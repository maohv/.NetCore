using System.Linq;
using Mylib;
//extension mothod

//lớp tĩnh static
static class Abc
{
    public static void Print(this string s, ConsoleColor color) //thêm this trở thành phương thức mở rộng 
    {
        Console.ForegroundColor = color;
        Console.WriteLine(s);
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        // string s = "Xin chao cac ban";
        // s.Print(ConsoleColor.Green);
        // "Minh".Print(ConsoleColor.DarkBlue);
        // "Test".Print(ConsoleColor.DarkRed);

        double a = 2.5;

        Console.WriteLine(a.BinhPhuong());
        Console.WriteLine(a.CanBacHai());

    }
}