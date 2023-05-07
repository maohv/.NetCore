internal class Program
{
    private static void Main(string[] args)
    {
     
        /*
        if(dieu kien logic){
            dong lenh
        }
        */

        int a;
        Console.WriteLine("Nhap so nguyen a: ");
        a = int.Parse(Console.ReadLine());

        if(a % 2 == 0){
            Console.WriteLine($"so {a} la so chan");
        }else{
            Console.WriteLine($"so {a} khong phai la so chan");
        }
    }
}