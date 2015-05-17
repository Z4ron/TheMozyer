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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();


        }

        void timer_Tick(object sender, EventArgs e)
        {
                time.Text = DateTime.Now.ToLongTimeString();
                date.Text = DateTime.Now.ToLongDateString();
        }

        private void ButtonClickHandler(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch(button.Name)
            {
              /*
               * Just type in the constructors for the pages 
               * For example the code to create and display the main page is
               * 
               * new MainWindow().Show();
               * 
                case "Vitals": // Vitals page
              
                    break;
                case "Settings": // Settings page
                    
                    break;
                case "Medications": // Medications page
                    
                    break;
               * 
               */

                case "Emergency":
                    
                    break;

            }

        }
    }
}
