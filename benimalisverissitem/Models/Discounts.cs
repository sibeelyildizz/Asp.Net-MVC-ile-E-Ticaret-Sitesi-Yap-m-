using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Discounts
    {
        public int Id { get; set; }
        public int Indirim { get; set; }

        public List<Products> Ürünler { get; set; }
    }
}