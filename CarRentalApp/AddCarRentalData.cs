using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddCarRentalData : Form
    {
        private readonly CarRentalEntities carRentalEntities;
        public AddCarRentalData()
        {
            InitializeComponent();
            carRentalEntities = new CarRentalEntities();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            try
            {
            
                var customerName = tbCustomerName.Text;
                var rentalCost = Convert.ToDecimal(tbRentalCost.Text);
                var rentalStartDate = dtpRentalStartDate.Value;
                var leaseEndDate = dtpLeaseEndDate.Value;
                var typesOfCar = cbTypesOfCar.Text;
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
                        var carRentalAppData = new CarRentingTable();
                        carRentalAppData.Customer_Name = customerName;
                        carRentalAppData.Rental_Cost = rentalCost;
                        carRentalAppData.Rental_Start_Date = rentalStartDate;
                        carRentalAppData.Lease_End_Date = leaseEndDate;
                        carRentalAppData.Type_Of_Car = (int) cbTypesOfCar.SelectedValue;

                        carRentalEntities.CarRentingTables.Add(carRentalAppData);
                        carRentalEntities.SaveChanges();
                        MessageBox.Show($"\tCustomer Name : {customerName} \n" +
                        string.Format("\tRental Cost : {0:C} \n", rentalCost) +
                        $"\tRental Start Date : {rentalStartDate} \n" +
                        $"\tLease End Date : {leaseEndDate} \n" +
                        $"\tTypes Of Car : {typesOfCar}  \n");
                }

                else
                {
                    MessageBox.Show(errorMessage);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

                //throw;
            }

            





        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //select * from tables
            //var cars = carRentalEntities.CarTypesTables.ToList();
            var cars = carRentalEntities.CarTypesTables
                .Select(q => new
                {
                    Id = q.Id, Car_Types = q.Make + " "  + q.Model 

                }).ToList();


            cbTypesOfCar.DisplayMember = "Car_Types";
            cbTypesOfCar.ValueMember = "Id";
            cbTypesOfCar.DataSource = cars;

        }

       
    }
}
