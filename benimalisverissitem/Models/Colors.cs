using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Colors
    {
        public int Id { get; set; }
        public string Renk { get; set; }
        public List<Products> Ürünler { get; set; }
    }
}