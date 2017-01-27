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
using System.Web;
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
        //private WebBrowser web;
        private GeoIzmer Geo;
        private NewCategory redact;
        private MapAddress1 test_mark;
        private MapMarker locateProb;

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
            textBox8.Clear();
            textBox9.Clear();
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Проверьте введены ли все поля в адресе");
                return;
            }
            string str1 = textBox3.Text + ',' + textBox4.Text + ',' + textBox5.Text + ',' + textBox6.Text + ',' + textBox7.Text;
            str1 = GET("https://geocode-maps.yandex.ru/1.x", str1);
            int startIndex = str1.IndexOf("<Point ");
            int endIndex = str1.IndexOf("</Point>");
            int length = endIndex - startIndex + 1;
            string s = str1.Substring(startIndex, length);
            startIndex = s.IndexOf("<pos>");
            endIndex = s.LastIndexOf("</pos>");
            length = endIndex - startIndex + 1;
            string str2 = s.Substring(startIndex, length);
            startIndex = str2.IndexOf(">") + 1;
            endIndex = str2.LastIndexOf("<") - 1;
            length = endIndex - startIndex + 1;
            string str3 = str2.Substring(startIndex, length);
            startIndex = str3.IndexOf(" ");
            string longitude = str3.Substring(0, startIndex);
            length = str3.Length - startIndex - 1;
            string latitude = str3.Substring(startIndex+1, length);

            textBox8.Text = longitude;
            textBox9.Text = latitude;
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

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            test_mark = new MapAddress1(textBox8.Text, textBox9.Text);
            test_mark.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            textBox8.Clear();
            textBox9.Clear();
            locateProb = new MapMarker();
            locateProb.ShowDialog();
            textBox8.Text = locateProb.Lat;
            textBox9.Text = locateProb.Lng;
        }
    }
}
