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

namespace diplom
{
    /// <summary>
    /// Логика взаимодействия для SelectProf.xaml
    /// </summary>
    public partial class SelectProf : Window
    {
        private NewIzmerenie Izmerenie;

        public SelectProf()
        {
            InitializeComponent();
            SqlConnection sqlConnection1 = new SqlConnection(Data.value);
            SqlCommand cmd = new SqlCommand();            

            cmd.CommandText = "SELECT Название FROM Profile";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            using (var reader = cmd.ExecuteReader())                
                    while (reader.Read())
                    {
                        comboBox.Items.Add((string)reader.GetValue(0));
                    }
            sqlConnection1.Close();
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            Izmerenie = new NewIzmerenie();
            Izmerenie.ShowDialog();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string profile = comboBox.SelectedItem.ToString();
            string query = "SELECT Название, Аббревиатура FROM Sensor WHERE id_sensor IN (SELECT id_sensor FROM Sensor_Profile WHERE id_Prof = (SELECT id_Prof FROM Profile WHERE Название = '"+profile+"'))";
            //string query = "SELECT id_Prof FROM Profile WHERE [Название] = 'test_one'";
            using (SqlConnection conn = new SqlConnection(Data.value))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Сенсоры в профиле");
                sda.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }            
        }
    }
}
