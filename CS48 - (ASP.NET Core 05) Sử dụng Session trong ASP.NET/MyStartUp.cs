using System.Text;
using Microsoft.Extensions.Options;

public class MyStartUp
{

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddSession((option) =>
        {
            option.Cookie.Name = "HoangMao";
            option.IdleTimeout = new TimeSpan(0, 30, 0);
        });
    }
    // Xay dung pipeline (chuoi Middleware)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSession();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                //context.Session
                await context.Response.WriteAsync("Hello, world");
            });

            endpoints.MapGet("/readwritesession", async context =>
            {
                int? count;
                count = context.Session.GetInt32("count"); //Doc session
                if (count == null)
                {
                    count = 0;
                }

                count += 1;
                context.Session.SetInt32("count", count.Value); //Luu session
                await context.Response.WriteAsync($"So lan truy cap vao readwritesession la: {count} ");
            });
        });
    }
}