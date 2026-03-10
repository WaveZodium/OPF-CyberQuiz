namespace CyberQuiz.UI.Services;

public sealed class ApiClient(HttpClient httpClient) : IApiClient
{
    public HttpClient HttpClient { get; } = httpClient;
}