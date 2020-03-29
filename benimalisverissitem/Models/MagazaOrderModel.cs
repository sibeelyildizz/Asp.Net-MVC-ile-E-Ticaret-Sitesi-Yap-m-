using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class MagazaOrderModel
    {
        public int Id { get; set; }
        public string SiparisNo { get; set; }
        public double Toplam { get; set; }
        public double Count { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public EnumOrderState SiparisDurumu { get; set; }
        public string  Username { get; set; }
        public string Magaza { get; set; }



        public Stores Products { get; set; }
        public string MagazaId { get; set; }

}
}