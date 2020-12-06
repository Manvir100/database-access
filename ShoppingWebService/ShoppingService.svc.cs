using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

/*
 * Edit by Harvey Ho
 * December 12 2020, 6:18pm EST
 */

namespace ShoppingWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShoppingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ShoppingService.svc or ShoppingService.svc.cs at the Solution Explorer and start debugging.
    public class ShoppingService : IShoppingService
    {
        ShoppingDBEntities context = new ShoppingDBEntities();

        //add a product to the Product table
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        //remove a product from the Product table
        public void DeleteProduct(Product product)
        {
            context.Products.Remove(context.Products.Find(product.Id));
            context.SaveChanges();
        }

        //edit a product from the Product table
        public void EditProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

        //Returns all products in the Products table
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        //Returns a product based on it's id from the Product table
        public Product GetAProduct(int id)
        {
            return context.Products.SingleOrDefault(p => p.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return context.Users.SingleOrDefault(u => u.Username == username);
        }

        //get products greater than and equal to price from the Product table
        public List<Product> GetProductsGreaterThanOrEqualToPrice(double price)
        {
            return context.Products.Where(p => p.Price >= price).Select(p => p).ToList();
        }
    }
}
