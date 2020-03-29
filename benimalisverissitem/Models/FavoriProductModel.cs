using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class FavoriProductModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Products_Id1 { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int Fiyat { get; set; }
        public string Resim { get; set; }
      //  public Products Products { get; set; }
    }
}