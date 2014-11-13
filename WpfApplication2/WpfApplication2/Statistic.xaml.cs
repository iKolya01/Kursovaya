﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : Window
    {
        public Statistic()
        {
            InitializeComponent();

            string path = AppDomain.CurrentDomain.BaseDirectory + "statistic.html";
            browser.Navigate(new Uri(path));
        }
    }
}
