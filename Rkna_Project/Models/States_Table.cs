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

    [MetadataType(typeof(MetaData.States_TableMeta))]
    public partial class States_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public States_Table()
        {
            this.Area_Table = new HashSet<Area_Table>();
        }
    
        public int States_ID { get; set; }
        public int Gov_ID { get; set; }
        public string States_Name { get; set; }
        public string States_Desc { get; set; }
        public string States_X_Point { get; set; }
        public string States_Y_Point { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area_Table> Area_Table { get; set; }
        public virtual Governorate_Table Governorate_Table { get; set; }
    }
}
