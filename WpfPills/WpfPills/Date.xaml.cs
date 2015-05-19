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

namespace TheMozyer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Date : Window
    {
        public Date()
        {
            InitializeComponent();
            SetStartPosition();
        }

        private void Home_Button(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            new OptionsWindow().Show();
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
