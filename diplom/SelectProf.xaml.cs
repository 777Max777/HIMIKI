﻿using System;
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
    /// Логика взаимодействия для SelectProf.xaml
    /// </summary>
    public partial class SelectProf : Window
    {
        private NewIzmerenie Izmerenie;
        public SelectProf()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Izmerenie = new NewIzmerenie();
            Izmerenie.ShowDialog();
        }
    }
}
