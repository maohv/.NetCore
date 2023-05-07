internal class Program
{
    private static void Main(string[] args)
    {
        // + - * / %
        // toan tu gan = += -= *= /= %=

        // float a = 5;
        // int b = 4;

        // Console.WriteLine($"a + b = {a + b}");
        // Console.WriteLine($"a - b = {a - b}");
        // Console.WriteLine($"a * b = {a * b}");
        // Console.WriteLine($"a / b = {a / b}");
        // Console.WriteLine($"a % b = {a % b}");

        int x;
        x = 10;
        int n = x++;
        Console.WriteLine(x);
        Console.WriteLine(n);


        int z = 2 * ++x;
        // x = x + 1
        // 2 * x 
        Console.WriteLine(x);
        Console.WriteLine(z);

    }
}