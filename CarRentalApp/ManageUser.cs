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
    public partial class ManageUser : Form
    {
        private CarRentalEntities userDb;
        private userLoginTable userLoginName;
        private string userRoleName;
        public ManageUser()
        {
            InitializeComponent();
            userDb = new CarRentalEntities();
        }

        public ManageUser(userLoginTable userLoginInfo,string roleName)
        {
            InitializeComponent();
            userDb = new CarRentalEntities();
            userLoginName = userLoginInfo;
            userRoleName = roleName;
            if( userRoleName.Trim() == "clerk")
            {
                btnAddNewUser.Enabled = false;
                btnUpdatePassword.Enabled = false;
                btnDeactivateUser.Enabled = false;
                btnDelete.Enabled = false;
            }
        }



        private void ManageUser_Load(object sender, EventArgs e)
        {

            var userRoles = userDb.userLoginTables.Select(q => new
            {
                q.userName,
                //q.password,
                q.id,
                q.userRolesTables.FirstOrDefault().rolesTable.name,
                q.isActive


            }).ToList();

            dgvManageUser.DataSource = userRoles;
            dgvManageUser.Columns[0].HeaderText = "Username";
            //dgvManageUser.Columns[1].HeaderText = "Password";
            dgvManageUser.Columns[2].HeaderText = "Role Name";
            if (userRoleName.Trim() == "clerk")
            {
                dgvManageUser.Columns[3].Visible = false;

            }
            else
            {
                dgvManageUser.Columns[3].HeaderText = "IsActive";
            }
            dgvManageUser.Columns[1].Visible = false;
            dgvManageUser.Show();


        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            
             if(!Utility.IsOpenForm("AddEditUser"))
            {
                var addedNewUser = new AddEditUser(this);
                //addedNewUser.ShowDialog();
                addedNewUser.MdiParent = this.MdiParent;
                addedNewUser.Show();

            }

        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = (int)dgvManageUser.CurrentRow.Cells["id"].Value;
                var updatePassword = userDb.userLoginTables.FirstOrDefault(q => q.id == selectedRow);
                var hashPassword = Utility.DefaultHashPassword();

                updatePassword.password = hashPassword;

                userDb.SaveChanges();
                
                MUPopulateRefresh();

                MessageBox.Show($"{updatePassword.userName.Trim()}'s password has been reset");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           




            

        }

        private void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = (int)dgvManageUser.CurrentRow.Cells["id"].Value;
                var updatePermit = userDb.userLoginTables.FirstOrDefault(q => q.id == selectedRow);

                userLoginName.isActive = userLoginName.isActive == true ? false : true;

                updatePermit.isActive = userLoginName.isActive;
                userDb.SaveChanges();

                if (updatePermit.isActive)
                {
                    MUPopulateRefresh();

                    MessageBox.Show($"{updatePermit.userName.Trim()} has been activated","Activation Succeed");
                }
                else
                {
                    MUPopulateRefresh();

                    MessageBox.Show($"{updatePermit.userName.Trim()} has been de-activated","Deactivation Succeed");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MUPopulateRefresh();
        }

        public void MUPopulateRefresh()
        {
            var userRoles = userDb.userLoginTables.Select(q => new
            {
                q.userName,
                //q.password,
                q.id,
                q.userRolesTables.FirstOrDefault().rolesTable.name,
                q.isActive


            }).ToList();

            dgvManageUser.DataSource = userRoles;
            dgvManageUser.Columns[0].HeaderText = "Username";
            //dgvManageUser.Columns[1].HeaderText = "Password";
            dgvManageUser.Columns[2].HeaderText = "Role Name";
            if (userRoleName.Trim() == "clerk")
            {
                dgvManageUser.Columns[3].Visible = false;

            }
            else
            {
                dgvManageUser.Columns[3].HeaderText = "IsActive";
            }
            dgvManageUser.Columns[1].Visible = false;
            dgvManageUser.Update();
            dgvManageUser.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = (int) dgvManageUser.CurrentRow.Cells["id"].Value;
            var deleteUser = userDb.userLoginTables.FirstOrDefault(q => q.id == selectedRow);

            userDb.userLoginTables.Remove(deleteUser);
            userDb.SaveChanges();
            MUPopulateRefresh();
            MessageBox.Show($"Successfully removed {deleteUser.userName}");
        }

     
    }
}
