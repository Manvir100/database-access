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
            context.Products.Add(product); //adds a product to the Product table
            context.SaveChanges(); //save those changes
        }
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void AddUserInfos(UserInfo userInfo)
        {
            context.UserInfoes.Add(userInfo);
            context.SaveChanges();
        }

        //remove a product from the Product table
        public void DeleteProduct(int id)
        {
            context.Products.Remove(context.Products.Find(id)); //first find the product by ID then remove the product from table
            context.SaveChanges(); //save those changes
        }
        public void DeleteUser(int id)
        {
            context.Users.Remove(context.Users.Find(id));
            context.SaveChanges();
        }
        public void DeleteUserInfos(int id)
        {
            context.UserInfoes.Remove(context.UserInfoes.Find(id)); 
            context.SaveChanges();
        }

        //edit a product from the Product table
        public void EditProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified; //Using EntityState to find what was modified from the old state and change the state
            context.SaveChanges(); //save those changes
        }

        public void EditUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void EditUserInfos(UserInfo userInfo)
        {
            context.Entry(userInfo).State = EntityState.Modified;
            context.SaveChanges();
        }
        //Returns all products in the Products table
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList(); //returns the Products table to a list
        }
        //Returns all user in the Users table
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }        
        //Returns all userinfos in the Userinfo table
        public List<UserInfo> GetAllUserInfos()
        {
            return context.UserInfoes.ToList();
        }
        //Returns a product based on it's id from the Product table
        public Product GetAProduct(int id)
        {
            return context.Products.SingleOrDefault(p => p.Id == id); //find a product based on it's ID
        }
        public User GetAUser(int id)
        {
            return context.Users.SingleOrDefault(p => p.Id == id);
        }
        public UserInfo GetAUserInfos(int id)
        {
            return context.UserInfoes.SingleOrDefault(p => p.Id == id);
        }
        public User GetUserByUsername(string username)
        {
            return context.Users.SingleOrDefault(u => u.Username == username);
        }

        //get products greater than and equal to price from the Product table
        public List<Product> GetProductsGreaterThanOrEqualToPrice(double price)
        {
            return context.Products.Where(p => p.Price >= price).Select(p => p).ToList(); //return products that have a greater or equal price to a list
        }
    }
}
