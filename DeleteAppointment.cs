using System;
using System.Windows.Forms;

namespace Scheduling_Software
{
    /// <summary>
    /// Code behind for the DeleteAppointment Form
    /// </summary>
    public partial class DeleteAppointment : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DeleteAppointment()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Actions to perform on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAppointment_Load(object sender, EventArgs e)
        {
            this.appointmentTableAdapter.Fill(this.u06IIcDataSet.appointment);

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
        /// Passes user value to the data layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Informs user if all fields haven't been filled
            if (!EntryValidation())
            {
                MessageBox.Show("The appointment has not been entered.");
            }
            // Clears entry if ID isn't valid
            else if (!IDValidation())
            {
                appointmentIDTextBox1.Clear();
            }
            // IF ID has been entered and exists
            else
            {
                // Passes value to data layer and returns true/false
                var success = DBHelper.DeleteAppointment(Convert.ToInt32(appointmentIDTextBox1.Text));
                // If true, Form closes
                if (success)
                {
                    this.Close();
                }
                // If false, clears entry
                else
                {
                    appointmentIDTextBox1.Clear();
                }
            }
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Validates user entry
        /// </summary>
        /// <returns></returns>
        private bool EntryValidation()
        {
            // Determines if field is empty
            if (String.IsNullOrEmpty(appointmentIDTextBox1.Text.ToString()))
            {
                return false;
            }
            // Fields have values
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Checks to make sure entered value is a valid ID
        /// </summary>
        /// <returns></returns>
        private bool IDValidation()
        {
            // Tests to see if value can be parsed to integer
            try
            {
                int testCustomerID = Convert.ToInt32(appointmentIDTextBox1.Text);

                return true;
            }
            // If value cannot be parsed, informs user
            catch (Exception)
            {
                MessageBox.Show("Please enter valid a ID for the appointment.");
                return false;
            }
        }
        #endregion
    }
}
