using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext() : base("alisverisSitesiDb")
        {
            Database.SetInitializer(new ShoppingInitializer());
           
        }
        public DbSet<Products> Ürünler { get; set; }
        public DbSet<Categories> Kategoriler { get; set; }
        public DbSet<Genders> Cinsiyetler { get; set; }
        public DbSet<Brands> Markalar { get; set; }
        public DbSet<Sizes> Bedenler { get; set; }
        public DbSet<Colors> Renkler { get; set; }
        public DbSet<Stores> Magazalar { get; set; }
        public DbSet<Discounts> Indirimler { get; set; }
        public DbSet<Cities> Iller { get; set; }
        public DbSet<Towns> Ilceler { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<Favorites> Favorites { get; set; }
       



    }
}