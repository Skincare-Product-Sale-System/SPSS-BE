using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ResponseCachingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ResponseCachingMiddleware> _logger;

        public ResponseCachingMiddleware(
            RequestDelegate next,
            IMemoryCache cache,
            ILogger<ResponseCachingMiddleware> logger)
        {
            _next = next;
            _cache = cache;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Only cache GET requests
            if (context.Request.Method != "GET")
            {
                await _next(context);
                return;
            }

            // Skip caching for authenticated requests or specific paths
            if (context.Request.Headers.ContainsKey("Authorization") ||
                context.Request.Path.StartsWithSegments("/api/auth") ||
                context.Request.Path.StartsWithSegments("/api/cart") ||
                context.Request.Path.StartsWithSegments("/api/order"))
            {
                await _next(context);
                return;
            }

            var cacheKey = $"response_cache:{context.Request.Path}{context.Request.QueryString}";

            // Try to get cached response
            if (_cache.TryGetValue(cacheKey, out CachedResponse cachedResponse))
            {
                _logger.LogDebug("Cache hit for: {Path}", context.Request.Path);
                context.Response.StatusCode = cachedResponse.StatusCode;
                context.Response.ContentType = cachedResponse.ContentType;
                await context.Response.WriteAsync(cachedResponse.Body);
                return;
            }

            // Capture response
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            // Cache successful responses
            if (context.Response.StatusCode == 200)
            {
                responseBody.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(responseBody).ReadToEndAsync();
                responseBody.Seek(0, SeekOrigin.Begin);

                var cached = new CachedResponse
                {
                    StatusCode = context.Response.StatusCode,
                    ContentType = context.Response.ContentType ?? "application/json",
                    Body = responseText
                };

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                _cache.Set(cacheKey, cached, cacheOptions);
                _logger.LogDebug("Cached response for: {Path}", context.Request.Path);
            }

            await responseBody.CopyToAsync(originalBodyStream);
        }

        private class CachedResponse
        {
            public int StatusCode { get; set; }
            public string ContentType { get; set; }
            public string Body { get; set; }
        }
    }
}
