internal class Program
{
    private static void Main(string[] args)
    {
        // //Mặc định .net 5.0 trở lên
        // var builder = WebApplication.CreateBuilder(args);
        // var app = builder.Build();

        // app.MapGet("/", async (context) =>
        // {
        //     // npm (nodejs)
        //     string html = "Trang Chu";
        //     await context.Response.WriteAsync(html);
        // });
        // app.MapGet("/tintuc", () => "Trang Tin Tuc");
        // app.MapGet("/thongtin", () => "Trang thong tin");

        // app.Run();




        //Tường minh
        Console.WriteLine("Start Up");
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