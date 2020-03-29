using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string SiparisNo { get; set; }
        public double Toplam { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public EnumOrderState SiparisDurumu { get; set; }
    }
}