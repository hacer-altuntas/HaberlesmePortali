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
    
    public partial class Mesaj
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mesaj()
        {
            this.Alicilar = new HashSet<Alicilar>();
        }
    
        public int MesajId { get; set; }
        public string İcerik { get; set; }
        public Nullable<int> GonderenId { get; set; }
        public Nullable<int> GrupId { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<int> Okunma { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alicilar> Alicilar { get; set; }
        public virtual Grup Grup { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
