using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberlesmePortali.ViewModels
{
    public class KullaniciModel
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Resim { get; set; }
        public Nullable<decimal> Numara { get; set; }
        public string Durum { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
    }
}