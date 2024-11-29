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
    public partial class ResetPassword : Form
    {
        private CarRentalEntities userDb;
        private userLoginTable userName;
        public ResetPassword(userLoginTable userLoginName)
        {
            InitializeComponent();
            userName = userLoginName;
            userDb =new CarRentalEntities();
            
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var password = tbPassword.Text;
            var confirmPassword = tbConfirmPassword.Text;

            if (confirmPassword != password)
            {
                MessageBox.Show("Password must be matched");
            }

            else if (confirmPassword == password)
            {
                try
                {

                   
                    var updateUserPassword = userDb.userLoginTables.FirstOrDefault( q => q.id == userName.id);
                    
                    updateUserPassword.password = Utility.HashPassword(password);

                    userDb.SaveChanges();
                    MessageBox.Show("Password has been successfully changed");
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    
                }
            
            }
            

        }
    }
}
