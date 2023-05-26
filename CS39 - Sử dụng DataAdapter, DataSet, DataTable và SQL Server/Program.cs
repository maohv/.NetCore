using System.Data;
using System.Data.SqlClient;

internal class Program
{
    static void ShowDataTable(DataTable table)
    {
        Console.WriteLine($"Ten Bang {table.TableName}");

        Console.Write($"{"Index",15}");
        foreach (DataColumn c in table.Columns)
        {

            Console.Write($"{c.ColumnName,15}");
        }

        Console.WriteLine();

        int number_columns = table.Columns.Count;

        int index = 0;

        foreach (DataRow d in table.Rows)
        {
            Console.Write($"{index,15}");
            for (int i = 0; i < number_columns; i++)
            {
                Console.Write($"{d[i],15}");
            }
            // Console.Write($"{d[0],20}");
            // Console.Write($"{d["HoTen"],20}");
            // Console.Write($"{d["Tuoi"],20}");
            Console.WriteLine();
            index++;

        }
    }
    static void Main(string[] args)
    {
        string sqlStringConnection = "Data Source=DESKTOP-9L14R4S\\SQLEXPRESS;Initial Catalog=xtlab;Persist Security Info=True;User ID=sa;Password=123456";
        using var connection = new SqlConnection(sqlStringConnection);

        connection.Open();

        //var dataset = new DataSet();

        // var table = new DataTable("MyTable");
        // dataset.Tables.Add(table);
        // table.Columns.Add("STT");
        // table.Columns.Add("HoTen");
        // table.Columns.Add("Tuoi");
        // table.Rows.Add(1, "Hoang Mao", 24);
        // table.Rows.Add(1, "Hoang Mao 1", 23);
        // table.Rows.Add(1, "Hoang Mao 2", 26);
        // ShowDataTable(table);

        var adapter = new SqlDataAdapter();
        adapter.TableMappings.Add("Table", "NhanVien");
        //SelectCommand
        adapter.SelectCommand = new SqlCommand("Select NhanViennID, Ten, Ho from NhanVien", connection);

        //InsertCommand
        adapter.InsertCommand = new SqlCommand("Insert into NhanVien (Ho, Ten) values (@Ho, @Ten)", connection);
        adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
        adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");

        //DeleteCommand
        adapter.DeleteCommand = new SqlCommand("Delete from NhanVien where @NhanViennID = @NhanViennID", connection);
        var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NhanViennID", SqlDbType.Int));
        pr1.SourceColumn = "NhanViennID";
        pr1.SourceVersion = DataRowVersion.Original;


        var dataset = new DataSet();
        adapter.Fill(dataset); //do du lieu vao dataset

        DataTable table = dataset.Tables["NhanVien"];
        ShowDataTable(table);

        // var row = table.Rows.Add();
        // row["Ten"] = "Abc";
        // row["Ho"] = "Nguyen Van";


        //cap nhap

        // var row10 = table.Rows[10];
        // row10.Delete();

        adapter.Update(dataset);

        connection.Close();
    }
}