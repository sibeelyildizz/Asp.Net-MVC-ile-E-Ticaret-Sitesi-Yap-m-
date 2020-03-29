using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Genders
    {
        public int Id { get; set; }
        public string Cinsiyet { get; set; }

        public List<Products> Ürünler { get; set; }
    }
}