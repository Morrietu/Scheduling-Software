using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduling_Software
{
    /// <summary>
    /// Code behind for the Main form
    /// </summary>
    public partial class Main : Form
    {
        #region Global variables
        // Stores appointment data
        DataTable appointmentTable = new DataTable();
        // Stores today's date
        DateTime currentDate;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Initializes on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            // Sets the date/time
            currentDate = DateTime.Now;
            // Formats the calender
            monthCalendar1.AddBoldedDate(currentDate);
            // Starts with radio button pre-selected
            weekRadioButton1.Checked = true;
            // Call to dispaly appointments by week
            handleWeek();
            // Populates data table
            dataGridView1.DataSource = appointmentTable;
            // Checks if any appointments are within 15 minutes
            appointmentReminder(dataGridView1);
        }
        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Displays the add customer form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            // Hides main form
            this.Hide();
            //creates add customer form object and displays it
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.ShowDialog();
            // Shows main form upon sub-form closure
            this.Show();
        }
        /// <summary>
        /// Displays the update customer form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            // Hides main form
            this.Hide();
            //creates update customer form object and displays it
            UpdateCustomer updateCustomer = new UpdateCustomer();
            updateCustomer.ShowDialog();
            // Shows main form upon sub-form closure
            this.Show();
        }
        /// <summary>
        /// Displays the remove customer form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeCustomerButton_Click(object sender, EventArgs e)
        {
            // Hides main form
            this.Hide();
            //creates remove customer form object and displays it
            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.ShowDialog();
            // Shows main form upon sub-form closure
            this.Show();
        }
        /// <summary>
        /// Displays the add appointment form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            // Hides main form
            this.Hide();
            //creates add appointment form object and displays it
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.ShowDialog();
            // Shows main form upon sub-form closure
            this.Show();
            // Refreshes appointment table
            UpdateTable();
        }
        /// <summary>
        /// Displays the update appointment form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            // Hides main form
            this.Hide();
            //creates update appointment form object and displays it
            UpdateAppointment updateAppointment = new UpdateAppointment();
            updateAppointment.ShowDialog();
            // Shows main form upon sub-form closure
            this.Show();
            // Refreshes appointment table
            UpdateTable();
        }
        /// <summary>
        /// Displays the remove appointment form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeAppointmentButton_Click(object sender, EventArgs e)
        {
            // Hides main form
            this.Hide();
            //creates delete appointment form object and displays it
            DeleteAppointment deleteAppointment = new DeleteAppointment();
            deleteAppointment.ShowDialog();
            // Shows main form upon sub-form closure
            this.Show();
            // Refreshes appointment table
            UpdateTable();
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Loads all appointments within the month into the data table
        /// </summary>
        private void handleMonth()
        {
            // Clears calender formatting
            monthCalendar1.RemoveAllBoldedDates();
            appointmentTable.Clear();
            // Stores date information
            var month = currentDate.Month;
            var year = currentDate.Year;
            var day = 0;
            // Formats date into variable
            string startDate = month.ToString() + "/01/" + year.ToString();
            DateTime tempDate = Convert.ToDateTime(startDate);
            // Formats months with appropriate number of days
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                    day = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    day = 30;
                    break;
                default:
                    day = 29;
                    break;
            }
            // Adds formatting to calender
            for (int i = 0; i < day; i++)
            {
                monthCalendar1.AddBoldedDate(tempDate.AddDays(i));
            }
            monthCalendar1.UpdateBoldedDates();
            // Formats end date and stores into variable
            string endDate = year.ToString() + "/" + month.ToString() + "/" + day.ToString() + "/" + currentDate.TimeOfDay.ToString();
            // Call to run SQL query for appointments
            GetTableData($"SELECT * FROM appointment WHERE start BETWEEN'{startDate}' AND '{endDate}';");
            // Populates data table 
            dataGridView1.DataSource = appointmentTable;
        }
        /// <summary>
        /// Loads all appointments within the week into the data table
        /// </summary>
        private void handleWeek()
        {
            // Clears calender formatting
            monthCalendar1.RemoveAllBoldedDates();
            appointmentTable.Clear();
            // Counter for day of the week
            int dow = (int)currentDate.DayOfWeek;
            // Formats and stores date information
            string sqlFormattedDateStart = currentDate.AddDays(-dow).ToString("yyyy-MM-dd HH:mm:ss.fff");
            DateTime tempDate = Convert.ToDateTime(sqlFormattedDateStart);
            // Formats calender for the week
            for (int i = 0; i < 7; i++)
            {
                monthCalendar1.AddBoldedDate(tempDate.AddDays(i));
            }
            monthCalendar1.UpdateBoldedDates();
            // Formats end date and stores into variable
            string sqlFormattedDateEnd = currentDate.AddDays(7 - dow).ToString("yyyy-MM-dd HH:mm:ss.fff");
            // Call to run SQL query for appoinments
            GetTableData($"SELECT * FROM appointment WHERE start BETWEEN '{sqlFormattedDateStart}' AND '{sqlFormattedDateEnd}';");
            // Populates the data table
            dataGridView1.DataSource = appointmentTable;
        }
        /// <summary>
        /// Populates calender for the week
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weekRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            handleWeek();
        }
        /// <summary>
        /// Populates calender for the month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            handleMonth();
        }
        /// <summary>
        /// Populates data table with appointments
        /// </summary>
        /// <param name="s"></param>
        public void GetTableData(string s)
        {
            // Opens connection to the database
            DBHelper.ConnectionString().Open();
            // Retrieves query results
            MySqlDataAdapter adapter = new MySqlDataAdapter(s, DBHelper.ConnectionString());
            // Fills data table with results
            adapter.Fill(appointmentTable);
            // Convert UTC to local time
            for (int idx = 0; idx < appointmentTable.Rows.Count; idx++)
            {
                appointmentTable.Rows[idx]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)appointmentTable.Rows[idx]["start"], TimeZoneInfo.Local).ToString();
                appointmentTable.Rows[idx]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)appointmentTable.Rows[idx]["end"], TimeZoneInfo.Local).ToString();
            }
            // Closes connection to the database
            DBHelper.ConnectionString().Close();
        }
        /// <summary>
        /// Notifies user if an appointment is within 15 minutes
        /// </summary>
        /// <param name="appointmentCalendar"></param>
        public void appointmentReminder(DataGridView appointmentCalendar)
        {
            // Iteraters over rows
            foreach (DataGridViewRow row in appointmentCalendar.Rows)
            {
                // Saves space by using a lamba within a delegate function to determine the difference between start and current is less then 15
                Func<DateTime, DateTime, TimeSpan> timeCheck = (start , now) => start - now;
                // Calls and stores results from delegate function
                TimeSpan timeSpan = timeCheck(DateTime.Parse(row.Cells[9].Value.ToString()).ToUniversalTime(), DateTime.UtcNow);
                // Executes if time difference is less than 15 but also a postive value
                if (timeSpan.TotalMinutes <= 15 && timeSpan.TotalMinutes > -1)
                {
                    // Query for customer name
                    string nameQuery = $"SELECT customerName FROM customer WHERE customerId='{row.Cells[1].Value.ToString()}';";
                    // Passes query to data layer and stores result
                    string customer = DBHelper.ReminderQuery(nameQuery);
                    // Notifies user with customer name and appointment date/time information
                    MessageBox.Show($"You have a meeting with {customer} at {row.Cells[9].Value.ToString()}");
                }
            }
        }
        /// <summary>
        /// Displays the Reports form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportsButton1_Click(object sender, EventArgs e)
        {
            // Hides main form
            this.Hide();
            //creates reports form object and displays it
            Reports reportForm = new Reports();
            reportForm.ShowDialog();
            // Shows main form upon sub-form closure
            this.Show();
        }
        /// <summary>
        /// Refreshed data table for either week or month
        /// </summary>
        private void UpdateTable()
        {
            // Determines if week button is selected, refreshes week view if so
            if (weekRadioButton1.Checked == true)
            {
                handleWeek();
            }
            // Refreshes month view otherwise
            else
            {
                handleMonth();
            }
        }
        #endregion
    }
}
