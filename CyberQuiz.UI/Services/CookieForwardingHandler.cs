using Microsoft.AspNetCore.Http;

namespace CyberQuiz.UI.Services;

public sealed class CookieForwardingHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var cookieHeader = httpContextAccessor.HttpContext?.Request.Headers.Cookie.ToString();

        if (!string.IsNullOrWhiteSpace(cookieHeader) && !request.Headers.Contains("Cookie"))
        {
            request.Headers.Add("Cookie", cookieHeader);
        }

        return base.SendAsync(request, cancellationToken);
    }
}