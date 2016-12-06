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
using System.Web;
using System.IO;


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
        //private CreateProf CreateProfil = new CreateProf();
        private Com ComPort;
        private CreateProf Prof;
        private Login logwin;
        private SelectProf SelectProf;
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

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateProf_Click1(object sender, RoutedEventArgs e)
        {
            Prof = new CreateProf();
            Prof.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SelectProf = new SelectProf();
            SelectProf.ShowDialog();
        }

       

        private void SelectCom_Click_2(object sender, RoutedEventArgs e)
        {
            ComPort = new Com();
            ComPort.ShowDialog();
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            try
            {
                this.web.Navigate(new Uri(String.Format("file:///{0}/test.html", curDir)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
