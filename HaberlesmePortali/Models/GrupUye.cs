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
    
    public partial class GrupUye
    {
        public int UyeId { get; set; }
        public Nullable<int> KullaniciId { get; set; }
        public Nullable<int> GrupId { get; set; }
        public Nullable<int> UyeYetki { get; set; }
    
        public virtual Grup Grup { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}