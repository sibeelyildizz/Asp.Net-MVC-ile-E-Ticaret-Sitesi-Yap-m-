using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class TownModel
    {
        public int Id { get; set; }
        public string kategoriAdi { get; set; }

        public List<Products> Ürünler { get; set; }
        public List<Cities> İller { get; set; }

    }
}