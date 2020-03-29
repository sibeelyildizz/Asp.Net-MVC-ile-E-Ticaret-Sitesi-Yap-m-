using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Products
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string Barkod { get; set; }
        public System.DateTime eklenmeTarihi { get; set; }
        public string Aciklama { get; set; }
        public int KategoriId { get; set; }
        public Categories Category { get; set; }
        public int MarkaID { get; set; }
        public Brands Brand { get; set; }
        public int BedenID { get; set; }
        public Sizes Size { get; set; }
        public int RenkID { get; set; }
        public Colors Color { get; set; }
        public int CinsiyetID { get; set; }
        public Genders Gender { get; set; }
        public string Resim { get; set; } 
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public int Fiyat { get; set; }
        public int Il_ID { get; set; }
        public Cities City{ get; set; }
        public int Ilce_ID { get; set; }
        public Towns Town { get; set; }
        public Nullable<int> IndirimID { get; set; }
        public Discounts Discount { get; set; }
    }
}