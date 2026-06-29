using System.Runtime.CompilerServices;

namespace WebApplication1.Middlewares
{
    public static  class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTiming(this IApplicationBuilder app)=>
             app.UseMiddleware<RequestTimingMiddleware>();

        public static IApplicationBuilder UseCorrelationId( this IApplicationBuilder app)
        =>  app.UseMiddleware<CorrelationIdMiddleware>();
        
    }
}
