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
    using Rkna_Project.MetaData;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(Company_TableMeta1))]
    public partial class Company_Table
    {
        public int Company_Info_ID { get; set; }
        public string Company_Name { get; set; }
        public string Company_Desc { get; set; }
        public string Com_Pnone1 { get; set; }
        public string Com_Pnone2 { get; set; }
        public string Com_Pnone3 { get; set; }
        public string Comp_Manger { get; set; }
    }
}
