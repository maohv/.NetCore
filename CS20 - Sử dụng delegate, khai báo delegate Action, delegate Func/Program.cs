using System;
namespace CS20___S__d_ng_delegate__khai_b_o_delegate_Action__delegate_Func
{
    //delegate (type) bien = phuong thuc
    public delegate void ShowLog(string message);
    internal class Program
    {
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void Tong(int a, int b, ShowLog log)
        {
            int kq = a + b;
            log?.Invoke($"Tong la {kq}");
        }
        static int Hieu(int a, int b) => a - b;

        static void Main(string[] args)
        {
            //delegate có thể nhận giá trị null
            ShowLog log = null;
            //log = Info;
            //if (log != null)
            //{ log("Xin chao"); }

            //log = Warning;
            //log?.Invoke("Hoc ve delegate");

            //Biến kiểu delagate có thể tham chiếu đến nhiều phương thức

            //log += Info;
            //log += Warning;

            //log?.Invoke("Xin Chao cac ban");

            //Action, Func : delegate - gereric

            //Action action; // ~delegate void KIEU();
            //Action<string, int> action1; // ~dalagate void KIEU(string s, int y)

            //Action<string> action2;

            //action2 = Warning;
            //action2 += Info;

            //action2?.Invoke("Thong bao tu Action");

            Func<int> f1;                       //~delegate int KIEU();
            Func<string, double, string> f2;    //~delegate string KIEU(string, double); Func kiểu trả về ở cuối cùng



            Func<int, int, int> tinhtoan; //~dalegate int KIEU(int a, int b);
            int a = 5;
            int b = 5;

            //tinhtoan = Tong;
            //Console.WriteLine($"KQ {tinhtoan(a, b)}");

            Tong(4, 5, Info);
        }

    }
}

