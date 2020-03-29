using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Sizes
    {
        public int Id { get; set; }
        public string Beden{ get; set; }
        public List<Products> Ürünler { get; set; }
    }
}