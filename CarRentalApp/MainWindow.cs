using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainWindow : Form
    {

        private userLoginForm userLoginForm;

        private userLoginTable userLoginName;

        private string rolesIdName;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(userLoginForm userLoginForm, userLoginTable userName)
        {
            InitializeComponent();
            userLoginName = userName;
            rolesIdName = userName.userRolesTables.FirstOrDefault().rolesTable.shortName.ToString().Trim();
            this.userLoginForm = userLoginForm;
        }




        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (!Utility.IsOpenForm("AddCarRentalData"))
            {
                var addCarRentalRecord = new AddCarRentalData();

                addCarRentalRecord.MdiParent = this;
                addCarRentalRecord.Show();
            }
                                                                                     
            

        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (!Utility.IsOpenForm("ManageVehicleListing"))
            {
                var manageVehicleListing = new ManageVehicleListing();

                manageVehicleListing.MdiParent = this;
                manageVehicleListing.Show();
            }
           
           
        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (!Utility.IsOpenForm("ManageRentalRecord"))
            {
                var manageRentalRecord = new ManageRentalRecord();

                manageRentalRecord.MdiParent = this;
                manageRentalRecord.Show();
            }
           
           

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            userLoginForm.Close();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (userLoginName.password.Trim() == Utility.DefaultHashPassword())
            {
                var resetPassword = new ResetPassword(userLoginName);
                resetPassword.ShowDialog();
            }
            tslStatus.Text = $"Login As : {userLoginName.userName}";
            if (rolesIdName == "admin" || rolesIdName == "clerk")
            {
                managUserToolStripMenuItem.Visible = true;
            }

            else
            {
                managUserToolStripMenuItem.Visible = false;

            }
        }

        private void managUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!Utility.IsOpenForm("ManageUser"))
            {
                ManageUser manageUser = new ManageUser(userLoginName,userLoginName.userRolesTables.FirstOrDefault().rolesTable.shortName);
                manageUser.MdiParent = this;
                manageUser.Show();
            }
          

        }

        
    }


}
