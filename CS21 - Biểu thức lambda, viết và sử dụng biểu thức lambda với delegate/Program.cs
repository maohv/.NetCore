internal class Program
{
    /*
        Lamba - Anonymous function
        1) 
        (tham_so) => bieuthuc
        2)
        (thamso) => {
            cac_bieu_thuc;
            return bieu_thuc_tra_ve;
        }
    */
    static void Main(string[] args)
    {
        // Action<string> thongbao;

        // thongbao = (string s) => Console.WriteLine(s); //~delegate void KIEU(string s) tương đương Action<string>;

        // thongbao?.Invoke("Xin chao");

        // Action<string, string> welcome;

        // welcome = (msg, name) =>
        // {
        //     Console.BackgroundColor = ConsoleColor.DarkBlue;
        //     Console.WriteLine(msg + " " + name);
        //     Console.ResetColor();
        // };

        // welcome?.Invoke("Mao", "xin chao");


        int[] mang = { 1, 4, 6, 7, 9, 2, 3 };
        //select trả về tập hợp các phần tử đc biến đổi khi đi qua biểu lamda
        // var kq = mang.Select((int x) =>
        // {
        //     return Math.Sqrt(x);
        // });
        // foreach (var item in kq)
        // {
        //     Console.WriteLine(item);
        // }

        var kq = mang.Where(
            (int x) =>
            {
                return x >= 4;
            }
        );

        foreach (var item in kq)
        {
            Console.WriteLine(item);
        }
    }
}