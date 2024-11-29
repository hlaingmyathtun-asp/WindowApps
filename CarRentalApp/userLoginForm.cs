using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class userLoginForm : Form
    {
        private CarRentalEntities userDb;
        public userLoginForm()
        {
            InitializeComponent();
            userDb = new CarRentalEntities();

         

           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           

            var userName = tbUserName.Text.Trim();
            var password = tbPassword.Text.Trim();


            var hashPassword = Utility.HashPassword(password);
            //// the below code is just for testing password update
            //var update = userDb.userLoginTables.FirstOrDefault(q => q.id == 1);


            //if (update.id == 1)
            //{

            //    update.password = hashPassword;
            //    userDb.SaveChanges();
            //    MessageBox.Show("Successfully Saved");
            //}
            ////the above code is just for password auto update (testing) purpose



            var user = userDb.userLoginTables.FirstOrDefault(q => q.password == hashPassword && q.userName == userName && q.isActive == true);


            if (user == null)
            {
                MessageBox.Show("Please enter the valid credital words");
            }
            else
            {

               

                MainWindow mainWindow = new MainWindow(this, user);
                mainWindow.Show();
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
