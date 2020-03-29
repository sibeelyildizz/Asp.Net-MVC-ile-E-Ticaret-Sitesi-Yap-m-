using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Towns
    {
        public int Id { get; set; }
        public string Ilce { get; set; }
        public int il_ID { get; set; }
        public List<Products> Ürünler { get; set; }        
    }
}