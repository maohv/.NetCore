internal class Program
{
    // <Access Modifiers> <return type> <name_method>(<parameters>)
    // {
    //     // Các câu lệnh trong phương thức
    // }
    static void Main(string[] args)
    {
        // XinChao("Mao","Hoang");

        

        // var result = CS009_Methods.Tinhtoan.Tong(12, 13);

        // Console.WriteLine(result);
    }

    public static int Tich(int a, int b)
    {
        int result;
        result = a * b;
        return result;
    }
    static void XinChao(string ho, string ten){
        string fullName = ho + " " + ten;
        Console.WriteLine($"Xin Chao {fullName}");
    }
}