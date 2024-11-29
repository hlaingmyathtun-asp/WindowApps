namespace CarRentalApp
{
    partial class ManageUser
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
            this.lbYesDelete = new System.Windows.Forms.Label();
            this.dgvManageUser = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeactivateUser = new System.Windows.Forms.Button();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.lblManageUserTitle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageUser)).BeginInit();
            this.SuspendLayout();
            // 
            // lbYesDelete
            // 
            this.lbYesDelete.AutoSize = true;
            this.lbYesDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYesDelete.Location = new System.Drawing.Point(487, 34);
            this.lbYesDelete.Name = "lbYesDelete";
            this.lbYesDelete.Size = new System.Drawing.Size(0, 17);
            this.lbYesDelete.TabIndex = 13;
            // 
            // dgvManageUser
            // 
            this.dgvManageUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageUser.Location = new System.Drawing.Point(25, 53);
            this.dgvManageUser.Name = "dgvManageUser";
            this.dgvManageUser.Size = new System.Drawing.Size(498, 193);
            this.dgvManageUser.TabIndex = 12;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(422, 263);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeactivateUser
            // 
            this.btnDeactivateUser.Location = new System.Drawing.Point(307, 263);
            this.btnDeactivateUser.Name = "btnDeactivateUser";
            this.btnDeactivateUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeactivateUser.TabIndex = 10;
            this.btnDeactivateUser.Text = "Deactivated User";
            this.btnDeactivateUser.UseVisualStyleBackColor = true;
            this.btnDeactivateUser.Click += new System.EventHandler(this.btnDeactivateUser_Click);
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Location = new System.Drawing.Point(155, 263);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(105, 23);
            this.btnUpdatePassword.TabIndex = 11;
            this.btnUpdatePassword.Text = "Update Password";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Location = new System.Drawing.Point(48, 263);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewUser.TabIndex = 8;
            this.btnAddNewUser.Text = "Add New User";
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // lblManageUserTitle
            // 
            this.lblManageUserTitle.AutoSize = true;
            this.lblManageUserTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageUserTitle.Location = new System.Drawing.Point(43, 9);
            this.lblManageUserTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManageUserTitle.Name = "lblManageUserTitle";
            this.lblManageUserTitle.Size = new System.Drawing.Size(142, 26);
            this.lblManageUserTitle.TabIndex = 7;
            this.lblManageUserTitle.Text = "Manage User";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(448, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete User";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 296);
            this.Controls.Add(this.lbYesDelete);
            this.Controls.Add(this.dgvManageUser);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeactivateUser);
            this.Controls.Add(this.btnUpdatePassword);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.lblManageUserTitle);
            this.Name = "ManageUser";
            this.Text = "Manage User";
            this.Load += new System.EventHandler(this.ManageUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbYesDelete;
        private System.Windows.Forms.DataGridView dgvManageUser;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeactivateUser;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Label lblManageUserTitle;
        private System.Windows.Forms.Button btnDelete;
    }
}