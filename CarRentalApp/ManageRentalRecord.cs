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
    public partial class ManageRentalRecord : Form
    {

        private CarRentalEntities recordDB;
        public ManageRentalRecord()
        {
            InitializeComponent();
            recordDB = new CarRentalEntities();
        }
        private void ManageRentalRecord_Load(object sender, EventArgs e)
        {
            var mangeRentalRecord = recordDB.CarRentingTables.Select(q =>
            new
            {
                q.Customer_Name,
                q.Rental_Cost,
                q.Rental_Start_Date,
                q.Lease_End_Date,
                CarBrands = q.CarTypesTable.Make + " " + q.CarTypesTable.Model,
                q.id
            }).ToList();

            dgvManageRentalRecord.DataSource = mangeRentalRecord;
            dgvManageRentalRecord.Columns[0].HeaderText = "Customer Name";
            dgvManageRentalRecord.Columns[1].HeaderText = "Rental Cost";
            dgvManageRentalRecord.Columns[2].HeaderText = "Rental Start Date";
            dgvManageRentalRecord.Columns[3].HeaderText = "Lease End Date";
            dgvManageRentalRecord.Columns[4].HeaderText = "Car Brands";
            dgvManageRentalRecord.Columns[5].Visible = false;
            dgvManageRentalRecord.Show();
          

        }
        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
           
            var addNewRecord = new tAddEditRecord(this);
            addNewRecord.ShowDialog();
            addNewRecord.MdiParent = this.MdiParent;
            //addNewRecord.Show();
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var Id = (int)dgvManageRentalRecord.CurrentRow.Cells["Id"].Value;

                var editRecord = recordDB.CarRentingTables.FirstOrDefault(q => q.id == Id);

                var editNewRecord = new tAddEditRecord(editRecord,this);

                editNewRecord.ShowDialog();
                editNewRecord.MdiParent = this.MdiParent;
                //editNewRecord.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select a row First");
            }
           
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var Id = (int)dgvManageRentalRecord.CurrentRow.Cells["Id"].Value;

                var deleteRecord = recordDB.CarRentingTables.FirstOrDefault(q => q.id == Id);

                
                DialogResult mgBox = MessageBox.Show($"Are you sure to delete {deleteRecord.Customer_Name} ","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);

                if(mgBox == DialogResult.Yes)
                {
                    recordDB.CarRentingTables.Remove(deleteRecord);

                    recordDB.SaveChanges();
                    PopulatedRefresh();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulatedRefresh();
        }

        public void PopulatedRefresh()
        {
            var rentalData = recordDB.CarRentingTables.Select(q =>
            new
            {
                q.Customer_Name,
                q.Rental_Cost,
                q.Rental_Start_Date,
                q.Lease_End_Date,
                CarBrands = q.CarTypesTable.Make + " " + q.CarTypesTable.Model,
                q.id
            }).ToList();

            dgvManageRentalRecord.DataSource = rentalData;
            dgvManageRentalRecord.Columns[0].HeaderText = "Customer Name";
            dgvManageRentalRecord.Columns[1].HeaderText = "Rental Cost";
            dgvManageRentalRecord.Columns[2].HeaderText = "Rental Start Date";
            dgvManageRentalRecord.Columns[3].HeaderText = "Lease End Date";
            dgvManageRentalRecord.Columns[4].HeaderText = "Car Brands";
            dgvManageRentalRecord.Columns[5].Visible = false;
            dgvManageRentalRecord.Update();
            dgvManageRentalRecord.Refresh();

        }

        
    }
}
