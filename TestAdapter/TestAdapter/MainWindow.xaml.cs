using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestAdapter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable("NhanVien");
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet dataSet = new DataSet();
        public MainWindow()
        {
            InitAdapter();
            InitializeComponent();
        }
        void InitAdapter()
        {
            string sqlStringConnection = "Data Source=DESKTOP-9L14R4S\\SQLEXPRESS;Initial Catalog=xtlab;Persist Security Info=True;User ID=sa;Password=123456";
            connection = new SqlConnection(sqlStringConnection);

            connection.Open();

            adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "NhanVien");
            //SelectCommand
            adapter.SelectCommand = new SqlCommand("Select NhanViennID, Ten, Ho from NhanVien", connection);

            //InsertCommand
            adapter.InsertCommand = new SqlCommand("Insert into NhanVien (Ho, Ten) values (@Ho, @Ten)", connection);
            adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");
      

            //DeleteCommand
            adapter.DeleteCommand = new SqlCommand("Delete from NhanVien where NhanViennID = @NhanViennID", connection);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NhanViennID", SqlDbType.Int));
            pr1.SourceColumn = "NhanViennID";
            pr1.SourceVersion = DataRowVersion.Original;

            //UpdateCommand
            adapter.UpdateCommand = new SqlCommand("Update NhanVien Set Ho = @Ho, Ten = @Ten where NhanviennID = @NhanViennID", connection);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NhanViennID", SqlDbType.Int));
            pr2.SourceColumn = "NhanViennID";
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.UpdateCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");

            dataSet.Tables.Add(table);
        }

        void LoadataTable()
        {
            table.Rows.Clear();
            adapter.Fill(dataSet);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadataTable();
            datagrid.DataContext = table.DefaultView;

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadataTable();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            adapter.Update(dataSet);
            table.Rows.Clear();
            adapter.Fill(dataSet);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selecteditem = (DataRowView)datagrid.SelectedItem;
            if(selecteditem !=null)
            {
                selecteditem.Delete();
            }
        }
    }
}
