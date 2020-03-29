using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Cities
    {
        public int Id { get; set; }
        public string Il { get; set; } 
        public List<Products> Ürünler { get; set; }
        public List<Towns> İlçeler { get; set; }
    }
}