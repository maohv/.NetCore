public class MyStartUp
{
    //Dang ki cac dich vu cua ung dung (DI)
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<SecondMiddleWare>();
    }
    // Xay dung pipeline (chuoi Middleware)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // app.UseMiddleware<FirstMiddleWare>();

        //app.UseStaticFiles();//StaticFileMiddleware

        app.UseFirstMiddleware(); //Dua vao pipeline Middleware

        app.UseSecondMiddleware();

        app.UseRouting(); //EndpointRoutingMiddleware

        //tao Endpoin();

        app.UseEndpoints((endpoint) =>
        {
            //E1
            endpoint.MapGet("/about.html", async (context) =>
            {
                await context.Response.WriteAsync("Day la trang gioi thieu");
            });
            //E2
            endpoint.MapGet("/sanpham.html", async (context) =>
           {
               await context.Response.WriteAsync("Day la trang san pham");
           });
        });

        //re nhanh pipeline
        app.Map("/admin", (app1) =>
        {
            //Tao Middleware cua nhanh

            app.UseRouting();
            //BE1
            app1.UseEndpoints((endpoint) =>
            {
                endpoint.MapGet("/user", async (context) =>
                {
                    await context.Response.WriteAsync("Trang quan li user");
                });
            });

            //BE2
            app1.UseEndpoints((endpoint) =>
            {
                endpoint.MapGet("/product", async (context) =>
                {
                    await context.Response.WriteAsync("Trang quan li san pham");
                });
            });


            //M2
            app1.Run(async (context) =>
            {
                await context.Response.WriteAsync("Trang admin");
            });
        });

        //Terminate Middleware M1
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Xin Chao ASP.NET CORE");
        });
    }
}

/*
HttpContext
pipeline : StaticFileMiddleware -> FirstMiddleware -> SecondMiddleware -> EndpointRoutingMiddleware -> M1
*/