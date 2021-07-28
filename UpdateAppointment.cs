using System;
using System.Windows.Forms;
using System.Data;

namespace Scheduling_Software
{
    /// <summary>
    /// Code behind for the UpdateAppointment Form
    /// </summary>
    public partial class UpdateAppointment : Form
    {
        #region Global Variable
        DataTable appointmentTable;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UpdateAppointment()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Initializes select form components on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAppointment_Load(object sender, EventArgs e)
        {
           // Initializes date pickers
           startDateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
           startDateTimePicker1.ShowUpDown = true;
           endDateTimePicker2.CustomFormat = "HH:mm";
           endDateTimePicker2.ShowUpDown = true;
           // Runs SQL query and populates datagrid
           appointmentTable = DBHelper.AvailableAppointments();
            // Converts from UTC to local time
            for (int idx = 0; idx < appointmentTable.Rows.Count; idx++)
            {
                appointmentTable.Rows[idx]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)appointmentTable.Rows[idx]["start"], TimeZoneInfo.Local).ToString();
                appointmentTable.Rows[idx]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)appointmentTable.Rows[idx]["end"], TimeZoneInfo.Local).ToString();
            }
            // Binds table to data grid
            customerDataGridView1.DataSource = appointmentTable;
        }
        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Passes user entered data to data layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Informs user that all fields haven't been filled
            if (!EntryValidation())
            {
                MessageBox.Show("The required fields have not been filled.");
            }
            // Passes input validation
            else
            {
                // Stores appointment start and end times
                DateTime dateTimeToStart = startDateTimePicker1.Value.Date + startDateTimePicker1.Value.TimeOfDay;
                DateTime dateTimeToEnd = startDateTimePicker1.Value.Date + endDateTimePicker2.Value.TimeOfDay;
                // Stores regular business hours 
                TimeSpan businessStart = TimeSpan.Parse("08:00");
                TimeSpan businessEnd = TimeSpan.Parse("17:00");
                // Validates and checks for overlap with existing appointments
                if (EntryValidation() && DateOverlapCheck(dateTimeToStart, dateTimeToEnd, businessStart, businessEnd))
                {
                    // Passes values to data layer
                    DBHelper.UpdateAppointment(Convert.ToInt32(appointmentIDTextBox1.Text), Convert.ToInt32(customerIDTextBox1.Text), customerNameTextBox1.Text, titleTextBox1.Text, descriptionTextBox1.Text, locationTextBox1.Text, contactTextBox1.Text, typeTextBox1.Text, urlTextBox1.Text, dateTimeToStart, dateTimeToEnd);
                    // Closes the forms
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Fills in the Customer ID field on row select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            populateID();
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Checks to ensure user entered data is valid
        /// </summary>
        /// <returns></returns>
        private bool EntryValidation()
        {
            // Determines if any fields are empty
            if (String.IsNullOrEmpty(appointmentIDTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(titleTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(descriptionTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(locationTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(contactTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(typeTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(urlTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(startDateTimePicker1.Checked.ToString()) ||
                String.IsNullOrEmpty(endDateTimePicker2.Checked.ToString()) ||
                String.IsNullOrEmpty(customerIDTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(customerNameTextBox1.Text.ToString()))
            {
                return false;
            }
            // If no fields are empty
            else
            {
                // Tests to see if ID can be parsed to integer
                try
                {
                    int testAppointmentID = Convert.ToInt32(appointmentIDTextBox1.Text);
                    int testCustomerID = Convert.ToInt32(customerIDTextBox1.Text);
                    return true;
                }
                // Informs user if ID cannot be parsed
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid a ID for the appointment.");
                    return false;
                }
            }
        }
        /// <summary>
        /// Checks to see if selected appointment times overlap with regular business hours and other appointments
        /// </summary>
        /// <param name="dateTimeToStart"></param>
        /// <param name="dateTimeToEnd"></param>
        /// <param name="businessStart"></param>
        /// <param name="businessEnd"></param>
        /// <returns></returns>
        private bool DateOverlapCheck(DateTime dateTimeToStart, DateTime dateTimeToEnd, TimeSpan businessStart, TimeSpan businessEnd)
        {
            // Determines if the seleted times are within business hours
            if ((dateTimeToStart.TimeOfDay > businessStart) && (dateTimeToStart.TimeOfDay < businessEnd) && (dateTimeToEnd.TimeOfDay < businessEnd))
            {
                // Checks if there is overlap with existing appointments
                if (DBHelper.CheckCalender(dateTimeToStart, dateTimeToEnd, Convert.ToInt32(appointmentIDTextBox1.Text)))
                {
                    return true;
                }
                // Informs user that the selected times interfere with an existing appointment
                else
                {
                MessageBox.Show("Appointment date and/or time overlap with a previously scheduled appointment.");
                return false;
                }
            }
            // Informs user that the selected times occur outside of business hours
            else
            {
               MessageBox.Show("Appointment date and/or time is outside of regular business hours");
               return false;
            }
        }
        /// <summary>
        /// Fills in the Appointment ID field on row select
        /// </summary>
        private void populateID()
        {
            // Executes if a row is selected
            if (customerDataGridView1.SelectedRows.Count != 0)
            {
                appointmentIDTextBox1.Text = customerDataGridView1.CurrentRow.Cells["appointmentId"].Value.ToString();
                titleTextBox1.Text = customerDataGridView1.CurrentRow.Cells["title"].Value.ToString();
                descriptionTextBox1.Text = customerDataGridView1.CurrentRow.Cells["description"].Value.ToString();
                locationTextBox1.Text = customerDataGridView1.CurrentRow.Cells["location"].Value.ToString();
                typeTextBox1.Text = customerDataGridView1.CurrentRow.Cells["type"].Value.ToString();
                urlTextBox1.Text = customerDataGridView1.CurrentRow.Cells["url"].Value.ToString();
                contactTextBox1.Text = customerDataGridView1.CurrentRow.Cells["contact"].Value.ToString();
                customerIDTextBox1.Text = customerDataGridView1.CurrentRow.Cells["customerId"].Value.ToString();
                customerNameTextBox1.Text = customerDataGridView1.CurrentRow.Cells["customerName"].Value.ToString();
                startDateTimePicker1.Value = Convert.ToDateTime(customerDataGridView1.CurrentRow.Cells["start"].Value.ToString());
                endDateTimePicker2.Value = Convert.ToDateTime(customerDataGridView1.CurrentRow.Cells["end"].Value.ToString());
            }
        }
        #endregion
    }
}
