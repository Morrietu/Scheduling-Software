using System;
using System.Windows.Forms;
using System.Data;

namespace Scheduling_Software
{
    /// <summary>
    /// Code behind for the AddAppointment Form
    /// </summary>
    public partial class AddAppointment : Form
    {
        #region Global Variable
        DataTable customerTable;
        int dummyID = -1;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AddAppointment()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Initializes select form elements on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAppointment_Load(object sender, EventArgs e)
        {
            // Initializes date pickers
            startDateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            startDateTimePicker1.ShowUpDown = true;
            endDateTimePicker2.CustomFormat = "HH:mm";
            endDateTimePicker2.ShowUpDown = true;
            // Runs SQL query and populates datagrid
            customerTable = DBHelper.AvailableCustomers();
            customerDataGridView1.DataSource = customerTable;
        }
        /// <summary>
        /// Passes user entered values to data layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Informs user if fields haven't been filled
            if (!EntryValidation())
            {
                MessageBox.Show("The required fields have not been filled.");
            }
            // If all fields are valid
            else
            {
                // Stores appointment start and end times
                DateTime dateTimeToStart = startDateTimePicker1.Value.Date + startDateTimePicker1.Value.TimeOfDay;
                DateTime dateTimeToEnd = startDateTimePicker1.Value.Date + endDateTimePicker2.Value.TimeOfDay;
                // Stores business hours
                TimeSpan businessStart = TimeSpan.Parse("08:00");
                TimeSpan businessEnd = TimeSpan.Parse("17:00");
                // Validates and makes sure appointment times don't overlap with existing ones
                if (EntryValidation() && DateOverlapCheck(dateTimeToStart, dateTimeToEnd, businessStart, businessEnd))
                {
                    // Passes field information to data layer
                    DBHelper.AddAppointment(Convert.ToInt32(customerIDTextBox1.Text), titleTextBox1.Text, descriptionTextBox1.Text, locationTextBox1.Text, contactTextBox1.Text, typeTextBox1.Text, urlTextBox1.Text, dateTimeToStart, dateTimeToEnd);
                    // Closes form
                    this.Close();
                }
            }
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
        /// Actions to perform when a cell is selected
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
        /// Tests user entered data
        /// </summary>
        /// <returns></returns>
        private bool EntryValidation()  
        {
            // Tests to see if all fields have a value
            if (String.IsNullOrEmpty(customerIDTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(titleTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(descriptionTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(locationTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(contactTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(typeTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(urlTextBox1.Text.ToString()) ||
                String.IsNullOrEmpty(startDateTimePicker1.Checked.ToString()) ||
                String.IsNullOrEmpty(endDateTimePicker2.Checked.ToString()))
            {
                // Returns if they do not
                return false;
            }
            // If all fields have values
            else
            {
                // Tests to see if the ID field can be parsed to integer
                try
                {
                    int testCustomerID = Convert.ToInt32(customerIDTextBox1.Text);
                    
                    return true;
                }
                // If value cannot be parse, informs user and returns false
                catch (Exception)
                {
                    MessageBox.Show("Please enter valid a ID for the customer.");
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
                if (DBHelper.CheckCalender(dateTimeToStart, dateTimeToEnd, dummyID))
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
        /// Fills in the Customer ID field on row select
        /// </summary>
        private void populateID()
        {
            // Executes if a row is selected
            if (customerDataGridView1.SelectedRows.Count != 0)
            {
                customerIDTextBox1.Text = customerDataGridView1.CurrentRow.Cells["customerId"].Value.ToString();
                customerNameTextBox1.Text = customerDataGridView1.CurrentRow.Cells["customerName"].Value.ToString();
            }
        }
        #endregion
    }
}
