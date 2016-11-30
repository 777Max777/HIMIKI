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

namespace diplom
{ 
    /// <summary>
    /// Логика взаимодействия для CreateProf.xaml
    /// </summary>
    public partial class CreateProf : Window
    {
        public static int age;
        public int ChisloSensorov;
        private CreateProf2 Prof2;
        public CreateProf()
        {
            InitializeComponent();
        }

        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ((textBox.Text !="") && (textBox1.Text != "")) { 
            age = Convert.ToInt32(textBox1.Text);
                Prof2 = new CreateProf2();
                Prof2.ShowDialog();
            this.Close();
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }

        private void Ввод_кол_дачиков(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
