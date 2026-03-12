using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CyberQuiz.Application.Interfaces;
using CyberQuiz.Shared.DTOs.AiChat;
using CyberQuiz.Shared.Exceptions;

namespace CyberQuiz.Application.Services
{
    public class AiChatService : IAiChatService
    {
        //An object of HttpClient is injected into the AiChatService through its constructor.
        //This HttpClient is used to send HTTP requests to the Ollama API,
        //which is the AI service that processes the chat messages and quiz help requests.
        private readonly HttpClient _httpClient;

        public AiChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChatResponseDto> SendMessageAsync(ChatRequestDto request)
        //The method for "usual"(not ChatHelpRequest) chat messages.
        //It validates the input, constructs a request for the Ollama API,
        //sends it, and processes the response.
        {
            //Input validation: checks if the request is null, if the message is empty, and if the message is too long.
            if (request is null)
                throw new ValidationException("Request cannot be null.");

            if (string.IsNullOrWhiteSpace(request.Message))
                throw new ValidationException("Message cannot be empty.");

            if (request.Message.Length > 2000)
                throw new ValidationException("Message is too long.");

            var messages = new List<OllamaMessage> //Cteating the list of messages to send to the Ollama API,
                                                   //starting with a system message that sets the context for the AI's responses.
            {
                new()
                {
                    Role = "system", //prompt for the AI
                    Content = """
                              You are a helpful cybersecurity tutor.
                              Answer in simple English.
                              Keep answers short, clear, and practical.
                              Avoid long introductions, long lists, and unnecessary detail.
                              """
                }
            };
            //If there is a message history in the request, it adds those messages to the list,
            //normalizing their roles and trimming their content.
            //Do this only if there is a message history in the request.
            if (request.History is not null && request.History.Count > 0)
            {
                //Add the message history to the list of messages, normalizing roles and trimming content.
                messages.AddRange(
                    request.History
                        .Where(m => !string.IsNullOrWhiteSpace(m.Content))//Filter out messages with empty content.
                        .Select(m => new OllamaMessage //for every message in the history, create a new OllamaMessage
                                                       //with normalized role and trimmed content.
                        {
                            Role = NormalizeRole(m.Role),//Normalize the role of the message (user, assistant, system).
                            Content = m.Content.Trim()//Trim the content of the message to remove extra whitespace.
                        }));
            }

            //Adding a new user message

            messages.Add(new OllamaMessage
            {
                Role = "user",
                Content = request.Message.Trim()
            });
            //Constructing the request object to send to the Ollama API, specifying the model to use,
            //whether to stream the response, and the list of messages.
            var ollamaRequest = new OllamaChatRequest
            {
                Model = "phi3",//Specifies the model
                Stream = false,//Give ne the full response at once, not as a stream.
                Messages = messages
            };

            try
            {
                //Sending the request to the Ollama API and awaiting the response.
                using var response = await _httpClient.PostAsJsonAsync("/api/chat", ollamaRequest);
                //base address is alredy http://localhost:11434
                //endpoint is /api/chat, so the full URL is http://localhost:11434/api/chat
                //PostJsonAsync means - send the object as JSON in the body of the POST request.

                if (!response.IsSuccessStatusCode)//controlles if Ollama answrd with an error
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new DomainException($"AI service failed: {error}");
                }
                //Reading the response from the Ollama API and deserializing it into an OllamaChatResponse object.
                var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>();
                //Extracting the reply from the response, trimming it, and checking if it's empty.
                var reply = result?.Message?.Content?.Trim();

                if (string.IsNullOrWhiteSpace(reply))
                    throw new DomainException("AI service returned an empty response.");

                //Returning the reply in a ChatResponseDto object.
                return new ChatResponseDto
                {
                    Reply = reply
                };
            }

            //Handling exceptions that may occur during the HTTP request, such as network errors or timeouts,
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


        //==========================GET QUIZ HELP PART=================================
        //This method is specifically designed to provide help for quiz questions.
        public async Task<ChatResponseDto> GetQuizHelpAsync(QuizHelpRequestDto request)
        {
            //Quiz Help cant be provided without the question text and the correct answer, so we validate those first.
            if (request is null)
                throw new ValidationException("Request cannot be null.");

            if (string.IsNullOrWhiteSpace(request.QuestionText))
                throw new ValidationException("Question text is required.");

            if (string.IsNullOrWhiteSpace(request.CorrectAnswer))
                throw new ValidationException("Correct answer is required.");

            //Constructing a prompt for the AI that includes the quiz question, the user's answer, the correct answer,
            //and any extra explanation from the database.
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
                - Separate paragraphs with a blank line
                - Be clear and practical
                - Do not use bullet points
                - Do not repeat the full question
                - Focus only on why the correct answer is right, why the user's answer is wrong, and one short memory tip
                """;
            //Constructing the request object to send to the Ollama API, specifying the model to use,
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
                //the same as in the SendMessageAsync method
                //- sending the request to the Ollama API, checking for errors,
                using var response = await _httpClient.PostAsJsonAsync("/api/chat", ollamaRequest);
                // if Ollama answers with errors, we read the error message and throw a DomainException with that message.
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new DomainException($"AI service failed: {error}");
                }

                //Reading the response from the Ollama API, extracting the reply, checking if it's empty,
                //and returning it in a ChatResponseDto.
                var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>();
                var reply = result?.Message?.Content?.Trim();
                //If the reply is empty, we throw a DomainException indicating that the AI service
                //returned an empty response.
                if (string.IsNullOrWhiteSpace(reply))
                    throw new DomainException("AI service returned an empty response.");

                //If everything is fine, we return the reply in a ChatResponseDto object.
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

        /*
         The biggest difference between SendMessageAsync and GetQuizHelpAsync 
        is in how we construct the prompt for the AI and what kind of response we expect.
            
        SendMessageAsync uses:
        -user's new message
        -history (if exists)
        -more like a free chat

        GetQuizHelpAsync uses:
        -specific quiz question details (question text, user's answer, correct answer, extra explanation)
        -strickter prompt with clear rules for the AI to follow in its response
         */

        private static string NormalizeRole(string? role)
        {
            return role?.Trim().ToLowerInvariant() switch
            {
                "assistant" => "assistant",
                "system" => "system",
                _ => "user"
            };
        }
        //==========================HELPER CLASSES FOR OLLAMA API COMMUNICATION (MAPPING)=========================

        // These classes are kept inside AiChatService because they are only used internally
        // for communication with the Ollama API.
        //
        // They are not part of the shared contract between UI and API, so they do not belong
        // in the Shared project. The UI never sees or uses these classes.
        //
        // Their purpose is to map the JSON structure that Ollama expects and returns:
        // - OllamaChatRequest represents the request body sent to Ollama
        // - OllamaMessage represents individual chat messages in Ollama format
        // - OllamaChatResponse represents the response body returned from Ollama
        //
        // Keeping them here makes it clear that they are implementation details of this service,
        // not general application DTOs.
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