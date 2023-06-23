using System.Text;
using Microsoft.Extensions.Options;

public class MyStartUp
{
    //Dang ki cac dich vu cua ung dung (DI)
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages().AddRazorPagesOptions(options =>
        {
            options.RootDirectory = "/Pages";
            options.Conventions.AddPageRoute("/FirstPage", "/trang-dau-tien.html");


            services.Configure<RouteOptions>((routeOption) =>
            {
                routeOption.LowercaseUrls = true;               //Đăng kí dịch vụ url thành chữ thường
            });
        });
    }
    // Xay dung pipeline (chuoi Middleware)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            // FirstPage.cshtml URL=/FirstPage.html

            //Dichvu/Dichvu1

            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello, world");
            });

        });
    }
}

/*
    Razor page (.cshtml) = html + c#
    Engine Razor => bien dich cshtml -> response
    - @page
    - @bien, @(bieu-thuc), @phuongthuc
    @{
        //viet code c#

    }

    Rewrite URL

    Tag Helper -> HTML

    @addTagHelper * Microsoft.AspNetCore.Mvc.TagHelpers
*/