using System;
using System.Windows.Forms;
using System.Data;

namespace Scheduling_Software
{
    /// <summary>
    /// Cod behind for the AddCustomer Form
    /// </summary>
    public partial class AddCustomer : Form
    {
        #region Global Variable
        // Holds customer data
        DataTable customerTable = new DataTable();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AddCustomer()
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
        private void AddCustomer_Load(object sender, EventArgs e)
        {
            // Populates table with customers
            customerTable = DBHelper.CustomerTable();
            // Binds table to data grid
            customerDataGridView1.DataSource = customerTable;
        }
        /// <summary>
        /// Closes the AddCustomer form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Submits user information to data layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Stores city selection
            var cityId = 0; 
            // Informs user if there is invalid entries
            if(!EntryValidation())
            {
                MessageBox.Show("The required fields have not been filled.");
            }
            // Parses city selection
            else
            {
                switch (cityListBox1.FindString(cityListBox1.SelectedItem.ToString()))
                {
                    case 0:
                        cityId = 1;
                        break;
                    case 1:
                        cityId = 2;
                        break;
                    case 2:
                        cityId = 3;
                        break;
                    case 3:
                        cityId = 4;
                        break;
                    case 4:
                        cityId = 5;
                        break;
                    case 5:
                        cityId = 6;
                        break;
                    case 6:
                        cityId = 7;
                        break;
                    case 7:
                        cityId = 8;
                        break;
                }
                // Passes user entered data to add to database
                DBHelper.AddCustomer(nameBox1.Text, cityId, phoneBox1.Text, addressBox1.Text, addressBox2.Text, activityCheckBox1.Checked, postalBox1.Text);
                // Closes form
                this.Close();
            }
        }
        #endregion

        #region Helper Classes
        /// <summary>
        /// Validates user input upon submission
        /// </summary>
        /// <returns></returns>
        private bool EntryValidation()
        {
            // Condition set to return if any of the required fields are left empty
            if (String.IsNullOrEmpty(nameBox1.Text.ToString()) ||
                 String.IsNullOrEmpty(addressBox1.Text.ToString()) ||
                 String.IsNullOrEmpty(postalBox1.Text.ToString()) ||
                 String.IsNullOrEmpty(phoneBox1.Text.ToString())
                )
            {
                // If an entry is invalid
                return false;
            }
            // If all entries are valid
            else
            {
                return true;
            }
        }
        #endregion
    }
}
