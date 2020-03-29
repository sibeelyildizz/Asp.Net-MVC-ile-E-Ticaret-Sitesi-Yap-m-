using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{

    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string SiparisNo { get; set; }
        public double Toplam { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public EnumOrderState SiparisDurumu { get; set; }

        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        public virtual List<OrderLineModel> Orderlines { get; set; }
    }

    public class OrderLineModel
    {
        public int Products_Id { get; set; }
        public string UrunAdi{ get; set; }
        public string Resim { get; set; }
        public int Quantity { get; set; }
        public double Fiyat { get; set; }
    }
}