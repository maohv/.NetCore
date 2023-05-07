internal class Program
{
    private static void Main(string[] args)
    {
     
        /*
        if(dieu kien logic){
            dong lenh
        }
        */

        // int a;
        // Console.WriteLine("Nhap so nguyen a: ");
        // a = int.Parse(Console.ReadLine());

        // if(a % 2 == 0){
        //     Console.WriteLine($"so {a} la so chan");
        // }else{
        //     Console.WriteLine($"so {a} khong phai la so chan");
        // }       
        
        // float dtb;
        // Console.WriteLine("Hay nhap diem trung binh");
        // dtb = float.Parse(Console.ReadLine());
        // if(dtb < 5){
        //     Console.WriteLine("Yeu");
        // }else if(dtb >= 5 && dtb <= 7 ){
        //     Console.WriteLine("Kha");
        // }else
        // {
        //     Console.WriteLine("Gioi");
        // }

        // float a, b;
        // Console.WriteLine("nhap so a: ");
        // a = float.Parse(Console.ReadLine());

        // Console.WriteLine("nhap so b: ");
        // b = float.Parse(Console.ReadLine());

        // float max;

        // // (dieu_kien) ? bieuthuc1 : bieuthuc2

        // max = (a > b) ? a : b;

        // Console.WriteLine($"So lon nhat la: {max}");

        float a = 2, b =3.5f, c = 1;
        float max;

        max = (a > b) ? (a > c) ? a : c : (b > c) ? a : c;
        // (a > b) ? a : b;

        // (a > c) ? a : c; 

        // (b > c) ? b : c;

        Console.WriteLine(max);

    }
}