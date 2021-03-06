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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheMozyer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            SetStartPosition();
        }

        private void Home_Button(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Pills_Button(object sender, RoutedEventArgs e)
        {
            new Pills().Show();
            this.Close();
        }

        private void Date_Button(object sender, RoutedEventArgs e)
        {
            new Date().Show();
            this.Close();
        }

        private void Vitals_Button(object sender, RoutedEventArgs e)
        {
            new VitalsOptions().Show();
            this.Close();
        }

        // For starting the window in a consistent position
        private void SetStartPosition()
        {
            this.Left = 100;
            this.Top = 100;
        }


    }
}
