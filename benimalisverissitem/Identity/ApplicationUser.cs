using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; internal set; }
        public object StoreName { get; internal set; }
        public string Address { get; set; }
    }
}