using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace ef
{
    // Thuộc tính products kiểu DbSet<Product> cho biết CSDL có bảng mà
    // thông tin về bảng dữ liệu biểu diễn bởi model Product
    public class ProductDbContext : DbContext
    {
        //log
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();

        });
        public DbSet<Product> products { get; set; }
        private const string connectionString = "Data Source=DESKTOP-9L14R4S\\SQLEXPRESS;Initial Catalog=db01;Persist Security Info=True;User ID=sa;Password=123456; TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}