using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello, world");
    });

    endpoints.MapGet("/ShowOptions", async (context) =>
   {
       var configuration = context.RequestServices.GetService<IConfiguration>();

       var testOptions = configuration.GetSection("TestOptions");

       var opt_key1 = testOptions["opt_key1"];

       var k1 = testOptions.GetSection("opt_key2")["K1"];
       var k2 = testOptions.GetSection("opt_key2")["K2"];

       var stringBuiler = new StringBuilder();

       stringBuiler.Append("TESTOPTIONS\n");
       stringBuiler.Append($"opt_key1 = {opt_key1}\n");
       stringBuiler.Append($"TestOptions.opt_key2.k1 = {k1}\n");
       stringBuiler.Append($"TestOptions.opt_key2.k2 = {k2}");

       await context.Response.WriteAsync(stringBuiler.ToString());

   });

});

app.Run();
