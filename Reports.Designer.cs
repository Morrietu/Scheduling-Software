namespace Scheduling_Software
{
    partial class Reports
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.closeButton1 = new System.Windows.Forms.Button();
            this.appointmentRadioButton1 = new System.Windows.Forms.RadioButton();
            this.consultantRadioButton1 = new System.Windows.Forms.RadioButton();
            this.infoRadioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(41, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(364, 225);
            this.dataGridView1.TabIndex = 0;
            // 
            // closeButton1
            // 
            this.closeButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton1.Location = new System.Drawing.Point(172, 372);
            this.closeButton1.Name = "closeButton1";
            this.closeButton1.Size = new System.Drawing.Size(107, 36);
            this.closeButton1.TabIndex = 1;
            this.closeButton1.Text = "Close";
            this.closeButton1.UseVisualStyleBackColor = true;
            this.closeButton1.Click += new System.EventHandler(this.closeButton1_Click);
            // 
            // appointmentRadioButton1
            // 
            this.appointmentRadioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.appointmentRadioButton1.AutoSize = true;
            this.appointmentRadioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentRadioButton1.Location = new System.Drawing.Point(22, 39);
            this.appointmentRadioButton1.Name = "appointmentRadioButton1";
            this.appointmentRadioButton1.Size = new System.Drawing.Size(116, 17);
            this.appointmentRadioButton1.TabIndex = 2;
            this.appointmentRadioButton1.TabStop = true;
            this.appointmentRadioButton1.Text = "Appointment Types";
            this.appointmentRadioButton1.UseVisualStyleBackColor = true;
            this.appointmentRadioButton1.CheckedChanged += new System.EventHandler(this.appointmentRadioButton1_CheckedChanged);
            // 
            // consultantRadioButton1
            // 
            this.consultantRadioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.consultantRadioButton1.AutoSize = true;
            this.consultantRadioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultantRadioButton1.Location = new System.Drawing.Point(156, 39);
            this.consultantRadioButton1.Name = "consultantRadioButton1";
            this.consultantRadioButton1.Size = new System.Drawing.Size(123, 17);
            this.consultantRadioButton1.TabIndex = 3;
            this.consultantRadioButton1.TabStop = true;
            this.consultantRadioButton1.Text = "Consultant Schedule";
            this.consultantRadioButton1.UseVisualStyleBackColor = true;
            this.consultantRadioButton1.CheckedChanged += new System.EventHandler(this.consultantRadioButton1_CheckedChanged);
            // 
            // infoRadioButton1
            // 
            this.infoRadioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.infoRadioButton1.AutoSize = true;
            this.infoRadioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoRadioButton1.Location = new System.Drawing.Point(301, 39);
            this.infoRadioButton1.Name = "infoRadioButton1";
            this.infoRadioButton1.Size = new System.Drawing.Size(105, 17);
            this.infoRadioButton1.TabIndex = 4;
            this.infoRadioButton1.TabStop = true;
            this.infoRadioButton1.Text = "Appointment Info";
            this.infoRadioButton1.UseVisualStyleBackColor = true;
            this.infoRadioButton1.CheckedChanged += new System.EventHandler(this.infoRadioButton1_CheckedChanged);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 432);
            this.Controls.Add(this.infoRadioButton1);
            this.Controls.Add(this.consultantRadioButton1);
            this.Controls.Add(this.appointmentRadioButton1);
            this.Controls.Add(this.closeButton1);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(458, 471);
            this.Name = "Reports";
            this.Text = "AppointmentReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button closeButton1;
        private System.Windows.Forms.RadioButton appointmentRadioButton1;
        private System.Windows.Forms.RadioButton consultantRadioButton1;
        private System.Windows.Forms.RadioButton infoRadioButton1;
    }
}