using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Favorites
    {
        private List<Favorites> favorites = new List<Favorites>();
        
        public int Id { get; set; }
        public string Username { get; set; }
        
        public string UrunAdi { get; set; }
        
        public string Aciklama { get; set; }
        public int Fiyat { get; set; }
        public string Resim { get; set; }

        [Index(IsUnique = true)]
        public int Products_Id1 { get; set; }
        public Products Products { get; set; }
    }
 

}