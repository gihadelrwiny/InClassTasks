namespace WebApplication1.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CorrelationIdMiddleware> _logger;
        public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            const string HeaderName = "X-Correlation-Id";
            string correlationId;
            if (context.Request.Headers.TryGetValue(HeaderName, out var value))
            {
                correlationId = value!;
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
            }
            _logger.LogInformation(
            "Request started. CorrelationId = {CorrelationId}",
            correlationId);
            context.Response.Headers[HeaderName] = correlationId;

            await _next(context);
            _logger.LogInformation(
           "Request finished. CorrelationId = {CorrelationId}",
           correlationId);
        }
    }
}
