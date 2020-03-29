using benimalisverissitem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace benimalisverissitem.Models
{
    public class Cart
    {
        private List<CartLine> _cardLines = new List<CartLine>();

        public List<CartLine> CartLines
        {
            get { return _cardLines; }

        } 
        //sepete ürün ekleme
        public void AddProduct(Products products, int quantity)
         {
            var line = _cardLines.FirstOrDefault(i => i.Products.Id == products.Id);

            //ürün sepete ilk kez eklenecekse
            if (line == null)
            {
                _cardLines.Add(new CartLine() { Products  = products, Quantity = quantity });
            }

            else //sepette o ürün var
            {
                line.Quantity += quantity;
            }
        }

        //sepetten ürün silme
        public void DeleteProduct( Products products)
        {
            _cardLines.RemoveAll(i => i.Products.Id == products.Id);
        }
        //sepet tutarı
        public double Total()
        {
            return _cardLines.Sum(i => i.Products.Fiyat * i.Quantity);
        }

        //sepeti boşaltma
        public void Clear()
        {
            _cardLines.Clear();
        }

    }
    public class CartLine
    { 
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
    }
}