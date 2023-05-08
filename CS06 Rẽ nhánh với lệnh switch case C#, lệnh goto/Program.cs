internal class Program
{
    private static void Main(string[] args)
    {
        // int a = 3;

        // switch(a)
        // {
        //     case 1:
        //         Console.WriteLine($"Gia tri a bang mot");
        //     break;
        //     case 2:
        //         Console.WriteLine($"Gia tri a bang hai");
        //     break;
        //     case 3:
        //         Console.WriteLine($"Gia tri a bang ba");
        //     break;
        //     case 4:
        //         Console.WriteLine($"Gia tri a bang bon");
        //     break;

        //     default:
        //         Console.WriteLine("Hay thu so khac");
        //     break;
        // }

        int a, b;
        Console.WriteLine("Nhap so a: ");
        a = int.Parse(Console.ReadLine());

        Console.WriteLine("Nhap so b: ");
        b = int.Parse(Console.ReadLine());

        Console.WriteLine("Hay chon lenh");
        Console.WriteLine("1) Tinh tong");
        Console.WriteLine("2) Tinh hieu");
        Console.WriteLine("3) Tinh tich");
        Console.WriteLine("4) Tinh thuong");

        L1:
        char c = Console.ReadKey().KeyChar; //Đọc kí tự được nhấn

        switch(c)
        {
            case '1':
            Console.WriteLine($": Tong hai so a va b la {a + b}");
            break;
            case '2':
            Console.WriteLine($": Hieu hai so a va b la {a - b}");
            break;
            case '3':
            Console.WriteLine($": Tich hai so a va b la {a * b}");
            break;
            case '4':
            Console.WriteLine($": Thuong hai so a va b la {a / b}");
            break;

            default:
            Console.WriteLine("Hay chon cac lenh tren");
            goto L1;
            break;
        }
    }
}