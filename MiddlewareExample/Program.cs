var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello\n");
    await next(context); 
});

// Middleware 2
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("World");
});

app.Run();

