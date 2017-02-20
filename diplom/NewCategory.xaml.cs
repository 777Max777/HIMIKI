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
        private MyLinqDataContext dbContex;
        public NewCategory(int flag)
        {
            InitializeComponent();
            talk = flag;
            dbContex = new MyLinqDataContext();
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

                var reader = (from Category in dbContex.Category select Category.Название).ToArray();
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
            //SqlConnection con = new SqlConnection(Data.value);
            if (talk == 0)
            {
                type item = new type
                {
                    Название = textBox.Text
                };
                dbContex.type.InsertOnSubmit(item);
                try
                {
                    dbContex.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                /*string query = "INSERT INTO type (Название) VALUES(@Name)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                /*SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM type", con);
                int count = 1;
                using (var reader = cmd2.ExecuteReader())
                    while (reader.Read())
                    {
                        count += (int)reader.GetValue(0);
                    }*/
                /*cmd.Parameters.AddWithValue("@ID", count);
                cmd.Parameters.AddWithValue("@Name", textBox.Text);
                cmd.ExecuteNonQuery();
                con.Close(); */

            }
            if(talk == 1)
            {
                Category categ = new Category
                {
                    Название = textBox.Text
                };
                dbContex.Category.InsertOnSubmit(categ);
                // Submit the change to the database.
                try
                {
                    dbContex.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                /*string query = "INSERT INTO Category (Название) VALUES(@Name)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", textBox.Text);
                cmd.ExecuteNonQuery();
                con.Close();*/
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
            /**SqlConnection con = new SqlConnection(Data.value);            
            string query = "";*/
            if (talk == 0)
            {
                var deleteitems = from type in dbContex.type where type.Название == name select type;
                foreach (var items in deleteitems)
                {
                    dbContex.type.DeleteOnSubmit(items);
                }
                try
                {
                    dbContex.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //query = "DELETE FROM type WHERE Название = '" + name + "'";               
            }
            if(talk == 1)
            {
                var deleteitems = from Category in dbContex.Category where Category.Название == name select Category;
                foreach (var items in deleteitems)
                {
                    dbContex.Category.DeleteOnSubmit(items);
                }
                try
                {
                    dbContex.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //query = "DELETE FROM Category WHERE Название = '" + name + "'";                
            }
            /*con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();*/

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

            /*SqlConnection con = new SqlConnection(Data.value);                        
            string query = "";*/
            if (talk == 0)
            {
                var UpdateItem = from type in dbContex.type where type.Название == name select type;
                foreach (type item in UpdateItem)
                {
                    item.Название = textBox_Copy.Text;
                }
                try
                {
                    dbContex.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //query = "UPDATE type SET Название = '" + name + "' WHERE Название = '" + textBox_Copy.Text + "'";
            }
            if (talk == 1)
            {
                var UpdateItem = from Category in dbContex.Category where Category.Название == name select Category;
                foreach (Category item in UpdateItem)
                {
                    item.Название = textBox_Copy.Text;
                }
                try
                {
                    dbContex.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //query = "UPDATE Category SET Название = '" + name + "' WHERE Название = '" + textBox_Copy.Text + "'";
            }
            /*con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();*/

            comboBox.Items.Remove(name);
            comboBox1.Items.Remove(name);
            comboBox.Items.Add(textBox_Copy.Text);
            comboBox1.Items.Add(textBox_Copy.Text);
            textBox_Copy.Clear();
        }
    }
}
