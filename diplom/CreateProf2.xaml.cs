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
    /// Логика взаимодействия для CreateProf2.xaml
    /// </summary>
    public partial class CreateProf2 : Window
    {
        public int a;
        public CreateProf2()
        {
            InitializeComponent();
        }


        private void CreateProf2_load(object sender, RoutedEventArgs e)
        {

            // CreateProf frm3 = new CreateProf();
            a = CreateProf.age;

            for (int i = 0; i < a; i++)
            {
                
                    ComboBox ComboBox = new ComboBox();
                ComboBox.Margin = new Thickness(0,2,0, 2);
                ComboBox.Name = "combobox" + i;
                PanelBox.Children.Add(ComboBox);


                Label label= new Label();
                label.Margin = new Thickness(40, 0, 0, 0); 
                label.Content = "Сенсор № " + i ;
                PanelLabel.Children.Add(label);

            }

               
           }

      }
}


        
