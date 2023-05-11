public delegate void SuKienNhapSo(int x);
/*
    publisher -> class -> phat su kien
    subsriber -> class -> nhan su kien
*/

//publisher
class UserInput
{
    public SuKienNhapSo sukiennhapso { get; set; }
    public void Input()
    {
        do
        {
            Console.WriteLine("Nhap vao so nguyen");
            string s = Console.ReadLine();
            int i = Int32.Parse(s);
            //phat su kien
            sukiennhapso?.Invoke(i);
        }
        while (true);
    }
}

class TinhCan
{
    public void Sub(UserInput input)
    {
        input.sukiennhapso = Can;
    }
    public void Can(int i)
    {
        Console.WriteLine($"Can bac hai cua {i} la {Math.Sqrt(i)}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        //publisher
        UserInput input = new UserInput();

        TinhCan tinhcan = new TinhCan();
        tinhcan.Sub(input);

        input.Input();
    }
}