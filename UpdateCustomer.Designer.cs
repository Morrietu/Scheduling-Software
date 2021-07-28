namespace Scheduling_Software
{
    partial class UpdateCustomer
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
            this.cityListBox1 = new System.Windows.Forms.ListBox();
            this.activityCheckBox1 = new System.Windows.Forms.CheckBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.phoneBox1 = new System.Windows.Forms.TextBox();
            this.postalBox1 = new System.Windows.Forms.TextBox();
            this.addressBox2 = new System.Windows.Forms.TextBox();
            this.addressBox1 = new System.Windows.Forms.TextBox();
            this.customerPhoneLabel = new System.Windows.Forms.Label();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.customerAddress2Label = new System.Windows.Forms.Label();
            this.customerAddressLabel = new System.Windows.Forms.Label();
            this.updateCustomerLabel = new System.Windows.Forms.Label();
            this.customerIDLabel1 = new System.Windows.Forms.Label();
            this.customerIDTextBox1 = new System.Windows.Forms.TextBox();
            this.addressIDTextBox1 = new System.Windows.Forms.TextBox();
            this.addressIDLabel1 = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.nameBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customerDataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cityListBox1
            // 
            this.cityListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityListBox1.FormattingEnabled = true;
            this.cityListBox1.ItemHeight = 20;
            this.cityListBox1.Items.AddRange(new object[] {
            "New York",
            "Los Angeles",
            "Toronto",
            "Vancouver",
            "Oslo",
            "Berlin",
            "Munich",
            "Frankfurt"});
            this.cityListBox1.Location = new System.Drawing.Point(400, 325);
            this.cityListBox1.Name = "cityListBox1";
            this.cityListBox1.Size = new System.Drawing.Size(124, 164);
            this.cityListBox1.TabIndex = 37;
            // 
            // activityCheckBox1
            // 
            this.activityCheckBox1.AutoSize = true;
            this.activityCheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityCheckBox1.Location = new System.Drawing.Point(53, 247);
            this.activityCheckBox1.Name = "activityCheckBox1";
            this.activityCheckBox1.Size = new System.Drawing.Size(71, 24);
            this.activityCheckBox1.TabIndex = 36;
            this.activityCheckBox1.Text = "Active";
            this.activityCheckBox1.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(356, 551);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(101, 35);
            this.Cancel.TabIndex = 35;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(463, 551);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(101, 35);
            this.submitButton.TabIndex = 34;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // phoneBox1
            // 
            this.phoneBox1.Location = new System.Drawing.Point(183, 530);
            this.phoneBox1.Name = "phoneBox1";
            this.phoneBox1.Size = new System.Drawing.Size(124, 20);
            this.phoneBox1.TabIndex = 33;
            // 
            // postalBox1
            // 
            this.postalBox1.Location = new System.Drawing.Point(183, 469);
            this.postalBox1.Name = "postalBox1";
            this.postalBox1.Size = new System.Drawing.Size(124, 20);
            this.postalBox1.TabIndex = 32;
            // 
            // addressBox2
            // 
            this.addressBox2.Location = new System.Drawing.Point(183, 402);
            this.addressBox2.Name = "addressBox2";
            this.addressBox2.Size = new System.Drawing.Size(124, 20);
            this.addressBox2.TabIndex = 31;
            // 
            // addressBox1
            // 
            this.addressBox1.Location = new System.Drawing.Point(183, 363);
            this.addressBox1.Name = "addressBox1";
            this.addressBox1.Size = new System.Drawing.Size(124, 20);
            this.addressBox1.TabIndex = 30;
            // 
            // customerPhoneLabel
            // 
            this.customerPhoneLabel.AutoSize = true;
            this.customerPhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerPhoneLabel.Location = new System.Drawing.Point(49, 530);
            this.customerPhoneLabel.Name = "customerPhoneLabel";
            this.customerPhoneLabel.Size = new System.Drawing.Size(119, 20);
            this.customerPhoneLabel.TabIndex = 28;
            this.customerPhoneLabel.Text = "Phone Number:";
            // 
            // postalCodeLabel
            // 
            this.postalCodeLabel.AutoSize = true;
            this.postalCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postalCodeLabel.Location = new System.Drawing.Point(49, 467);
            this.postalCodeLabel.Name = "postalCodeLabel";
            this.postalCodeLabel.Size = new System.Drawing.Size(99, 20);
            this.postalCodeLabel.TabIndex = 27;
            this.postalCodeLabel.Text = "Postal Code:";
            // 
            // customerAddress2Label
            // 
            this.customerAddress2Label.AutoSize = true;
            this.customerAddress2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerAddress2Label.Location = new System.Drawing.Point(49, 400);
            this.customerAddress2Label.Name = "customerAddress2Label";
            this.customerAddress2Label.Size = new System.Drawing.Size(85, 20);
            this.customerAddress2Label.TabIndex = 26;
            this.customerAddress2Label.Text = "Address 2:";
            // 
            // customerAddressLabel
            // 
            this.customerAddressLabel.AutoSize = true;
            this.customerAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerAddressLabel.Location = new System.Drawing.Point(52, 361);
            this.customerAddressLabel.Name = "customerAddressLabel";
            this.customerAddressLabel.Size = new System.Drawing.Size(72, 20);
            this.customerAddressLabel.TabIndex = 25;
            this.customerAddressLabel.Text = "Address:";
            // 
            // updateCustomerLabel
            // 
            this.updateCustomerLabel.AutoSize = true;
            this.updateCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateCustomerLabel.Location = new System.Drawing.Point(10, 10);
            this.updateCustomerLabel.Name = "updateCustomerLabel";
            this.updateCustomerLabel.Size = new System.Drawing.Size(185, 25);
            this.updateCustomerLabel.TabIndex = 23;
            this.updateCustomerLabel.Text = "Update Customer:";
            // 
            // customerIDLabel1
            // 
            this.customerIDLabel1.AutoSize = true;
            this.customerIDLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIDLabel1.Location = new System.Drawing.Point(49, 214);
            this.customerIDLabel1.Name = "customerIDLabel1";
            this.customerIDLabel1.Size = new System.Drawing.Size(103, 20);
            this.customerIDLabel1.TabIndex = 38;
            this.customerIDLabel1.Text = "Customer ID:";
            // 
            // customerIDTextBox1
            // 
            this.customerIDTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIDTextBox1.Location = new System.Drawing.Point(183, 214);
            this.customerIDTextBox1.Name = "customerIDTextBox1";
            this.customerIDTextBox1.Size = new System.Drawing.Size(124, 26);
            this.customerIDTextBox1.TabIndex = 39;
            // 
            // addressIDTextBox1
            // 
            this.addressIDTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressIDTextBox1.Location = new System.Drawing.Point(183, 325);
            this.addressIDTextBox1.Name = "addressIDTextBox1";
            this.addressIDTextBox1.Size = new System.Drawing.Size(124, 26);
            this.addressIDTextBox1.TabIndex = 41;
            // 
            // addressIDLabel1
            // 
            this.addressIDLabel1.AutoSize = true;
            this.addressIDLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressIDLabel1.Location = new System.Drawing.Point(49, 325);
            this.addressIDLabel1.Name = "addressIDLabel1";
            this.addressIDLabel1.Size = new System.Drawing.Size(93, 20);
            this.addressIDLabel1.TabIndex = 40;
            this.addressIDLabel1.Text = "Address ID:";
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNameLabel.Location = new System.Drawing.Point(49, 285);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(128, 20);
            this.customerNameLabel.TabIndex = 24;
            this.customerNameLabel.Text = "Customer Name:";
            // 
            // nameBox1
            // 
            this.nameBox1.Location = new System.Drawing.Point(183, 285);
            this.nameBox1.Name = "nameBox1";
            this.nameBox1.Size = new System.Drawing.Size(124, 20);
            this.nameBox1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(396, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Select City:";
            // 
            // customerDataGridView1
            // 
            this.customerDataGridView1.AllowUserToAddRows = false;
            this.customerDataGridView1.AllowUserToDeleteRows = false;
            this.customerDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customerDataGridView1.Location = new System.Drawing.Point(15, 47);
            this.customerDataGridView1.Name = "customerDataGridView1";
            this.customerDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGridView1.Size = new System.Drawing.Size(564, 150);
            this.customerDataGridView1.TabIndex = 43;
            this.customerDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerDataGridView1_CellContentClick);
            // 
            // UpdateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 600);
            this.Controls.Add(this.customerDataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressIDTextBox1);
            this.Controls.Add(this.addressIDLabel1);
            this.Controls.Add(this.customerIDTextBox1);
            this.Controls.Add(this.customerIDLabel1);
            this.Controls.Add(this.cityListBox1);
            this.Controls.Add(this.activityCheckBox1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.phoneBox1);
            this.Controls.Add(this.postalBox1);
            this.Controls.Add(this.addressBox2);
            this.Controls.Add(this.addressBox1);
            this.Controls.Add(this.nameBox1);
            this.Controls.Add(this.customerPhoneLabel);
            this.Controls.Add(this.postalCodeLabel);
            this.Controls.Add(this.customerAddress2Label);
            this.Controls.Add(this.customerAddressLabel);
            this.Controls.Add(this.customerNameLabel);
            this.Controls.Add(this.updateCustomerLabel);
            this.Name = "UpdateCustomer";
            this.Text = "UpdateCustomer";
            this.Load += new System.EventHandler(this.UpdateCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cityListBox1;
        private System.Windows.Forms.CheckBox activityCheckBox1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox phoneBox1;
        private System.Windows.Forms.TextBox postalBox1;
        private System.Windows.Forms.TextBox addressBox2;
        private System.Windows.Forms.TextBox addressBox1;
        private System.Windows.Forms.Label customerPhoneLabel;
        private System.Windows.Forms.Label postalCodeLabel;
        private System.Windows.Forms.Label customerAddress2Label;
        private System.Windows.Forms.Label customerAddressLabel;
        private System.Windows.Forms.Label updateCustomerLabel;
        private System.Windows.Forms.Label customerIDLabel1;
        private System.Windows.Forms.TextBox customerIDTextBox1;
        private System.Windows.Forms.TextBox addressIDTextBox1;
        private System.Windows.Forms.Label addressIDLabel1;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.TextBox nameBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView customerDataGridView1;
    }
}