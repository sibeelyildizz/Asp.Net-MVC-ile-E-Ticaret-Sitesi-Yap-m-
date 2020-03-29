using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Stores
    {
        public int Id { get; set; }
        public string Magaza  { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string  Adres { get; set; }
        public List<Products> Ürünler { get; set; }
        public string KullaniciAdi { get; set; }
    }
}