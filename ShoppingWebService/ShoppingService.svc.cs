﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShoppingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ShoppingService.svc or ShoppingService.svc.cs at the Solution Explorer and start debugging.
    public class ShoppingService : IShoppingService
    {
        ShoppingDBEntities context = new ShoppingDBEntities();

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(context.Products.Find(product.Id));
            context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetAProduct(int id)
        {
            return context.Products.SingleOrDefault(p => p.Id == id);
        }
    }
}
