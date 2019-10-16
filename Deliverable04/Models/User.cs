//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deliverable04.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.UserTypes = new HashSet<UserType>();
        }
    
        public int UserID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> DietID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Weight { get; set; }
        public string Allergies { get; set; }
    
        public virtual City City { get; set; }
        public virtual Diet Diet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserType> UserTypes { get; set; }
    }
}