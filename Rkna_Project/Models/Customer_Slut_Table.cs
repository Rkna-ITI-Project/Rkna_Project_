//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rkna_Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(MetaData.Customer_Slut_TableMeta))]
    public partial class Customer_Slut_Table
    {
        public int Customer_Slut_ID { get; set; }
        public string Customer_ID { get; set; }
        public int Slut_ID { get; set; }
        public int Car_Spe_ID { get; set; }
        public System.DateTime Cus_Slut_Date { get; set; }
        public System.TimeSpan Cus_Slut_S_Time { get; set; }
        public System.TimeSpan Cus_Slut_E_Time { get; set; }
        public string Cheeck_Code { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Car_Specifications_Table Car_Specifications_Table { get; set; }
        public virtual Slut_Table Slut_Table { get; set; }
    }
}
