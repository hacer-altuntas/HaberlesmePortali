//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HaberlesmePortali.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grup()
        {
            this.GrupUye = new HashSet<GrupUye>();
            this.Mesaj = new HashSet<Mesaj>();
        }
    
        public int GrupId { get; set; }
        public string GrupAdi { get; set; }
        public string Hakkinda { get; set; }
        public string GrupResim { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupUye> GrupUye { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mesaj> Mesaj { get; set; }
    }
}
