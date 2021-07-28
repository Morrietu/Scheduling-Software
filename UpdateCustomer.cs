using System;
using System.Windows.Forms;
using System.Data;

namespace Scheduling_Software
{
    /// <summary>
    /// Code behind for the UpdateCustomer Form
    /// </summary>
    public partial class UpdateCustomer : Form
    {
        #region Global Variable
        // Holds customer data
        DataTable customerTable = new DataTable();
        #endregion

        #region Constructor
        // Contructor
        public UpdateCustomer()
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
        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            // Populates table with customers
            customerTable = DBHelper.CustomerTable();
            // Binds table to data grid
            customerDataGridView1.DataSource = customerTable;
            // Populates the text fields
            PopulateBoxes();
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
        /// Validates and passes user input to data layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Stores city selection
            var cityId = 0;
            // Inform user if data entry is invalid
            if (!EntryValidation())
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
                // Passes user entires to data layer
                DBHelper.UpdateCustomer(Convert.ToInt32(customerIDTextBox1.Text), nameBox1.Text, Convert.ToInt32(addressIDTextBox1.Text), addressBox1.Text, addressBox2.Text, phoneBox1.Text, activityCheckBox1.Checked, postalBox1.Text, cityId);
                // Closes form
                this.Close();
            }
        }
        /// <summary>
        /// Actions to perform when a cell is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateBoxes();
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
                if (String.IsNullOrEmpty(customerIDTextBox1.Text.ToString()) ||
                     String.IsNullOrEmpty(nameBox1.Text.ToString()) ||
                     String.IsNullOrEmpty(addressIDTextBox1.Text.ToString()) ||
                     String.IsNullOrEmpty(addressBox1.Text.ToString()) ||
                     String.IsNullOrEmpty(postalBox1.Text.ToString()) ||
                     String.IsNullOrEmpty(phoneBox1.Text.ToString())
                    )
                {
                // If a field is empty
                return false;
                }
                // If all fields contain a value
                else
                {
                    // Tests to see if the ID fields can successfully be parsed from string
                    try
                    {
                        int testCustomerID = Convert.ToInt32(customerIDTextBox1.Text);
                        int testedaddressID = Convert.ToInt32(addressIDTextBox1.Text);
                        // True if valid
                        return true;
                    }
                    // informs user if valid integer hasn't been entered
                    catch (Exception)
                    {
                        MessageBox.Show("Please enter valid IDs for the customer and customer address.");
                        return false;
                    }
                }
            }
        /// <summary>
        /// Populates text boxes based on table selection
        /// </summary>
        private void PopulateBoxes()
        {
            // Executes if a row is selected
            if (customerDataGridView1.SelectedRows.Count != 0)
            {
                // Stores cell values in corresponding text boxes
                customerIDTextBox1.Text = customerDataGridView1.CurrentRow.Cells["customerId"].Value.ToString();
                nameBox1.Text = customerDataGridView1.CurrentRow.Cells["customerName"].Value.ToString();
                addressBox1.Text = customerDataGridView1.CurrentRow.Cells["address"].Value.ToString();
                addressBox2.Text = customerDataGridView1.CurrentRow.Cells["address2"].Value.ToString();
                addressIDTextBox1.Text = customerDataGridView1.CurrentRow.Cells["addressId"].Value.ToString();
                postalBox1.Text = customerDataGridView1.CurrentRow.Cells["postalCode"].Value.ToString();
                phoneBox1.Text = customerDataGridView1.CurrentRow.Cells["phone"].Value.ToString();
                // Stores activity status
                string isChecked = customerDataGridView1.CurrentRow.Cells["active"].Value.ToString();
                // Checks activity box depending on booean value
                if (isChecked == "True")
                {
                    activityCheckBox1.Checked = true;
                }
                else
                {
                    activityCheckBox1.Checked = false;
                }
                // Stores cit ID
                string cityId = customerDataGridView1.CurrentRow.Cells["cityId"].Value.ToString();
                // Selects corresponding ID from list
                cityListBox1.SetSelected(Int32.Parse(cityId) - 1, true);
            }
        }
        #endregion
    }
}

