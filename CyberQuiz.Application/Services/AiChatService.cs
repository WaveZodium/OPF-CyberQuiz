using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.AiChat;
using CyberQuiz.Shared.Exceptions;

namespace CyberQuiz.Application.Services
{
    public class AiChatService : IAiChatService
    {
        private readonly HttpClient _httpClient;

        public AiChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChatResponseDto> SendMessageAsync(ChatRequestDto request)
        {
            if (request is null)
                throw new ValidationException("Request cannot be null.");

            if (string.IsNullOrWhiteSpace(request.Message))
                throw new ValidationException("Message cannot be empty.");

            if (request.Message.Length > 2000)
                throw new ValidationException("Message is too long.");

            var messages = new List<OllamaMessage>
            {
                new()
                {
                    Role = "system",
                    Content = """
                              You are a helpful cybersecurity tutor.
                              Answer in simple English.
                              Keep answers short, clear, and practical.
                              Avoid long introductions, long lists, and unnecessary detail.
                              """
                }
            };

            if (request.History is not null && request.History.Count > 0)
            {
                messages.AddRange(
                    request.History
                        .Where(m => !string.IsNullOrWhiteSpace(m.Content))
                        .Select(m => new OllamaMessage
                        {
                            Role = NormalizeRole(m.Role),
                            Content = m.Content.Trim()
                        }));
            }

            messages.Add(new OllamaMessage
            {
                Role = "user",
                Content = request.Message.Trim()
            });

            var ollamaRequest = new OllamaChatRequest
            {
                Model = "phi3",
                Stream = false,
                Messages = messages
            };

            try
            {
                using var response = await _httpClient.PostAsJsonAsync("/api/chat", ollamaRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new DomainException($"AI service failed: {error}");
                }

                var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>();
                var reply = result?.Message?.Content?.Trim();

                if (string.IsNullOrWhiteSpace(reply))
                    throw new DomainException("AI service returned an empty response.");

                return new ChatResponseDto
                {
                    Reply = reply
                };
            }
            catch (DomainException)
            {
                throw;
            }
            catch (HttpRequestException)
            {
                throw new DomainException("AI service is temporarily unavailable.");
            }
            catch (TaskCanceledException)
            {
                throw new DomainException("AI service timed out.");
            }
        }

        public async Task<ChatResponseDto> GetQuizHelpAsync(QuizHelpRequestDto request)
        {
            if (request is null)
                throw new ValidationException("Request cannot be null.");

            if (string.IsNullOrWhiteSpace(request.QuestionText))
                throw new ValidationException("Question text is required.");

            if (string.IsNullOrWhiteSpace(request.CorrectAnswer))
                throw new ValidationException("Correct answer is required.");

            var prompt = $"""
                Explain this quiz question in simple English.

                Question:
                {request.QuestionText}

                User's answer:
                {request.UserAnswer ?? "No answer provided"}

                Correct answer:
                {request.CorrectAnswer}

                Extra explanation from database:
                {request.Explanation ?? "No extra explanation"}

                Rules:
                - Maximum 3 short paragraphs
                - Maximum 90 words total
                - Be clear and practical
                - Do not use bullet points
                - Do not repeat the full question
                - Focus only on why the correct answer is right, why the user's answer is wrong, and one short memory tip
                """;

            var ollamaRequest = new OllamaChatRequest
            {
                Model = "phi3",
                Stream = false,
                Messages = new List<OllamaMessage>
                {
                    new()
                    {
                        Role = "system",
                        Content = """
                                  You are a helpful cybersecurity tutor for a quiz application.
                                  Write short, clear, practical explanations in simple English.
                                  Do not give long lectures.
                                  Do not use long lists.
                                  Keep the answer concise and easy to read in a small UI card.
                                  """
                    },
                    new()
                    {
                        Role = "user",
                        Content = prompt
                    }
                }
            };

            try
            {
                using var response = await _httpClient.PostAsJsonAsync("/api/chat", ollamaRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new DomainException($"AI service failed: {error}");
                }

                var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>();
                var reply = result?.Message?.Content?.Trim();

                if (string.IsNullOrWhiteSpace(reply))
                    throw new DomainException("AI service returned an empty response.");

                return new ChatResponseDto
                {
                    Reply = reply
                };
            }
            catch (DomainException)
            {
                throw;
            }
            catch (HttpRequestException)
            {
                throw new DomainException("AI service is temporarily unavailable.");
            }
            catch (TaskCanceledException)
            {
                throw new DomainException("AI service timed out.");
            }
        }

        private static string NormalizeRole(string? role)
        {
            return role?.Trim().ToLowerInvariant() switch
            {
                "assistant" => "assistant",
                "system" => "system",
                _ => "user"
            };
        }

        private class OllamaChatRequest
        {
            [JsonPropertyName("model")]
            public string Model { get; set; } = string.Empty;

            [JsonPropertyName("messages")]
            public List<OllamaMessage> Messages { get; set; } = [];

            [JsonPropertyName("stream")]
            public bool Stream { get; set; }
        }

        private class OllamaChatResponse
        {
            [JsonPropertyName("message")]
            public OllamaMessage? Message { get; set; }
        }

        private class OllamaMessage
        {
            [JsonPropertyName("role")]
            public string Role { get; set; } = string.Empty;

            [JsonPropertyName("content")]
            public string Content { get; set; } = string.Empty;
        }
    }
}