using System.Data;
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

        using var command = new SqlCommand();
        command.Connection = connection;
        // command.CommandText = "Select DanhmucID, TenDanhMuc, Mota From Danhmuc Where DanhmucID >= @DanhmucID ";

        // var danhmucid = command.Parameters.AddWithValue("@DanhmucID", 3);

        // // command.EndExecuteReader();
        // using var sqlreader = command.ExecuteReader(); //dung khi ket qua tra ve co nhieu dong

        // var datatable = new DataTable();

        // datatable.Load(sqlreader);

        // if (sqlreader.HasRows) //kiem cho xem co dong nao tra ve hay k
        // {
        //     while (sqlreader.Read())
        //     {
        //         var id = sqlreader.GetInt32(0);
        //         var ten = sqlreader["TenDanhMuc"];
        //         var mota = sqlreader["Mota"];
        //         Console.WriteLine($"{id} - {ten} - {mota}");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("K co du lieu");
        // }

        // command.ExecuteScalar(); - tra ve 1 gia tri (dong 1, cot 1)


        // command.ExecuteNonQuery(); -tra ve so dong bi tac dong nhu dung cau lenh Insert, Update, Delete 

        //StoredProcedure

        command.CommandText = "getproductinfo";
        command.CommandType = CommandType.StoredProcedure; //bắt buộc có để biết là storedprocedure

        var id = new SqlParameter("@id", 0);
        command.Parameters.Add(id);
        id.Value = 8;

        var reader = command.ExecuteReader();
        if(reader.HasRows){
            reader.Read();
            var tensp = reader["TenSanPham"];
            var tendanhmuc = reader["TenDanhMuc"];
            var nhacungcap = reader["tendaydu"];
            Console.WriteLine($"{tensp} - {tendanhmuc} - {nhacungcap}");
        }


        connection.Close();
    }
}