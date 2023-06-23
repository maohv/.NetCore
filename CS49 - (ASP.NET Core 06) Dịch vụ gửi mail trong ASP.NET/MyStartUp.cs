using System.Text;
using Microsoft.Extensions.Options;

public class MyStartUp
{
    IConfiguration _configuration;
    public MyStartUp(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        var mailsettings = _configuration.GetSection("Mailsettings");

        services.Configure<MailSettings>(mailsettings);

        services.AddTransient<SendMailService>();
    }
    // Xay dung pipeline (chuoi Middleware)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello, world");
            });

            endpoints.MapGet("/TestSendMail", async context =>
            {
                var message = await MailUtils.MailUtils.SendMail("maohvhn@gmail.com", "maohvhn@gmail.com", "TEST", "Xin Chao Mao");
                await context.Response.WriteAsync(message);
            });

            endpoints.MapGet("/TestGmail", async context =>
           {
               var message = await MailUtils.MailUtils.SendGmail("dream199001@gmail.com", "dream199001@gmail.com", "TEST GMAIL", "Xin Chao Mao", "dream199001@gmail.com", "Alook@123");
               await context.Response.WriteAsync(message);
           });

            endpoints.MapGet("/TestSendMailService", async context =>
          {
              var sendMailService = context.RequestServices.GetService<SendMailService>();
              var mailContent = new MailContent();
              mailContent.To = "dream199001@gmail.com";
              mailContent.Subject = "Kiem TRA GUI EMAIL";
              mailContent.Body = "asdaaaasss o k ok ";

              var kq = await sendMailService.SendMail(mailContent);
              await context.Response.WriteAsync(kq);
          });
        });
    }
}