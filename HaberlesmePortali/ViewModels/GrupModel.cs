using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberlesmePortali.ViewModels
{
    public class GrupModel
    {
        public int GrupId { get; set; }
        public string GrupAdi { get; set; }
        public string Hakkinda { get; set; }
        public string GrupResim { get; set; }
        public List<GrupUyeModel> UyeBilgi { get; set; }
    }
}