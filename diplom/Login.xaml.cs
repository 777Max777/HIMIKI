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
using System.Data.SqlClient;


namespace diplom
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>   

    public partial class Login : Window
    {
        public SqlConnection conn;

        public Login()
        {
            InitializeComponent();
            textBox.Text = "LIHOTIN";
            textBox1.Text = "ENose";
            textBox2.Text = "test";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (conn = new System.Data.SqlClient.SqlConnection("Server=" + textBox.Text + ";Database=" + textBox1.Text + ";uid=" + textBox2.Text + ";pwd=" + textBox3.Text + ""))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Соединено");
                    Data.value = "Server=" + textBox.Text + ";Database=" + textBox1.Text + ";uid=" + textBox2.Text + ";pwd=" + textBox3.Text + "";
                    this.Close();
                }
                catch(Exception help)
                {
                    MessageBox.Show(help.Message);
                }
            }
        }
    }
}
