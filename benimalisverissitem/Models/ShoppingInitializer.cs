using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class ShoppingInitializer: DropCreateDatabaseIfModelChanges<ShoppingContext>
    /*CreateDatabaseIfNotExists<ShoppingContext>*/
    //DropCreateDatabaseIfModelChanges<ShoppingContext>
    {
        protected override void Seed(ShoppingContext context)
        {
            base.Seed(context);

        }
    }
}