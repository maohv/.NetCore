public class FirstMiddleWare
{
    private readonly RequestDelegate _next;

    //RequestDelegate ~ async (HttpContext context) => {}
    public FirstMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    //HttpContext di qua MiddleWare trong pipeline
    public async Task InvoikeAsync(HttpContext context)
    {
        Console.WriteLine(context.Request.Path);
        context.Items.Add("DataFirstMiddleWare", $"<p>URL: {context.Request.Path}</p>");
        //await context.Response.WriteAsync($"<p>URL: {context.Request.Path}</p>");
        await _next(context);
    }
}