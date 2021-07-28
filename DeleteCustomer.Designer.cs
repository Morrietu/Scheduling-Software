namespace Scheduling_Software
{
    partial class DeleteCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customerIDTextBox1 = new System.Windows.Forms.TextBox();
            this.customerIDLabel1 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.updateCustomerLabel = new System.Windows.Forms.Label();
            this.customerDataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customerIDTextBox1
            // 
            this.customerIDTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIDTextBox1.Location = new System.Drawing.Point(118, 239);
            this.customerIDTextBox1.Name = "customerIDTextBox1";
            this.customerIDTextBox1.Size = new System.Drawing.Size(124, 26);
            this.customerIDTextBox1.TabIndex = 58;
            // 
            // customerIDLabel1
            // 
            this.customerIDLabel1.AutoSize = true;
            this.customerIDLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIDLabel1.Location = new System.Drawing.Point(13, 242);
            this.customerIDLabel1.Name = "customerIDLabel1";
            this.customerIDLabel1.Size = new System.Drawing.Size(99, 20);
            this.customerIDLabel1.TabIndex = 57;
            this.customerIDLabel1.Text = "CustomerID:";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(360, 236);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(101, 35);
            this.Cancel.TabIndex = 54;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(467, 236);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(101, 35);
            this.submitButton.TabIndex = 53;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // updateCustomerLabel
            // 
            this.updateCustomerLabel.AutoSize = true;
            this.updateCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateCustomerLabel.Location = new System.Drawing.Point(12, 19);
            this.updateCustomerLabel.Name = "updateCustomerLabel";
            this.updateCustomerLabel.Size = new System.Drawing.Size(178, 25);
            this.updateCustomerLabel.TabIndex = 42;
            this.updateCustomerLabel.Text = "Delete Customer:";
            // 
            // customerDataGridView1
            // 
            this.customerDataGridView1.AllowUserToAddRows = false;
            this.customerDataGridView1.AllowUserToDeleteRows = false;
            this.customerDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customerDataGridView1.Location = new System.Drawing.Point(17, 63);
            this.customerDataGridView1.Name = "customerDataGridView1";
            this.customerDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGridView1.Size = new System.Drawing.Size(552, 150);
            this.customerDataGridView1.TabIndex = 59;
            // 
            // DeleteCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 284);
            this.Controls.Add(this.customerDataGridView1);
            this.Controls.Add(this.customerIDTextBox1);
            this.Controls.Add(this.customerIDLabel1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.updateCustomerLabel);
            this.Name = "DeleteCustomer";
            this.Text = "DeleteCustomer";
            this.Load += new System.EventHandler(this.DeleteCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox customerIDTextBox1;
        private System.Windows.Forms.Label customerIDLabel1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label updateCustomerLabel;
        private System.Windows.Forms.DataGridView customerDataGridView1;
    }
}