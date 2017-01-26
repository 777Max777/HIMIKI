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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Navigation;

namespace diplom
{
    /// <summary>
    /// Логика взаимодействия для NewIzmerenie.xaml
    /// </summary>
    public partial class NewIzmerenie : Window
    {
        private WebBrowser myweb;
        private GeoIzmer Geo;
        private NewCategory redact;
        public NewIzmerenie()
        {
            InitializeComponent();
            SqlConnection sqlConnection1 = new SqlConnection(Data.value);
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();

            cmd.CommandText = "SELECT Название FROM type";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            cmd2.CommandText = "SELECT Название FROM Category";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = sqlConnection1;

            sqlConnection1.Open();

            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    comboBox1.Items.Add((string)reader.GetValue(0));
                }

            using (var reader = cmd2.ExecuteReader())
                while (reader.Read())
                {
                    comboBox.Items.Add((string)reader.GetValue(0));
                }
            sqlConnection1.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Geo = new GeoIzmer();
            Geo.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            redact = new NewCategory(1);
            redact.ShowDialog();
        }

        private void button_Click1(object sender, RoutedEventArgs e)
        {
            redact = new NewCategory(0);
            redact.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(GET("https://geocode-maps.yandex.ru/1.x", "Воронеж, московский проспект, 179"));
        }

        private static string GET(string Url, string Data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url + "?geocode=" + Data);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

    }
}
