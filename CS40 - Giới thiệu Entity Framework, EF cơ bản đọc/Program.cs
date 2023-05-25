using ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

internal class Program
{
    static void CreateDatabase()
    {
        using var dbContext = new ProductDbContext();
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
        using var dbContext = new ProductDbContext();
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
    static void InsertProduct()
    {
        using var dbContext = new ProductDbContext();

        // var p1 = new Product()
        // {
        //     ProductName = "San Pham 2",
        //     Provider = "Cong ty 2"
        // };

        //dbContext.Add(p1);

        //Tạo nhiều dữ liệu cùng 1 lúc
        var products = new object[]{
            new Product(){ProductName = "San Pham 3", Provider = "Cong ty A"},
            new Product(){ProductName = "San Pham 4", Provider = "Cong ty B"},
            new Product(){ProductName = "San Pham 3", Provider = "Cong ty C"}
        };
        dbContext.AddRange(products);

        int number_rows = dbContext.SaveChanges();
        Console.WriteLine($"Da chen {number_rows} dong du lieu");
    }
    static void Readproducts()
    {
        using var dbContext = new ProductDbContext();
        //Linq
        // var products = dbContext.products.ToList();
        // foreach (var item in products)
        // {
        //     Console.WriteLine($"{item.ProductName} - {item.Provider}");
        // }

        var qr = from product in dbContext.products
                 where product.ProductId >= 3
                 select product;
        qr.ToList().ForEach(
            product => Console.WriteLine($"{product.ProductName} - {product.Provider}")

        );
    }
    static void RenameProduct(int id, string newName)
    {
        using var dbContext = new ProductDbContext();

        var product = (from p in dbContext.products
                       where p.ProductId == id
                       select p).FirstOrDefault();

        if (product != null)
        {
            //theo doi su thay doi cua product
            EntityEntry<Product> entry = dbContext.Entry(product);

            product.ProductName = newName;
            int number_rows = dbContext.SaveChanges();
            Console.WriteLine($"Da thay doi {number_rows} dong du lieu");
        }
    }
    static void Main(string[] args)
    {

        //Insert, Select, Update, Delete

        //RenameProduct(3, "May tinh");
        Readproducts();
    }
}