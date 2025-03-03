using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Service;
using Entite;


namespace Shope
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    //kt hpv
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,IServiceRating serviceRating)
        {
            Rating rating = new()
            {

                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method.ToString(),
                Path = httpContext.Request.Path.ToString(),
                Referer=httpContext.Request.Headers.Referer.ToString(),
                UserAgent=httpContext.Request.Headers.UserAgent.ToString(),
                RecordDate=DateTime.Now

            };
            await serviceRating.AddRating(rating);

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
