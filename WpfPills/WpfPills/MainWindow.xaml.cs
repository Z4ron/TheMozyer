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
    public partial class MainWindow : Window
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

        public MainWindow()
        {
            InitializeComponent();
            SetStartPosition();
           // GetMeds();

            updaterP = new DispatcherTimer();
            updaterP.Interval = TimeSpan.FromSeconds(5);
            updaterP.Tick += RandomPressure;
            updaterP.Start();

            updaterH = new DispatcherTimer();
            updaterH.Interval = TimeSpan.FromSeconds(5);
            updaterH.Tick += RandomHeart;
            updaterH.Start();

            callEmergency = new DispatcherTimer();
            callEmergency.Interval = TimeSpan.FromSeconds(5);
            callEmergency.Tick += Check_Count;
            callEmergency.Start();

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
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Alper\Desktop\TheMozyer-master\WpfPills\WpfPills\Database1.mdf;Integrated Security=True;Integrated Security=True");
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

        // Check upcoming medications and dispaly them if they are within 15 mins of scheduled time
        private void CheckMeds(object sender, EventArgs e)
        {
            for(int i = 0; i < dates.Count; i++)
            {
                if(Math.Abs((dates[i] - DateTime.Now).TotalMinutes) < 15)
                {
                    Notifications.Text = med[i] + " " + doses[i] + " Doses at " + dates[i].ToLongTimeString();

                }
            }
        }
        
        
        public void PageHandler(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch(button.Name)
            {
                case "Vitals": // Vitals page
                    new VitalsWindow().Show();
                    callEmergency.Stop();
                    break;
                case "Settings": // Settings page
                    new OptionsWindow().Show();
                    callEmergency.Stop();
                    break;
                case "Medication": // Medications page
                    new MedicineWindow().Show();
                    callEmergency.Stop();
                    break;


                case "Emergency":
                    new EmergencyWindow().Show();
                    break;

            }
            this.Close();

        }

        
        // Create random numbers for blood pressure, will be used for presentation
        private void RandomPressure(object sender, EventArgs e)
        {
            Random dia = new Random(DateTime.Now.Millisecond);
            Random sys = new Random(DateTime.Now.Millisecond);

            int d = dia.Next(50, 100);
            int s = sys.Next(90, 150);

            if(d < 80)
            {
                Diastolic.Foreground = new SolidColorBrush(Colors.Green);
                Diastolic.Text = d.ToString();
            }
            else
            {
                Diastolic.Foreground = new SolidColorBrush(Colors.Red);
                Diastolic.Text = d.ToString();
            }

            if(s < 120)
            {
                Systolic.Foreground = new SolidColorBrush(Colors.Green);
                Systolic.Text = s.ToString();
            }
            else
            {
                Systolic.Foreground = new SolidColorBrush(Colors.Red);
                Systolic.Text = s.ToString();
            }

        }
        
        // Create random heart bpm amounts, will be used for presentation
        private void RandomHeart(object sender, EventArgs e)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int r = rand.Next(70, 140);
            if (r < 80)
            {
                HeartRate.Foreground = new SolidColorBrush(Colors.Red);
                HeartRate.Text = r.ToString();
                count--;
            }
            else if (r > 130)
            {
                HeartRate.Foreground = new SolidColorBrush(Colors.Red);
                HeartRate.Text = r.ToString();
                count--;
            }
            else
            {
                HeartRate.Foreground = new SolidColorBrush(Colors.Green);
                HeartRate.Text = r.ToString();
                if (count < 2)
                {
                    count++;
                }
            }
        }

        // Stop threads
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            updaterP.Stop();
            updaterH.Stop();
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
