//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DP_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.Permissions = new HashSet<Permission>();
            this.Transfer_Item = new HashSet<Transfer_Item>();
        }
    
        public int Supp_ID { get; set; }
        public string Supp_Name { get; set; }
        public int Supp_Mobile { get; set; }
        public Nullable<int> Supp_Telephone { get; set; }
        public Nullable<int> Supp_Fax { get; set; }
        public string Supp_Email { get; set; }
        public string Supp_Website { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transfer_Item> Transfer_Item { get; set; }
    }
}
