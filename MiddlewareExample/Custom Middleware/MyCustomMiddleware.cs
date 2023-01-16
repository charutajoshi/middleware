using System;
using System.Diagnostics;

namespace MiddlewareExample.CustomMiddleware
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class MyCustomMiddleware : IMiddleware
	{
		public MyCustomMiddleware()
		{
		}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My custom middleware starts\n");
            await next(context);
            await context.Response.WriteAsync("End"); 
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}

