using System;
using System.Collections.Generic;
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
using System.IO;
using System.Web;


namespace testBrowse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //root is a grid element identified in the XAML
      


        public MainWindow()
        {
            InitializeComponent();
            
        }

             
        private void webb_Loaded(object sender, RoutedEventArgs e)
        {

            string curDir = Directory.GetCurrentDirectory();
            try
            {
                this.webb.Navigate(new Uri(String.Format("file:///{0}/test.html", curDir)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Search_data_Click(object sender, RoutedEventArgs e)
        {
            /*string street = txt_Street.Text;
            string city = txt_City.Text;
            string state = txt_State.Text;
            string zip = txt_Zip.Text;

            try
            {
                StringBuilder queryaddres = new StringBuilder();
                queryaddres.Append("http://maps.google.com/maps?q=");   
                if(street != string.Empty)
                {
                    queryaddres.Append(street + "," + "+");
                }
                if (city != string.Empty)
                {
                    queryaddres.Append(city + "," + "+");
                }
                if (state != string.Empty)
                {
                    queryaddres.Append(state + "," + "+");
                }
                if (zip != string.Empty)
                {
                    queryaddres.Append(zip + "," + "+");
                }
                webb.Navigate(queryaddres.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }*/
        }
    }
}
