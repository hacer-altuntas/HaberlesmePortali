using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberlesmePortali.ViewModels
{
    public class GrupUyeModel
    {
        public int UyeId { get; set; }
        public Nullable<int> KullaniciId { get; set; }
        public Nullable<int> GrupId { get; set; }
        public Nullable<int> UyeYetki { get; set; }
    }
}