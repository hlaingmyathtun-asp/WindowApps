namespace CarRentalApp
{
    partial class tAddEditRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tAddEditRecord));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpLeaseEndDate = new System.Windows.Forms.DateTimePicker();
            this.tbRentalCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.dtpStartedRentalDate = new System.Windows.Forms.DateTimePicker();
            this.cbCarBrands = new System.Windows.Forms.ComboBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.dtpLeaseEndDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbRentalCost, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lb, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbCustomerName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpStartedRentalDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbCarBrands, 1, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // dtpLeaseEndDate
            // 
            resources.ApplyResources(this.dtpLeaseEndDate, "dtpLeaseEndDate");
            this.dtpLeaseEndDate.Name = "dtpLeaseEndDate";
            // 
            // tbRentalCost
            // 
            resources.ApplyResources(this.tbRentalCost, "tbRentalCost");
            this.tbRentalCost.Name = "tbRentalCost";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lb
            // 
            resources.ApplyResources(this.lb, "lb");
            this.lb.Name = "lb";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tbCustomerName
            // 
            resources.ApplyResources(this.tbCustomerName, "tbCustomerName");
            this.tbCustomerName.Name = "tbCustomerName";
            // 
            // dtpStartedRentalDate
            // 
            resources.ApplyResources(this.dtpStartedRentalDate, "dtpStartedRentalDate");
            this.dtpStartedRentalDate.Name = "dtpStartedRentalDate";
            // 
            // cbCarBrands
            // 
            resources.ApplyResources(this.cbCarBrands, "cbCarBrands");
            this.cbCarBrands.FormattingEnabled = true;
            this.cbCarBrands.Name = "cbCarBrands";
            // 
            // btnSaveChanges
            // 
            resources.ApplyResources(this.btnSaveChanges, "btnSaveChanges");
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // lblCustomerId
            // 
            resources.ApplyResources(this.lblCustomerId, "lblCustomerId");
            this.lblCustomerId.Name = "lblCustomerId";
            // 
            // tAddEditRecord
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCustomerId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "tAddEditRecord";
            this.Load += new System.EventHandler(this.AddEditRecord_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpLeaseEndDate;
        private System.Windows.Forms.TextBox tbRentalCost;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.DateTimePicker dtpStartedRentalDate;
        private System.Windows.Forms.ComboBox cbCarBrands;
        private System.Windows.Forms.Label lblCustomerId;
    }
}