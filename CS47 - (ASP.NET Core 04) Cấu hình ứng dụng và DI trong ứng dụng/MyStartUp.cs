using System.Text;
using Microsoft.Extensions.Options;

public class MyStartUp
{
    IConfiguration _configuration;
    public MyStartUp(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    //Dang ki cac dich vu cua ung dung (DI)
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<TestOptionsMiddleware>();
        services.AddOptions();

        var testOptinons = _configuration.GetSection("TestOptions");
        services.Configure<TestOptions>(testOptinons);

        //IOptions<TestOptions>
    }
    // Xay dung pipeline (chuoi Middleware)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<TestOptionsMiddleware>();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello, world");
            });

            endpoints.MapGet("/ShowOptions", async (context) =>
           {
               //var configuration = context.RequestServices.GetService<IConfiguration>();

               var testOptions = context.RequestServices.GetService<IOptions<TestOptions>>().Value;

               var stringBuiler = new StringBuilder();

               stringBuiler.Append("TESTOPTIONS\n");
               stringBuiler.Append($"opt_key1 = {testOptions.opt_key1}\n");
               stringBuiler.Append($"TestOptions.opt_key2.k1 = {testOptions.opt_key2.k1}\n");
               stringBuiler.Append($"TestOptions.opt_key2.k2 = {testOptions.opt_key2.k2}");

               await context.Response.WriteAsync(stringBuiler.ToString());

           });

        });
    }
}
