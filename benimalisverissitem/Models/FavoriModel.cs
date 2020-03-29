using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class FavoriModel
    {
        private List<Favorites> favorites = new List<Favorites>();
        public int Id { get; set; }
        public string Username { get; set; }


        public int Products_Id1 { get; set; }
        public Products Products { get; set; }
    }
}