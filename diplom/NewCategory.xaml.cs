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
using System.Linq;

namespace diplom
{
    /// <summary>
    /// Логика взаимодействия для NewCategory.xaml
    /// </summary>
    public partial class NewCategory : Window
    {
        private int talk;
        public NewCategory(int flag)
        {
            InitializeComponent();
            talk = flag;
            MyLinqDataContext dbContex = new MyLinqDataContext();
            if (flag == 0)
            {   
               var reader = (from type in dbContex.type select type.Название).ToArray();
               foreach(var curr in reader)
                {
                    comboBox.Items.Add(curr);
                    comboBox1.Items.Add(curr);
                }
                /*SqlConnection sqlConnection1 = new SqlConnection(Data.value);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT Название FROM type";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        comboBox.Items.Add((string)reader.GetValue(0));
                        comboBox1.Items.Add((string)reader.GetValue(0));
                    }
                sqlConnection1.Close();*/
            }
            if (flag == 1)
            {
                /*SqlConnection sqlConnection1 = new SqlConnection(Data.value);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT Название FROM Category";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        comboBox.Items.Add((string)reader.GetValue(0));
                        comboBox1.Items.Add((string)reader.GetValue(0));
                    }
                sqlConnection1.Close();*/

                var reader = (from Category in dbContex.type select Category.Название).ToArray();
                foreach (var curr in reader)
                {
                    comboBox.Items.Add(curr);
                    comboBox1.Items.Add(curr);
                }
            }
        }
      

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Нужно задать имя");
                return;
            }
            SqlConnection con = new SqlConnection(Data.value);
            if (talk == 0)
            {               
                string query = "INSERT INTO type (Название) VALUES(@Name)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                /*SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM type", con);
                int count = 1;
                using (var reader = cmd2.ExecuteReader())
                    while (reader.Read())
                    {
                        count += (int)reader.GetValue(0);
                    }*/
                //cmd.Parameters.AddWithValue("@ID", count);
                cmd.Parameters.AddWithValue("@Name", textBox.Text);
                cmd.ExecuteNonQuery();
                con.Close();                
            }
            if(talk == 1)
            {
                string query = "INSERT INTO Category (Название) VALUES(@Name)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", textBox.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            comboBox.Items.Add(textBox.Text);
            comboBox1.Items.Add(textBox.Text);
            textBox.Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string name;
            try
            {
               name = comboBox.SelectedItem.ToString();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Нужно указать что удалить хочешь");
                return;
            }
            SqlConnection con = new SqlConnection(Data.value);            
            string query = "";
            if (talk == 0)
            {
                query = "DELETE FROM type WHERE Название = '" + name + "'";               
            }
            if(talk == 1)
            {
                query = "DELETE FROM Category WHERE Название = '" + name + "'";                
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            comboBox.Items.Remove(name);
            comboBox1.Items.Remove(name);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string name;
            try
            {
                name = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Нужно выбрать необходимый параметр");
                return;
            }
            if (textBox_Copy.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Нужно задать необходимые параметры");
                return;
            }

            SqlConnection con = new SqlConnection(Data.value);                        
            string query = "";
            if (talk == 0)
            {
                query = "UPDATE type SET Название = '" + name + "' WHERE Название = '" + textBox_Copy.Text + "'";
            }
            if (talk == 1)
            {
                query = "UPDATE Category SET Название = '" + name + "' WHERE Название = '" + textBox_Copy.Text + "'";
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            comboBox.Items.Remove(name);
            comboBox1.Items.Remove(name);
            comboBox.Items.Add(textBox_Copy.Text);
            comboBox1.Items.Add(textBox_Copy.Text);
            textBox_Copy.Clear();
        }
    }
}
