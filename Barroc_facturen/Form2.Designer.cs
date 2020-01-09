namespace Barroc_facturen
{
    partial class Form2
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
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.LeaseIDlbl = new System.Windows.Forms.Label();
            this.Pricelbl = new System.Windows.Forms.Label();
            this.FinalPayDatelbl = new System.Windows.Forms.Label();
            this.PaymentFinishedlbl = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.contractComboBox = new System.Windows.Forms.ComboBox();
            this.updatePayDateButton = new System.Windows.Forms.Button();
            this.invoiceComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(480, 225);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(261, 24);
            this.customerComboBox.TabIndex = 0;
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            // 
            // LeaseIDlbl
            // 
            this.LeaseIDlbl.AutoSize = true;
            this.LeaseIDlbl.Location = new System.Drawing.Point(197, 109);
            this.LeaseIDlbl.Name = "LeaseIDlbl";
            this.LeaseIDlbl.Size = new System.Drawing.Size(0, 17);
            this.LeaseIDlbl.TabIndex = 2;
            // 
            // Pricelbl
            // 
            this.Pricelbl.AutoSize = true;
            this.Pricelbl.Location = new System.Drawing.Point(197, 152);
            this.Pricelbl.Name = "Pricelbl";
            this.Pricelbl.Size = new System.Drawing.Size(0, 17);
            this.Pricelbl.TabIndex = 3;
            // 
            // FinalPayDatelbl
            // 
            this.FinalPayDatelbl.AutoSize = true;
            this.FinalPayDatelbl.Location = new System.Drawing.Point(197, 196);
            this.FinalPayDatelbl.Name = "FinalPayDatelbl";
            this.FinalPayDatelbl.Size = new System.Drawing.Size(0, 17);
            this.FinalPayDatelbl.TabIndex = 4;
            // 
            // PaymentFinishedlbl
            // 
            this.PaymentFinishedlbl.AutoSize = true;
            this.PaymentFinishedlbl.Location = new System.Drawing.Point(197, 244);
            this.PaymentFinishedlbl.Name = "PaymentFinishedlbl";
            this.PaymentFinishedlbl.Size = new System.Drawing.Size(0, 17);
            this.PaymentFinishedlbl.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(541, 324);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // contractComboBox
            // 
            this.contractComboBox.FormattingEnabled = true;
            this.contractComboBox.Location = new System.Drawing.Point(541, 255);
            this.contractComboBox.Name = "contractComboBox";
            this.contractComboBox.Size = new System.Drawing.Size(200, 24);
            this.contractComboBox.TabIndex = 7;
            this.contractComboBox.SelectedIndexChanged += new System.EventHandler(this.contractComboBox_SelectedIndexChanged);
            // 
            // updatePayDateButton
            // 
            this.updatePayDateButton.Location = new System.Drawing.Point(541, 362);
            this.updatePayDateButton.Name = "updatePayDateButton";
            this.updatePayDateButton.Size = new System.Drawing.Size(99, 51);
            this.updatePayDateButton.TabIndex = 8;
            this.updatePayDateButton.Text = "Betaaldatum toevoegen";
            this.updatePayDateButton.UseVisualStyleBackColor = true;
            this.updatePayDateButton.Click += new System.EventHandler(this.updatePayDateButton_Click);
            // 
            // invoiceComboBox
            // 
            this.invoiceComboBox.FormattingEnabled = true;
            this.invoiceComboBox.Location = new System.Drawing.Point(541, 290);
            this.invoiceComboBox.Name = "invoiceComboBox";
            this.invoiceComboBox.Size = new System.Drawing.Size(200, 24);
            this.invoiceComboBox.TabIndex = 9;
            this.invoiceComboBox.SelectedIndexChanged += new System.EventHandler(this.invoiceComboBox_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.invoiceComboBox);
            this.Controls.Add(this.updatePayDateButton);
            this.Controls.Add(this.contractComboBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.PaymentFinishedlbl);
            this.Controls.Add(this.FinalPayDatelbl);
            this.Controls.Add(this.Pricelbl);
            this.Controls.Add(this.LeaseIDlbl);
            this.Controls.Add(this.customerComboBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label LeaseIDlbl;
        private System.Windows.Forms.Label Pricelbl;
        private System.Windows.Forms.Label FinalPayDatelbl;
        private System.Windows.Forms.Label PaymentFinishedlbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox contractComboBox;
        private System.Windows.Forms.Button updatePayDateButton;
        private System.Windows.Forms.ComboBox invoiceComboBox;
    }
}