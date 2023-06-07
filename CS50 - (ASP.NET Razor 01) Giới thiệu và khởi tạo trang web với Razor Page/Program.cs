internal class Program
{
    static void Main(string[] args)
    {
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