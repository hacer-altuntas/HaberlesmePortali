using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberlesmePortali.ViewModels
{
    public class MesajModel
    {
        public int MesajId { get; set; }
        public string İcerik { get; set; }
        public Nullable<int> GonderenId { get; set; }
        public Nullable<int> GrupId { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<int> Okunma { get; set; }
        public List<AlicilarModel> AliciBilgi { get; set; }
    }
}