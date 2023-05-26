using System.Data.Common;
using System.Data.SqlClient;

internal class Program
{
    static void Main(string[] args)
    {
        string sqlStringConnection = "Data Source=DESKTOP-9L14R4S\\SQLEXPRESS;Initial Catalog=xtlab;Persist Security Info=True;User ID=sa;Password=123456";
        using var connection = new SqlConnection(sqlStringConnection);

        connection.Open();
        Console.WriteLine(connection.State);
        //truy van

        using DbCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT TOP (5) * FROM SANPHAM";
        var datareader = command.ExecuteReader();
        while (datareader.Read())
        {
            Console.WriteLine($"Ten San Pham: {datareader["TenSanPham"]} - Gia: {datareader["Gia"]}");
        }

        connection.Close();
    }
}