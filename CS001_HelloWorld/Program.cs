internal class Program
{
    private static void Main(string[] args)
    {
        var n = Tong(1,5);
         Console.WriteLine(n);
    }

/// <summary>
/// Phuong thuc tra ve tong cua 2 so nguyen
/// </summary>
/// <param name="a">so nguyen 1</param>
/// <param name="b">so nguyen 2</param>
/// <returns>Tra ve tong a + b</returns>
    static int Tong(int a, int b){
        return a+b;
    }
}