public static class UseFirstMiddlewareMethod
{
    public static void UseFirstMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<FirstMiddleWare>();
    }
    public static void UseSecondMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<SecondMiddleWare>();
    }
}