//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRentalApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarRentingTable
    {
        public int id { get; set; }
        public string Customer_Name { get; set; }
        public Nullable<decimal> Rental_Cost { get; set; }
        public Nullable<System.DateTime> Rental_Start_Date { get; set; }
        public Nullable<System.DateTime> Lease_End_Date { get; set; }
        public Nullable<int> Type_Of_Car { get; set; }
    
        public virtual CarTypesTable CarTypesTable { get; set; }
    }
}
