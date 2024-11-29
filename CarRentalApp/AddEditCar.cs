using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CarRentalApp
{
    public partial class AddEditCar : Form
    {

        bool isEditMode;
        bool saveChanges = false;

        private CarRentalEntities carDB;

        public ManageVehicleListing manageAddEditCar;

        public AddEditCar(ManageVehicleListing manageVehicleListing)
        {
            InitializeComponent();
            manageAddEditCar = manageVehicleListing;
            isEditMode = false;
            carDB = new CarRentalEntities();
            lblTitle.Text = "Add New Car";


         
        }
        //car in edit mode
        public AddEditCar(CarTypesTable carsToEdit,ManageVehicleListing manageVehicleListing)
        {
            InitializeComponent();
            manageAddEditCar = manageVehicleListing;

            lblTitle.Text = "Edit Car";
            isEditMode = true;
            carDB = new CarRentalEntities();
            PopulateFields(carsToEdit);
           




        }

        private void PopulateFields(CarTypesTable cars)
        {
            lbCarID.Text = cars.Id.ToString();
            tbMake.Text = cars.Make;
            tbModel.Text = cars.Model;
            tbVIN.Text = cars.VIN;
            tbYear.Text = cars.Year.ToString();
            tbLicensePlateNumber.Text = cars.LicensePlateNumber;
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            try
            {
                //isEditMode == true

                if (isEditMode)
                {


                    var Id = int.Parse(lbCarID.Text);
                    var editCar = carDB.CarTypesTables.FirstOrDefault(q => q.Id == Id);


                    if (string.IsNullOrEmpty(tbMake.Text))
                    {
                        MessageBox.Show("Please do not blank in Name");

                    }
                    else
                    {
                        editCar.Make = tbMake.Text;
                    }

                    if (string.IsNullOrEmpty(tbModel.Text))
                    {
                        editCar.Model = null;
                    }

                    else
                    {
                        editCar.Model = tbModel.Text;
                    }


                    if (string.IsNullOrEmpty(tbVIN.Text))
                    {
                        editCar.VIN = null;
                    }
                    else
                    {
                        editCar.VIN = tbVIN.Text;

                    }

                    if (string.IsNullOrEmpty(tbLicensePlateNumber.Text))
                    {
                        editCar.LicensePlateNumber = null;
                    }
                    else
                    {
                        editCar.LicensePlateNumber = tbLicensePlateNumber.Text;

                    }

                    if (string.IsNullOrEmpty(tbYear.Text))
                    {
                        editCar.Year = null;
                    }
                    else
                    {
                        editCar.Year = int.Parse(tbYear.Text);

                    }



                    carDB.SaveChanges();
                    saveChanges = true;

                    if (saveChanges)
                    {
                        manageAddEditCar.PopulateRefresh();
                        
                        MessageBox.Show("Edited Completed ");
                        this.Close();
                    }




                }

                else
                {
                    //var addCar = new CarTypesTable
                    //{
                    //    addCar.Make = tbMake.Text;
                    //    addCar.Model = tbModel.Text;
                    //    addCar.VIN = tbVIN.Text;
                    //    addCar.Year = int.Parse(tbYear.Text);
                    //    addCar.LicensePlateNumber = tbLicensePlateNumber.Text;
                    //};

                    var addCar = new CarTypesTable();
                 
                    if (string.IsNullOrEmpty(tbMake.Text))
                    {
                        MessageBox.Show("Please do not blank in Name");
                        
                    }
                    else
                    {
                        addCar.Make = tbMake.Text;
                    }

                    if(string.IsNullOrEmpty(tbModel.Text))
                    {
                        addCar.Model = null;
                    }

                    else
                    {
                        addCar.Model = tbModel.Text;
                    }

                    
                    if (string.IsNullOrEmpty(tbVIN.Text))
                    {
                        addCar.VIN = null;
                    }
                    else
                    {
                        addCar.VIN = tbVIN.Text;

                    }

                   if(string.IsNullOrEmpty (tbLicensePlateNumber.Text))
                    {
                        addCar.LicensePlateNumber = null;
                    }
                   else
                    {
                        addCar.LicensePlateNumber = tbLicensePlateNumber.Text;

                    }

                   if(string.IsNullOrEmpty(tbYear.Text))
                    {
                        addCar.Year = null;
                    }
                   else
                    {
                        addCar.Year = int.Parse(tbYear.Text);

                    }


                    carDB.CarTypesTables.Add(addCar);

                    carDB.SaveChanges();
                    saveChanges = true;
                    if (saveChanges)
                    {
                        manageAddEditCar.PopulateRefresh();
                        MessageBox.Show("Added New Car");
                        Thread.Sleep(500);
                        this.Close();
                       


                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

      

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       

       
    }
}
