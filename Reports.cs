using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_Software
{
    /// <summary>
    /// Code behind for the Reports Form
    /// </summary>
    public partial class Reports : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Reports()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Passes report type value to datya layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void appointmentRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DBHelper.Report("appointment");
        }
        /// <summary>
        /// Passes report type value to datya layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultantRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DBHelper.Report("consultant");
        }
        /// <summary>
        /// Passes report type value to datya layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void infoRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DBHelper.Report("contact");
        }
        #endregion
    }
}
