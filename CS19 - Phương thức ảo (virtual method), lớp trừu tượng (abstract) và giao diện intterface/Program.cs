internal class Program
{
    //virtual method

    //abstract thì là lớp trừu tượng, sẽ không thể khởi tạo lớp đối tượng, chỉ dùng để làm cơ sở cho lớp kế thừa
    // abstract class Product
    // {
    //     public double Price { get; set; }

    //     //Phương thức nào bị ghi đè, định nghĩa lại là phương thức ảo thêm virtual

    //     // Đã là lớp trừu tượng thì lớp kế thừa phải định nghĩa lại nó  
    //     public abstract void ProducInfo();
    //     public void Test() => ProducInfo();
    // }
    // class Iphone : Product
    // {
    //     public Iphone() => Price = 500;

    //     //override cho biết phương thức này ghi đè 1 phương thức đã định nghĩa ở lớp cơ sở
    //     public override void ProducInfo()
    //     {
    //         Console.WriteLine("Dien thoai iphone");
    //         Console.WriteLine($"gia san pham {Price}");
    //     }
    // }

    //interface k đc dùng để tạo ra đối tượng, chỉ làm cơ sở cho các lớp kế thừa                                                   
    static void Main(string[] args)
    {
        // Iphone i = new Iphone();
        // i.Test();

        //Product p = new Product();


    }
}