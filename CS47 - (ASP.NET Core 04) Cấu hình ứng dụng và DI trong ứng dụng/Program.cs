internal class Program
{
    static void Main(string[] args)
    {
        // var builder = WebApplication.CreateBuilder(args);
        // var app = builder.Build();

        // app.MapGet("/", () => "Hello World!");

        // app.Run();

        IHostBuilder builder = Host.CreateDefaultBuilder(args);
        //Cau hinh mac dinh cho HOST tao ra
        builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) =>
        {
            //Tuy bien them ve Host
            //webBuilder.
            webBuilder.UseStartup<MyStartUp>();
        });
        IHost host = builder.Build();
        host.Run();
    }
}