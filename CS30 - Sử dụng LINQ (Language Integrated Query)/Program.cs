using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ID { set; get; }
    public string Name { set; get; }         // tên
    public double Price { set; get; }        // giá
    public string[] Colors { set; get; }     // các màu sắc
    public int Brand { set; get; }           // ID Nhãn hiệu, hãng
    public Product(int id, string name, double price, string[] colors, int brand)
    {
        ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
    }
    // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
    override public string ToString()
       => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

}
public class Brand
{
    public string Name { set; get; }
    public int ID { set; get; }
}
internal class Program
{
    //LINQ (Language Integrated Query) : ngon ngu truy van va tich hop
    // SQL
    //Nguon du lieu: IEnumerable, IEnumerable<T> (Array, List, Stack, Queue ...)
    //             : XML, SQL
    static void Main(string[] args)
    {
        // Product p = new Product(1, "Abc", 1000, new string[] { "Xanh", "Do" }, 2);
        // Console.WriteLine(p.ToString());

        var brands = new List<Brand>()
        {
            new Brand{ID = 1, Name = "Công ty AAA"},
            new Brand{ID = 2, Name = "Công ty BBB"},
            new Brand{ID = 4, Name = "Công ty CCC"},
        };
        var products = new List<Product>()
        {
            new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
            new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
            new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
            new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
            new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
            new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
            new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
        };

        // var query = from p in products
        //             where p.Price == 400
        //             select p;

        // foreach (var product in query)
        // {
        //     Console.WriteLine(product);
        // }

        //select
        //where
        //selectMany
        //Min, max, sum, average
        //join
        //Take
        //Skip
        //Oderby (tang dan) / OderbyByDescending (lon den nho) 
        //Groupby
        //Distinct
        //single SingleOrdefault

        // var kq = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
        // {
        //     return new
        //     {
        //         Ten = p.Name,
        //         ThuongHieu = b.Name,
        //     };
        // });

        // var kq = brands.GroupJoin(products, b => b.ID, p => p.Brand,
        //     (brands, pros) =>
        //     {
        //         return new
        //         {
        //             Thuonghieu = brands.Name,
        //             Cacsanpham = pros,
        //         };

        //     }
        // );

        // foreach (var gr in kq)
        // {
        //     Console.WriteLine(gr.Thuonghieu);
        //     foreach (var p in gr.Cacsanpham)
        //     {
        //         Console.WriteLine(p);
        //     }
        // }

        // products.Take(2).ToList().ForEach(p => Console.WriteLine(p));
        // products.Skip(2).ToList().ForEach(p => Console.WriteLine(p)); //bỏ qua 2 phần tử đầu tiên

        //products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));
        // var kq = products.GroupBy(p => p.Brand);
        // foreach (var group in kq)
        // {
        //     Console.WriteLine(group.Key);
        //     foreach (var p in group)
        //     {
        //         Console.WriteLine(p);
        //     }
        // }

        //products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(p => Console.WriteLine(p));
    }
}