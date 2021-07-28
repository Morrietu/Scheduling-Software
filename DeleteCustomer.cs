using System;
using System.Windows.Forms;
using System.Data;

namespace Scheduling_Software
{
    /// <summary>
    /// Code behind for the DeleteCustomer Form
    /// </summary>
    public partial class DeleteCustomer : Form
    {
        #region Global Variable
        // Holds customer data
        DataTable customerTable = new DataTable();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DeleteCustomer()
        {
            InitializeComponent();
        }
        #endregion region

        #region Event Handlers
        /// <summary>
        /// Actions to perform on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCustomer_Load(object sender, EventArgs e)
        {
            // Populates table with customers
            customerTable = DBHelper.CustomerTable();
            // Binds table to data grid
            customerDataGridView1.DataSource = customerTable;
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
        /// Validates and passes user entries to data layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Informs user if fields aren't valid
            if (!CustomerEntryValidation())
            {
                MessageBox.Show("The required fields have not been filled.");
            }
            // Clears user entry if ID isn't valid
            else if (!CustomerIDValidation())
            {
                customerIDTextBox1.Clear();
            }
            // If input is valid
            else
            {
                // Passes user entry and returns true/false
                var success = DBHelper.DeleteCustomer(Convert.ToInt32(customerIDTextBox1.Text));
                // Closes form if true
                if (success)
                {
                    this.Close();
                }
                // Clears form if false
                else
                {
                    customerIDTextBox1.Clear();
                }
            }
        }
        #endregion

        #region Helper Classes
        /// <summary>
        /// Validates user input upon submission
        /// </summary>
        /// <returns></returns>
        private bool CustomerEntryValidation()
        {
            // Condition set to return if any of the required fields are left empty
            if (String.IsNullOrEmpty(customerIDTextBox1.Text.ToString()))
            {
                return false;
            }
            // If no fields emptry, then true
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Tests to seee if entered ID can be parsed to an integer
        /// </summary>
        /// <returns></returns>
        private bool CustomerIDValidation()
        {
            // True if parse if successful
            try
            {
                int testCustomerID = Convert.ToInt32(customerIDTextBox1.Text);
                return true;
            }
            // False and informs user if entry is invalid
            catch (Exception)
            {
                MessageBox.Show("Please make sure ID input is valid.");
                return false;
            }
        }
        #endregion
    }
}

