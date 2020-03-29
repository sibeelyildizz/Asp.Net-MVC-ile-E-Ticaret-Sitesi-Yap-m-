using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace benimalisverissitem.Models
{
    public class ililceviewmodel
    {
        public ililceviewmodel()
        {
            this.IlceList = new List<SelectListItem>();
            IlceList.Add(new SelectListItem { Text = "Seçiniz.", Value = "" });
        }
        public int ilId { get; set; }
      
        public int ilceId { get; set; }
        public List<SelectListItem> SehirList { get; set; }
        public List<SelectListItem> IlceList { get; set; }

    }
}