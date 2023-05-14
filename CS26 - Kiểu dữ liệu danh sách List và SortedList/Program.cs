using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int ID { get; set; }
    public string Origin { get; set; }
}
internal class Program
{
    // List
    // SortedList -> key/value
    static void Main(string[] args)
    {
        // List<int> ds1 = new List<int>() { 4, 7, 9, 5, 6, 8, 2 };

        // var rs = ds1.FindAll(
        //     (e) =>
        //     {
        //         return e % 2 == 0;
        //     }
        // );
        // foreach (var item in rs)
        // {
        //     Console.WriteLine(item);
        // }
        // List<Product> products = new List<Product>(){
        //     new Product(){
        //         Name = "Iphone X", Price = 1000, Origin = "China", ID = 1
        //     },
        //       new Product(){
        //         Name = "SamSung", Price = 900, Origin = "China", ID = 2
        //     },
        //       new Product(){
        //         Name = "Sony", Price = 1100, Origin = "Japan", ID = 3
        //     },
        //       new Product(){
        //         Name = "Nokia", Price = 600, Origin = "China", ID = 4
        //     },
        // };

        // var sanphamtimdc = products.FindAll(
        //     (p) =>
        //     {
        //         return p.Price <= 800;
        //     }
        // );
        // foreach (var p in products)
        // {
        //     Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
        // }

        // Console.WriteLine("=======================");
        // Console.WriteLine("Sau khi sắp xếp");
        // products.Sort(
        //     (p1, p2) =>
        //     {
        //         // 0 p1 == p2
        //         // 1 p1 > p2
        //         //-1 p1 < p2
        //         if (p1.Price == p2.Price) return 1;
        //         if (p1.Price < p2.Price) return 2;
        //         return -1;
        //     }
        // );
        // foreach (var p in products)
        // {
        //     Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
        // }

        SortedList<string, Product> products = new SortedList<string, Product>();
        products["sanpham1"] = new Product() { Name = "Iphone X", Price = 1000, Origin = "China", ID = 1 };
        products["sanpham2"] = new Product() { Name = "Samsung", Price = 900, Origin = "China", ID = 2 };
        products.Add("sanpham3", new Product() { Name = "Samsung", Price = 900, Origin = "China", ID = 3 });

        var p = products["sanpham2"];
        Console.WriteLine(p.Name);

        // var keys = products.Keys;
        // var values = products.Values;

        // foreach (var k in keys)
        // {
        //     var product = products[k];
        //     Console.WriteLine(product.Name);
        // }

        foreach (KeyValuePair<string, Product> item in products)
        {
            var key = item.Key;
            var value = item.Value;
            Console.WriteLine($"{key} - {value.Name}");
        }
    }
}