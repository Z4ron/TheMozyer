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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace TheMozyer
{
    public class Pill
    {
        public String name;
        public String doses;
        public List<String> days = new List<string>();
        public List<String> hours = new List<string>();
        public DateTime from;
        public DateTime to;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Pills : Window
    {
        string dbLoc = Environment.CurrentDirectory + "\\PillsData.json";
        JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
        List<Pill> pillsData = new List<Pill>();

        public Pills()
        {
            InitializeComponent();
    
            AddHours();
            AddMinutes();
            PopulatePillsData();
            PopulateMedicationListBox();
        }

        // Initialization functions
        private void AddHours()
        {
            List<int> hourList = new List<int>();
            for(int i = 1; i < 13; i++)
            {
                hourList.Add(i);
            }
            hours.ItemsSource = hourList;
        }
        private void AddMinutes()
        {
            List<string> minList = new List<string>();
            minList.Add("00");
            for (int i = 1; i < 6; i++)
            {
                minList.Add((i * 10).ToString());
            }
            minutes.ItemsSource = minList;
        }

        private void PopulatePillsData()
        {
            string json = System.IO.File.ReadAllText(dbLoc);
            this.pillsData = jsonSerialiser.Deserialize<List<Pill>>(json);
        }

        private void PopulateMedicationListBox()
        {
            foreach (Pill pill in pillsData)
            {
                MedicationList.Items.Add(pill.name);
            }
        }

        // Buttons
        private void Add_Hour(object sender, RoutedEventArgs e)
        {
            int h;
            int.TryParse(hours.SelectedValue.ToString(), out h);
            int m;
            int.TryParse(minutes.SelectedValue.ToString(), out m);
            times.Items.Add(hours.SelectedValue.ToString() + ":" + minutes.SelectedValue.ToString() + " " + apm.SelectedValue.ToString().Split(' ')[1]);
        }

        private void Add_Medication(object sender, RoutedEventArgs e)
        {
            // Add Pill
            Pill newPill = new Pill();
            newPill.name = name.Text;
            newPill.doses = Doses.Text;
            newPill.days = getDays();
            newPill.hours = getHours();
            newPill.from = (DateTime)from.SelectedDate;
            newPill.to = (DateTime)to.SelectedDate;

            // Add Pill to database
            pillsData.Add(newPill);

            // Save database to file
            string json = jsonSerialiser.Serialize(pillsData);

            System.IO.File.WriteAllText(dbLoc, json);

            MedicationList.Items.Add(name.Text);
            MedicationList.SelectedIndex = MedicationList.Items.Count - 1;
            MessageBox.Show("Medication is added to the list");

        }

        private void Remove_Medication(object sender, RoutedEventArgs e)
        {
            try
            {
                pillsData.Remove(pillsData[MedicationList.SelectedIndex]);
                MedicationList.Items.Remove(MedicationList.Items[MedicationList.SelectedIndex]);
                // Save database to file
                string json = jsonSerialiser.Serialize(pillsData);

                System.IO.File.WriteAllText(dbLoc, json);
            }
               

            catch (Exception ex)
            {
                MessageBox.Show("No medication Selected");
            }


        }

        private void Home_Button(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        // Methods for getting data from form controls
        private List<String> getDays()
        {
            List<String> days = new List<string>();

            if (SundayBox.IsChecked.Value) { days.Add("Sunday"); }
            if (MondayBox.IsChecked.Value) { days.Add("Monday"); }
            if (TuesdayBox.IsChecked.Value) { days.Add("Tuesday"); }
            if (WednesdayBox.IsChecked.Value) { days.Add("Wednesday"); }
            if (ThursdayBox.IsChecked.Value) { days.Add("Thursday"); }
            if (FridayBox.IsChecked.Value) { days.Add("Friday"); }
            if (SaturdayBox.IsChecked.Value) { days.Add("Saturday"); }

            return days;
        }

        private List<String> getHours()
        {
            List<String> hours = new List<string>();

            foreach (var item in times.Items)
            {
                hours.Add(item.ToString());
            }

            return hours;
        }

        // Form Control Methods
        private void MedicationList_SelectionChanged(object sender, SelectionChangedEventArgs e) // populates the form when you select a medication
        {
            if (MedicationList.SelectedItem != null)
            {
                // Top fields
                name.Text = pillsData[MedicationList.SelectedIndex].name;
                Doses.Text = pillsData[MedicationList.SelectedIndex].doses;

                from.SelectedDate = pillsData[MedicationList.SelectedIndex].from;
                to.SelectedDate = pillsData[MedicationList.SelectedIndex].to;

                // Check/Uncheck appropriate boxes
                if (pillsData[MedicationList.SelectedIndex].days.Contains("Sunday")) { SundayBox.IsChecked = true; } else { SundayBox.IsChecked = false; };
                if (pillsData[MedicationList.SelectedIndex].days.Contains("Monday")) { MondayBox.IsChecked = true; } else { MondayBox.IsChecked = false; };
                if (pillsData[MedicationList.SelectedIndex].days.Contains("Tuesday")) { TuesdayBox.IsChecked = true; } else { TuesdayBox.IsChecked = false; };
                if (pillsData[MedicationList.SelectedIndex].days.Contains("Wednesday")) { WednesdayBox.IsChecked = true; } else { WednesdayBox.IsChecked = false; };
                if (pillsData[MedicationList.SelectedIndex].days.Contains("Thursday")) { ThursdayBox.IsChecked = true; } else { ThursdayBox.IsChecked = false; };
                if (pillsData[MedicationList.SelectedIndex].days.Contains("Friday")) { FridayBox.IsChecked = true; } else { FridayBox.IsChecked = false; };
                if (pillsData[MedicationList.SelectedIndex].days.Contains("Saturday")) { SaturdayBox.IsChecked = true; } else { SaturdayBox.IsChecked = false; };

                // Fill in appropriate times
                times.Items.Clear(); // clear currently displayed times so we don't stack them onto the new list
                foreach (String hour in pillsData[MedicationList.SelectedIndex].hours)
                {
                    times.Items.Add(hour);
                }
            }
            // Clear the form if an element was removed
            else
            {
                name.Text = "";
                Doses.Text = "";
                from.SelectedDate = null;
                to.SelectedDate = null;

                SundayBox.IsChecked = false;
                MondayBox.IsChecked = false;
                TuesdayBox.IsChecked = false;
                WednesdayBox.IsChecked = false;
                ThursdayBox.IsChecked = false;
                FridayBox.IsChecked = false;
                SaturdayBox.IsChecked = false;

                times.Items.Clear();

                hours.SelectedValue = null;
                minutes.SelectedValue = null;
                apm.SelectedValue = null;
            }
        }

    }
}
