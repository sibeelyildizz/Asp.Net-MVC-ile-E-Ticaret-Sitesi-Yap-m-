using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Brands
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public List<Products> Ürünler { get; set; }
    }
}