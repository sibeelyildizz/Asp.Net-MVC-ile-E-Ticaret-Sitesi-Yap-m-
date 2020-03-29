using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class ShippingDetails
    {

        [DisplayName("Kullanıcı:")]
        public string Username { get; set; }
        [DisplayName("Adınız:")]
        public string ad { get; set; }
        [DisplayName("Soyadınız:")]
        public string soyad { get; set; }
        [DisplayName("Mağaza:")]
        public string Magaza { get; set; }
        public Products Products { get; set; }

        [Required(ErrorMessage = "Lütfen adres tanımını giriniz.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen semt giriniz.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen mahalle giriniz.")]
        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }
    }
}