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
        private NewCategory redact;
        private MapAddress1 test_mark;
        private MapMarker locateProb;

        public NewIzmerenie()
        {
            InitializeComponent();
            updateComBoxTYPE();
            updateComBoxCATEGORY();
        }

        private void updateComBoxTYPE()
        {
            SqlConnection sqlConnection1 = new SqlConnection(Data.value);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Название FROM type";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    comboBox1.Items.Add((string)reader.GetValue(0));
                }

            sqlConnection1.Close();
        }

        private void updateComBoxCATEGORY()
        {
            SqlConnection sqlConnection1 = new SqlConnection(Data.value);
            SqlCommand cmd2 = new SqlCommand();

            cmd2.CommandText = "SELECT Название FROM Category";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = sqlConnection1;

            sqlConnection1.Open();

            using (var reader = cmd2.ExecuteReader())
                while (reader.Read())
                {
                    comboBox.Items.Add((string)reader.GetValue(0));
                }

            sqlConnection1.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        { 
                       
            if(textBox10.Text != "")
            {   
                if(textBox8.Text != "" && textBox9.Text != "")
                {
                    int idAddress = -1;
                    int type = 0, categ = 0;
                    try
                    {
                        SqlConnection con = new SqlConnection(Data.value);
                        con.Open();

                        //Получаю id типа воды
                        try
                        {
                            string queryType = "SELECT * FROM type WHERE Название='" + comboBox1.SelectedItem.ToString() + "'";
                            SqlCommand comm = new SqlCommand(queryType, con);
                            using (var read = comm.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    type = (int)read.GetValue(0);
                                }
                            }
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Введите тип воды");
                            con.Close();
                            return;
                        }

                        //Получаю id Адреса
                        string queryAddressId = "SELECT id_Address FROM Addres WHERE Широта = '" + textBox8.Text + "' AND Долгота = '" + textBox9.Text+"'";
                        SqlCommand comm2 = new SqlCommand(queryAddressId, con);
                        try
                        {
                            using (var read = comm2.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    idAddress += (int)read.GetValue(0);
                                }
                            }
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Не получил id запрос");
                            con.Close();
                            return;
                        }                       
                        
                        //Если запрос ничего не вернул заношу в таблицу координаты
                        if (idAddress == -1)
                        {
                            string queryAddress = "INSERT INTO Addres (Широта, Долгота) VALUES (@latitude, @longitude)";
                            SqlCommand comm = new SqlCommand(queryAddress, con);
                            comm.Parameters.AddWithValue("@latitude", textBox8.Text);
                            comm.Parameters.AddWithValue("@longitude", textBox9.Text);
                            comm.ExecuteNonQuery();
                        }
                        //Повторно отправляю запрос и получаю id Адреса
                        try
                        {
                            using (var read = comm2.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    idAddress = (int)read.GetValue(0);
                                }
                            }
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Не получил id адреса после занесения новых координат");
                            con.Close();
                            return;
                        }                      

                       
                        //Получаю id категории воды
                        try
                        {
                            string queryCateg = "SELECT id_categ FROM Category WHERE Название='" + comboBox.SelectedItem.ToString() + "'";
                            SqlCommand comm = new SqlCommand(queryCateg, con);
                            using (var read = comm.ExecuteReader())
                            {
                                while (read.Read())
                                {
                                    categ = (int)read.GetValue(0);
                                }
                            }
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Введите категорию воды");
                            con.Close();
                            return;
                        }
                        if (categ == 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Ничего не получилось категория не вернулась");
                            con.Close();
                            return;
                        }
                        if (type == 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Ничего не получилось тип не вернулся");
                            con.Close();
                            return;
                        }
                        string query = "INSERT INTO Prob_water (Название, Дата_забора, Консервация, Объем, id_Address, id_type, id_categ) VALUES(@Name, @Date, @Conserv, @V, @Address, @type, @categ)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Name", textBox10.Text);
                        cmd.Parameters.AddWithValue("@Date", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Conserv", comboBox2.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@V", textBox.ToString());
                        cmd.Parameters.AddWithValue("@Address", idAddress);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@categ", categ);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.ToString(), ex);
                    }                   
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Не введены координаты");
                }                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Не введено имя пробы");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            redact = new NewCategory(1);
            redact.ShowDialog();
            comboBox.Items.Clear();
            updateComBoxCATEGORY();
        }

        private void button_Click1(object sender, RoutedEventArgs e)
        {
            redact = new NewCategory(0);
            redact.ShowDialog();
            comboBox1.Items.Clear();
            updateComBoxTYPE();
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
