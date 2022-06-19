using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberlesmePortali.ViewModels
{
    public class AlicilarModel
    {
        public int AliciId { get; set; }
        public Nullable<int> KullaniciId { get; set; }
        public Nullable<int> MesajId { get; set; }
    }
}