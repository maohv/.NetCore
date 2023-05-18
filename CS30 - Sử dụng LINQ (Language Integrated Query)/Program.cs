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
        //Any
        //All
        //Count

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
        // var p = products.Single(p => p.Price == 600);
        //var p = products.SingleOrDefault(p => p.Price == 400);
        //var p = products.Count(p => p.Price == 400);


        //in ra ten san pham, ten thuong hieu, co gia (300-400)
        //gia giam dan

        // products.Where(p => p.Price >= 300 && p.Price <= 400)
        //         .OrderByDescending(p => p.Price)
        //         .Join(brands, p => p.Brand, b => b.ID, (p, b) =>
        //         {
        //             return new
        //             {
        //                 TenSp = p.Name,
        //                 tenTH = b.Name,
        //                 Gia = p.Price,
        //             };
        //         })
        //         .ToList()
        //         .ForEach(info =>
        //         {
        //             Console.WriteLine($"{info.TenSp,15} {info.tenTH,15} {info.Gia,15}");
        //         });

        //cach viet ro rang LINGQ

        /*
        1) Xac dinh nguon: from tenphantu in IEnumerable
            ... where, order by
        2) Lay du lieu: select, group by ...
        */

        // var qr = from p in products
        //          where p.Price <= 400
        //          select new
        //          {
        //              Ten = p.Name,
        //              Gia = p.Price,

        //          };
        // qr.ToList().ForEach(kq => Console.WriteLine(kq));

        //nhom san pham theo gia
        // var qr = from p in products
        //          group p by p.Price;

        // qr.ToList().ForEach(gr =>
        // {
        //     Console.WriteLine(gr.Key);
        //     gr.ToList().ForEach(p => Console.WriteLine(p));
        // });

        //Doi tuong:
        //Gia
        //cac san pham
        //So luong

        // var qr = from p in products
        //          group p by p.Price into gr
        //          orderby gr.Key
        //          let s1 = "So luong la " + gr.Count()

        //          select new
        //          {
        //              Gia = gr.Key,
        //              cacsanpham = gr.ToList(),
        //              solong = s1
        //          };

        // qr.ToList().ForEach(i =>
        // {

        //     Console.WriteLine(i.Gia);
        //     Console.WriteLine(i.solong);
        //     i.cacsanpham.ForEach(p => Console.WriteLine(p));

        // });

        // var qr = from p in products
        //          join b in brands on p.Brand equals b.ID
        //          select new
        //          {
        //              ten = p.Name,
        //              gia = p.Price,
        //              thuonghieu = b.Name
        //          };
        // qr.ToList().ForEach(kq =>
        // {
        //     Console.WriteLine($"{kq.ten} - {kq.gia} - {kq.thuonghieu}");
        // });

        var qr = from p in products
                 join b in brands on p.Brand equals b.ID into t //lưu ra biến tạm t
                 from b2 in t.DefaultIfEmpty() //trả về giá trị nếu tìm thấy, k thì b2 = null
                 select new
                 {
                     ten = p.Name,
                     gia = p.Price,
                     thuonghieu = (b2 != null) ? b2.Name : "No brand"
                 };
        qr.ToList().ForEach(kq =>
        {
            Console.WriteLine($"{kq.ten} - {kq.gia} - {kq.thuonghieu}");
        });
    }
}