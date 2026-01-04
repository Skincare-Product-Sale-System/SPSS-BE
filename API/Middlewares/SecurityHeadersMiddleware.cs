namespace API.Middlewares;

/// <summary>
/// Middleware to add security headers to all responses
/// </summary>
public class SecurityHeadersMiddleware
{
    private readonly RequestDelegate _next;

    public SecurityHeadersMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Prevent MIME type sniffing
        context.Response.Headers["X-Content-Type-Options"] = "nosniff";

        // Prevent clickjacking
        context.Response.Headers["X-Frame-Options"] = "DENY";

        // Enable XSS filter in browsers
        context.Response.Headers["X-XSS-Protection"] = "1; mode=block";

        // Referrer Policy
        context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";

        // Content Security Policy (adjust based on your needs)
        context.Response.Headers["Content-Security-Policy"] = "default-src 'self'";

        // Permissions Policy
        context.Response.Headers["Permissions-Policy"] = "camera=(), microphone=(), geolocation=()";

        // Remove server header
        context.Response.Headers.Remove("Server");
        context.Response.Headers.Remove("X-Powered-By");

        // Strict Transport Security (only add for HTTPS)
        if (context.Request.IsHttps)
        {
            context.Response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains";
        }

        await _next(context);
    }
}

/// <summary>
/// Extension method to add security headers middleware
/// </summary>
public static class SecurityHeadersMiddlewareExtensions
{
    public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SecurityHeadersMiddleware>();
    }
}
