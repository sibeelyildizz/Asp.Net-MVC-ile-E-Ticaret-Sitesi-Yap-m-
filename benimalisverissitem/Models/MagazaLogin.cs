﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class MagazaLogin
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }


        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}