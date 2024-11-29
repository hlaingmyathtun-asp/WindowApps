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
    public partial class tAddEditRecord : Form
    {

        private bool isEditMode;
        private bool saveChanges = false;
        private CarRentalEntities carRentingDB;
        private ManageRentalRecord manageaddEditCar;
        
        public tAddEditRecord(ManageRentalRecord manageRentalRecord = null)
        {
            InitializeComponent();
            manageaddEditCar = manageRentalRecord;
            lblTitle.Text = "Adding New Record";
            isEditMode = false;
            carRentingDB = new CarRentalEntities();
            this.MdiParent = this.MdiParent;


        }
        public tAddEditRecord(CarRentingTable carRecordToEdit,ManageRentalRecord manageRentalRecord = null)
        {
            InitializeComponent();
            
            manageaddEditCar = manageRentalRecord;
            carRentingDB = new CarRentalEntities();
            lblTitle.Text = "Editing Record";
            RentingPopulateFields(carRecordToEdit);

            isEditMode = true;
            this.MdiParent = this.MdiParent;

        }

        private void RentingPopulateFields(CarRentingTable carRecord)
        {
            tbCustomerName.Text = carRecord.Customer_Name;
            tbRentalCost.Text = carRecord.Rental_Cost.ToString();
            dtpStartedRentalDate.Value = (DateTime) carRecord.Rental_Start_Date;
            dtpLeaseEndDate.Value = (DateTime)carRecord.Lease_End_Date;
            lblCustomerId.Text = carRecord.id.ToString();
         
           
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //IsEditMode == true
            if(isEditMode)
            {
                try
                {
                    var Id =int.Parse(lblCustomerId.Text);
                    var editRecord = carRentingDB.CarRentingTables.FirstOrDefault( q => q.id == Id);
                    editRecord.Customer_Name = tbCustomerName.Text;
                    editRecord.Rental_Cost = Convert.ToDecimal(tbRentalCost.Text);
                    editRecord.Rental_Start_Date = dtpStartedRentalDate.Value;
                    editRecord.Lease_End_Date = dtpLeaseEndDate.Value;
                    editRecord.Type_Of_Car = (int) cbCarBrands.SelectedValue;

                    DialogResult diResult = MessageBox.Show("Are you sure to amend ", "Edit", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (diResult == DialogResult.Yes)
                    {
                        carRentingDB.SaveChanges();
                        saveChanges = true;

                        if (saveChanges)
                        {
                            manageaddEditCar.PopulatedRefresh();
                            MessageBox.Show("Editing was completed");
                            this.Close();
                        }
                    }

                   

                   


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
            else
            {
                try
                {
                    Console.WriteLine();


                var customerName = tbCustomerName.Text;
                var rentalCost = Convert.ToDecimal(tbRentalCost.Text);
                var rentalStartDate = dtpStartedRentalDate.Value;
                var leaseEndDate = dtpLeaseEndDate.Value;
                var typesOfCar = cbCarBrands.Text;
                var isValid = true;
                var errorMessage = string.Empty;



                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(tbRentalCost.Text) || string.IsNullOrEmpty(typesOfCar))
                {
                    isValid = false;
                    errorMessage += "Error : please do not put blank in the required field";
                }

                if (rentalStartDate >= leaseEndDate)
                {
                    isValid = false;
                    errorMessage += "Error : please check the date";
                }


                if (isValid)
                {
                    var addNewRecord = new CarRentingTable();
                    addNewRecord.Customer_Name = tbCustomerName.Text;
                    addNewRecord.Rental_Cost = Convert.ToDecimal(tbRentalCost.Text);
                    addNewRecord.Rental_Start_Date = dtpStartedRentalDate.Value;
                    addNewRecord.Lease_End_Date = dtpLeaseEndDate.Value;
                    addNewRecord.Type_Of_Car = (int)cbCarBrands.SelectedValue;

                    carRentingDB.CarRentingTables.Add(addNewRecord);

                    carRentingDB.SaveChanges();

                    saveChanges = true;

                    if(saveChanges)
                    {
                        manageaddEditCar.PopulatedRefresh();
                        MessageBox.Show("Successfully Added New Record then refresh");

                        this.Close();
                    }

                  
                }

                else
                {
                    MessageBox.Show(errorMessage);
                }

                Console.WriteLine();


            }
                catch (Exception)
                {

                MessageBox.Show("Error: Cannot be Added");
            }

        }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditRecord_Load(object sender, EventArgs e)
        {
            var cars = carRentingDB.CarTypesTables
                .Select(q => new
                {
                    Id = q.Id,
                    Car_Types = q.Make + " " + q.Model

                }).ToList();


            cbCarBrands.DisplayMember = "Car_Types";
            cbCarBrands.ValueMember = "Id";
            cbCarBrands.DataSource = cars;
        }
    }
}
