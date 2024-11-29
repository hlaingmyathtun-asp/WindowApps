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
    public partial class ManageVehicleListing : Form
    {
     
        private readonly CarRentalEntities carDb = new CarRentalEntities();
        public ManageVehicleListing()
        {
            InitializeComponent();

           
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            // select * (all) from CarTypesTables as a list
            //var cars = carRentalEntitiesDB.CarTypesTables.ToList();
            //select id as CarID , CarTypes as Car Name from CarTypesTables
            //var cars = carRentalEntitiesDB.CarTypesTables.Select(q => new { CarID = q.id, CarName = q.Car_Types}).ToList();
            
            var cars = carDb.CarTypesTables
                .Select(q => new { 
                    Make = q.Make,
                    Model = q.Model,
                    VIN = q.VIN,
                    Year = q.Year,
                    LicensePlateNumber = q.LicensePlateNumber,
                    q.Id
                }).ToList();

            dgvManageVehicleListing.DataSource = cars;
            dgvManageVehicleListing.Columns[4].HeaderText = "License Name Plate";
            dgvManageVehicleListing.Columns[5].Visible = false;
            dgvManageVehicleListing.Show();




        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            var newCar = new AddEditCar(this);


            newCar.ShowDialog();
            newCar.MdiParent = this.MdiParent;
            
            
            //newCar.Show();

            

        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            // get Id of the selected Row

            //dgvManageVehicleListing.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvManageVehicleListing.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //var selectedRow = dgvManageVehicleListing.CurrentRow;

            if (dgvManageVehicleListing.CurrentRow != null)
            {
                var Id = (int) dgvManageVehicleListing.CurrentRow.Cells["Id"].Value;
                // query the database for record

                var car = carDb.CarTypesTables.FirstOrDefault(q => q.Id == Id);

                //// launch the EditVechicel window with data

                var editCar = new AddEditCar(car,this);
                editCar.ShowDialog();
                editCar.MdiParent = this.MdiParent;

              

                
            }

            else
            {
                MessageBox.Show("Please select a row First");
              
            }
            
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {

                
                    var Id = (int)dgvManageVehicleListing.CurrentRow.Cells["Id"].Value;

                    // query the database for record
                    if (dgvManageVehicleListing.CurrentRow != null)
                {
                    var car = carDb.CarTypesTables.FirstOrDefault(q => q.Id == Id);

                    DialogResult messagDialog = MessageBox.Show($"Are you to delte [ {car.Make + " " + car.LicensePlateNumber} ] ", "Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (messagDialog == DialogResult.Yes)
                    {
                        
                            carDb.CarTypesTables.Remove(car);
                            carDb.SaveChanges();
                            MessageBox.Show("Car deleted successfully!");
                            PopulateRefresh();
                       
                        
                        
                    }

                   
                }
                    else
                {
                    MessageBox.Show("Select a row first");
                }
                  


             
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            // get Id of the selected Row



        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
            PopulateRefresh();
            
        }


        public  void PopulateRefresh()
        {
           
            var cars = carDb.CarTypesTables
                  .Select(q => new
                  {
                      Make = q.Make,
                      Model = q.Model,
                      VIN = q.VIN,
                      Year = q.Year,
                      LicensePlateNumber = q.LicensePlateNumber,
                      q.Id
                  })
                  .ToList();
            dgvManageVehicleListing.DataSource = cars;
            dgvManageVehicleListing.Columns[4].HeaderText = "License Plate Number";
            //Hide the column for ID. Changed from the hard coded column value to the name, 
            // to make it more dynamic. 
            dgvManageVehicleListing.Columns["Id"].Visible = false;
            dgvManageVehicleListing.Update();
            dgvManageVehicleListing.Refresh();

        }

    }

        
    
}
