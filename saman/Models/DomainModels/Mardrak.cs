//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace saman.Models.DomainModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mardrak
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mardrak()
        {
            this.Person_Madraks = new HashSet<Person_Madraks>();
        }
    
        public int Id { get; set; }
        public string MadrakText { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person_Madraks> Person_Madraks { get; set; }
    }
}