using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.AiChat;

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
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Message))
                throw new ArgumentException("Message cannot be empty.");

            var messages = new List<OllamaMessage>
            {
                new()
                {
                    Role = "system",
                    Content = "You are a helpful cybersecurity tutor. Answer clearly, simply, and briefly."
                }
            };

            if (request.History is not null && request.History.Count > 0)
            {
                messages.AddRange(request.History
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

            using var response = await _httpClient.PostAsJsonAsync("/api/chat", ollamaRequest);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ollama error: {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>();

            return new ChatResponseDto
            {
                Reply = result?.Message?.Content?.Trim() ?? "No response from AI."
            };
        }

        public async Task<ChatResponseDto> GetQuizHelpAsync(QuizHelpRequestDto request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var prompt = $"""
                You are a helpful cybersecurity tutor for a quiz application.

                Explain this quiz question in simple English.

                Question:
                {request.QuestionText}

                User's answer:
                {request.UserAnswer ?? "No answer provided"}

                Correct answer:
                {request.CorrectAnswer}

                Extra explanation from database:
                {request.Explanation ?? "No extra explanation"}

                Your task:
                1. Explain why the correct answer is right.
                2. Explain why the user's answer is wrong, if they answered incorrectly.
                3. Give a short tip for how to remember it next time.

                Keep the answer short, clear, and friendly.
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
                        Content = "You are a helpful cybersecurity tutor."
                    },
                    new()
                    {
                        Role = "user",
                        Content = prompt
                    }
                }
            };

            using var response = await _httpClient.PostAsJsonAsync("/api/chat", ollamaRequest);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Ollama error: {error}");
            }

            var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>();

            return new ChatResponseDto
            {
                Reply = result?.Message?.Content?.Trim() ?? "No response from AI."
            };
        }

        private static string NormalizeRole(string? role)
        {
            return role?.Trim().ToLower() switch
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