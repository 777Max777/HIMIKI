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


namespace diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    static class Data
    {
        public static string value { get; set; }        
    }
    

    public partial class MainWindow : Window
    {
        
        private Login logwin; 
        public MainWindow()
        {
            InitializeComponent();
        }

        public void updateTable()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection conn = new SqlConnection(Data.value))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Type_water ORDER BY id_type ASC", conn))
                    {
                        da.Fill(dt);
                    }
                }
                dataGrid.ItemsSource = dt.DefaultView;
                dataGrid.AutoGenerateColumns = true;
                dataGrid.CanUserAddRows = false;
            }
        }

        public void Tree_Categories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            logwin = new Login();
            logwin.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            updateTable();
        }
    }
}
