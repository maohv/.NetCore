using System;

public delegate void SuKienNhapSo(int x);
/*
    publisher -> class -> phat su kien
    subsriber -> class -> nhan su kien
*/

//publisher

class Dulieunhap : EventArgs
{
    public int data { get; set; }
    public Dulieunhap(int x) => data = x;
}
class UserInput
{
    // public event SuKienNhapSo sukiennhapso;

    public event EventHandler sukiennhapso; //tương đương ~delegate void KIEU(object? sender, EventArg args);
    public void Input()
    {
        do
        {
            Console.WriteLine("Nhap vao so nguyen");
            string s = Console.ReadLine();
            int i = Int32.Parse(s);
            //phat su kien
            sukiennhapso?.Invoke(this, new Dulieunhap(i));
        }
        while (true);
    }
}

class TinhCan
{
    public void Sub(UserInput input)
    {
        input.sukiennhapso += Can;
    }
    //~delegate void KIEU(object? sender, EventArg args);
    public void Can(object sender, EventArgs e)
    {
        Dulieunhap dulieunhap = (Dulieunhap)e;
        int i = dulieunhap.data;
        Console.WriteLine($"Can bac hai cua {i} la {Math.Sqrt(i)}");
    }
}
class BinhPhuong
{
    public void Sub(UserInput input)
    {
        input.sukiennhapso += TinhBinhPhuong;
    }
    public void TinhBinhPhuong(object sender, EventArgs e)
    {
        Dulieunhap dulieunhap = (Dulieunhap)e;
        int i = dulieunhap.data;
        Console.WriteLine($"Can bac hai cua {i} la {i * i}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        //publisher
        UserInput input = new UserInput();

        input.sukiennhapso += (sender, e) =>
        {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            Console.WriteLine("Ban vua nhap so" + dulieunhap.data);
        };

        //subcriber
        TinhCan tinhcan = new TinhCan();
        tinhcan.Sub(input);

        BinhPhuong binhphuong = new BinhPhuong();
        binhphuong.Sub(input);

        input.Input();
    }
}