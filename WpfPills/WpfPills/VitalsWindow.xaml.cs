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
using System.Data.Sql;
using System.Data.SqlClient;

namespace TheMozyer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VitalsWindow : Window
    {
        private int count = 2;
        private DispatcherTimer callEmergency;
        private DispatcherTimer updaterP;
        private DispatcherTimer updaterH;
        private DispatcherTimer check;
        private DispatcherTimer timer;


        List<DateTime> dates;
        List<string> med;
        List<string> doses;

        public VitalsWindow()
        {
            InitializeComponent();
            SetStartPosition();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        // If critical condition continues for 10 seconds then automatically call emergency
        void Check_Count(object sender, EventArgs e)
        {
            if(count == 0)
            {
                new EmergencyWindow().Show();
                this.Close();
                callEmergency.Stop();
            }
        }
        // Clock
        void timer_Tick(object sender, EventArgs e)
        {
                time.Text = DateTime.Now.ToLongTimeString();
                date.Text = DateTime.Now.ToLongDateString();
        }

        // Get medications in database
        private void GetMeds()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ben\Source\Backup\WpfPills\WpfPills\Database1.mdf;Integrated Security=True");
            connect.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM pills", connect);
            SqlDataReader read = command.ExecuteReader();
            dates = new List<DateTime>();
            med = new List<string>();
            doses = new List<string>();
            while(read.Read())
            {
                DateTime t = Convert.ToDateTime(read[2].ToString());
               
                if((t.Day == DateTime.Now.Day && t.Month == DateTime.Now.Month))
                {
                    dates.Add(t);
                    med.Add(read[0].ToString());
                    doses.Add(read[1].ToString());
                }
                
            }

            read.Close();
            connect.Close();
            
            
        }


        public void PageHandler(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "Vitals": // Vitals page
                    new VitalsWindow().Show();
                    break;
                case "Settings": // Settings page
                    new OptionsWindow().Show();
                    break;
                case "Medication": // Medications page
                    new MedicineWindow().Show();
                    break;
                case "Emergency":
                    new EmergencyWindow().Show();
                    break;

            }
            this.Close();

        }

        // Stop threads
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            updaterP.Stop();
            updaterH.Stop();
            check.Stop();
            callEmergency.Stop();
            timer.Stop();
        }

        // For starting the window in a consistent position
        private void SetStartPosition()
        {
            this.Left = 100;
            this.Top = 100;
        }
    }
}
