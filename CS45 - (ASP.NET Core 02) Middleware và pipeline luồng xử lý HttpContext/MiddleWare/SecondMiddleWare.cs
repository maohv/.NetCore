public class SecondMiddleWare : IMiddleware
{
    /*
        Url: "/xxx.html"
        - khong goi MiddleWare phia sau
        - Ban k dc truy cap
        - SecondMiddleWare : Ban k dc truy cap
        Url: != "/xxx.html
        - SecondMiddleWare: ban dc truy cap
        - Chuyen httpcontext cho MiddleWare phia sau
    */
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path == "xxx.html")
        {
            context.Response.Headers.Add("SecondMiddleWare", "Ban duoc truy cap");
            var datafromFirstMiddleware = context.Items["DataFirstMiddleWare"];

            if (datafromFirstMiddleware != null)
                await context.Response.WriteAsync((string)datafromFirstMiddleware);

            await context.Response.WriteAsync("Ban khong duoc truy cap");
        }
        else
        {
            context.Response.Headers.Add("SecondMiddleWare", "Ban duoc truy cap");
            await next(context);
        }
    }
}