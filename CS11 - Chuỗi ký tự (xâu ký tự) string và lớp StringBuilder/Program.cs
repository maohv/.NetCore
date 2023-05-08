using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder thongbao = new StringBuilder();
        thongbao.Append("Xin");
        thongbao.Append(" chao cac ban");
        thongbao.Replace("xin chao", "chao mung" );
        string kq = thongbao.ToString();
        Console.WriteLine(kq);
    }
}