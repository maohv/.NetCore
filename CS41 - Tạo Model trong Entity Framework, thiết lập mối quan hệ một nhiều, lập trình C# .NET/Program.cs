using ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

internal class Program
{
    static void CreateDatabase()
    {
        using var dbContext = new ShopContext();
        string dbname = dbContext.Database.GetDbConnection().Database;

        var kq = dbContext.Database.EnsureCreated(); //Kiểm tra trên sever k có sẽ tạo ra csdl đó

        if (kq == true)
        {
            Console.WriteLine($"tao db {dbname} thanh cong");
        }
        else
        {
            Console.WriteLine($"tao db {dbname} k thanh cong");
        }

    }
    static void DropDatabase()
    {
        using var dbContext = new ShopContext();
        string dbname = dbContext.Database.GetDbConnection().Database;

        var kq = dbContext.Database.EnsureDeleted();

        if (kq == true)
        {
            Console.WriteLine($"Xoa db {dbname} thanh cong");
        }
        else
        {
            Console.WriteLine($"Xoa db {dbname} k thanh cong");
        }

    }
    static void InsertData()
    {
        using var dbContext = new ShopContext();
        dbContext.Add(new Category() { Name = "Dien thoai", Description = "Cac loai dien thoai" });
        dbContext.Add(new Category() { Name = "Do uong", Description = "Cac loai do uong" });


        dbContext.Add(new Product() { Name = "Iphone 11", Price = 10000, CateId = 1 });
        dbContext.Add(new Product() { Name = "Dien Thoai SamSung", Price = 9000, CateId = 1 });
        dbContext.Add(new Product() { Name = "Ruou Vang", Price = 1000, CateId = 2 });
        dbContext.Add(new Product() { Name = "Coca", Price = 300, CateId = 2 });
        dbContext.SaveChanges();
    }
    static void Main(string[] args)
    {

        InsertData();
        // using var dbContext = new ShopContext();
        // var product = from p in dbContext.products
        //               where p.CateId == 2
        //               select p;
        // product.ToList().ForEach(
        //     p => Console.WriteLine($"{p.Name} - {p.Price}")
        // );


    }
}