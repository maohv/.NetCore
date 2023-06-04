public class TestOptionsMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Show options in TestOptionsMiddle");
        await next(context);
    }
}