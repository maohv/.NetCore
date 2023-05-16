using System;
using System.IO;
using System.Text;

class Product
{
    public int ID { get; set; }
    public double Price { get; set; }
    public string Name { get; set; }

    public void Save(Stream stream)
    {
        //int -> 4 byte
        var bytes_id = BitConverter.GetBytes(ID);
        stream.Write(bytes_id, 0, 4);

        //double -> 8 byte
        var bytes_price = BitConverter.GetBytes(Price);
        stream.Write(bytes_price, 0, 8);

        //chuoi Name
        var bytes_name = Encoding.UTF8.GetBytes(Name);
        var bytes_leng = BitConverter.GetBytes(bytes_name.Length);
        stream.Write(bytes_leng, 0, 4);
        stream.Write(bytes_name, 0, bytes_name.Length);
    }

    public void Restore(Stream stream)
    {
        //int 4 byte
        var byte_id = new byte[4];
        stream.Read(byte_id, 0, 4);
        ID = BitConverter.ToInt32(byte_id, 0);

        //double -> 8 byte
        var bytes_price = new byte[8];
        stream.Write(bytes_price, 0, 8);
        Price = BitConverter.ToDouble(bytes_price, 0);

        //chuoi Name
        var bytes_leng = new byte[4];
        stream.Read(bytes_leng, 0, 4);
        int leng = BitConverter.ToInt32(bytes_leng, 0);

        var bytes_name = new byte[leng];
        stream.Read(bytes_name, 0, leng);
        Name = Encoding.UTF8.GetString(bytes_name, 0, leng);
    }
}
internal class Program
{
    static void ListFileDirectory(string path)
    {
        String[] directories = Directory.GetDirectories(path);
        String[] files = Directory.GetFiles(path);
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
        foreach (var directory in directories)
        {
            Console.WriteLine(directory);
            ListFileDirectory(directory); // Đệ quy
        }
    }
    static void Main(string[] args)
    {
        //DriveInfo
        //Directory - Thu muc
        //Path
        //File

        // string path = "obj";

        // ListFileDirectory(path);


        string path = "data.dat";
        using var stream = new FileStream(path: path, FileMode.Open);

        Product product = new Product();
        // {
        //     ID = 10,
        //     Price = 12345,
        //     Name = "San Pham Abc"

        // };

        // product.Save(stream);

        product.Restore(stream);

        Console.WriteLine($"{product.Name} - {product.Price} - {product.ID}");


        ////luu du lieu
        //byte[] buffer = { 1, 2, 3 };

        //int offset = 0;

        //int count = 3;

        //stream.Write(buffer, 0, 3);

        ////Doc du lieu
        //int sobytedocduoc = stream.Read(buffer, 0, 3);

        //// int, double, --> byte. Su dung lop BitConverter

        //int abc = 1;
        //var byte_abc = BitConverter.GetBytes(abc);

        //// bytes --> int, double
        //BitConverter.ToInt32(byte_abc, 0);

    }
}