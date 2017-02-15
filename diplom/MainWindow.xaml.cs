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
        private NewIzmerenie NewIz;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void updateTable(string str, DataGrid myDataGrid)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection conn = new SqlConnection(Data.value))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(str, conn))
                    {
                        da.Fill(dt);
                    }
                }
                myDataGrid.ItemsSource = dt.DefaultView;
                myDataGrid.AutoGenerateColumns = true;
                myDataGrid.CanUserAddRows = false;
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
            //updateTable();
            

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

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = "новая группа(проба)";            
            Tree_Categories.Items.Add(item);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Tree_Categories.Items.Remove(Tree_Categories.SelectedItem);
        }



        //переименовываем группу или пробу
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ((TreeViewItem)(Tree_Categories.SelectedItem)).Header = textBox.Text;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            NewIz = new NewIzmerenie();
            NewIz.ShowDialog();
        }
    }
}
