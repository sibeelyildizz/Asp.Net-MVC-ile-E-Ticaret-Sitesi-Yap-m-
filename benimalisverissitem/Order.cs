using benimalisverissitem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem
{
    public class Order
    {

        public int Id { get; set; }
        public string SiparisNo { get; set; }
        public double Toplam { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public EnumOrderState SiparisDurumu { get; set; }

        public string Username { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
        public string Magaza { get; set; }

        public Products Products { get; set; }
     
     
        public virtual List<OrderLine> Orderlines { get; set; }
    }

    public class OrderLine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int Quantity { get; set; }

        public double Fiyat { get; set; }

        public int Products_Id { get; set; }

        public string barkod { get; set; }

        public string magaza { get; set; }
        
        public virtual Products Products { get; set; }

    }
}