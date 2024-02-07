var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Getting Response from First Middleware");
    await next();
    await context.Response.WriteAsync("Middleware1: Outgoing Response\n");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Getting Response from Second Middleware");
    await next();
    await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("\nGetting Response from Third Middleware");
    await context.Response.WriteAsync("Middleware3: Outgoing Response\n");
});

app.Run();
