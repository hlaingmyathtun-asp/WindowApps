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
    public partial class AddEditUser : Form
    {
        
        private CarRentalEntities userDb;

        private userLoginTable newUser;
        private userRolesTable newRoles;
        private rolesTable rolesTable;
     

        private ManageUser manageUser;
        public AddEditUser()
        {
            InitializeComponent();
            userDb = new CarRentalEntities();
            

        }

        public  AddEditUser(ManageUser manageUser)
        {
            InitializeComponent();
            lblManageUserTitle.Text = "Add New User";
            this.manageUser = manageUser;
            userDb = new CarRentalEntities();
            newUser = new userLoginTable();
            newRoles = new userRolesTable();
            rolesTable = new rolesTable();
            
        }

       

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
               
            
                newUser.userName = tbUserName.Text;
                newUser.password = tbPasswrod.Text;
                if (string.IsNullOrWhiteSpace(tbPasswrod.Text))
                {
                    newUser.password = Utility.DefaultHashPassword();
                }
                else
                {
                  
                    var hashPassword = Utility.HashPassword(newUser.password);
                    newUser.password = hashPassword;
                }

              


                rolesTable.name = cbRoles.Text;
                if(cbRoles.Text == "data entry clerk                                  ")
                {
                    rolesTable.shortName = "clerk";
                }
                else
                {
                    rolesTable.shortName = cbRoles.Text.Substring(0, 5);
                }


                newRoles.userId = newUser.id;
                newRoles.roleId = rolesTable.id;




                userDb.userLoginTables.Add(newUser);
                userDb.rolesTables.Add(rolesTable);
                userDb.userRolesTables.Add(newRoles);
                userDb.SaveChanges();


                manageUser.MUPopulateRefresh();

                
                MessageBox.Show($"User Name : {newUser.userName} successfully added");
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbActivate_Click(object sender, EventArgs e)
        {
            newUser.isActive = cbActivate.Checked;

        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            var userRoles = userDb.rolesTables.Select(q => new
            { 
                q.id,
                Name = q.name.Trim() 
               

            }).ToList();
            cbRoles.DisplayMember = "Name";
            cbRoles.ValueMember = "Id";
            cbRoles.DataSource = userRoles;
            
            cbRoles.Show();
        }

        
    }
}
