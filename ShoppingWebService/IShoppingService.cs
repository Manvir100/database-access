using System;
using System.Collections.Generic;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShoppingService" in both code and config file together.
    [ServiceContract]
    public interface IShoppingService
    {
        [OperationContract]
        //Returns all products in the Products table
        List<Product> GetAllProducts();

        [OperationContract]
        //Returns all users in the User table
        List<User> GetAllUsers();

        [OperationContract]
        //Returns all userinfos in the Userinfo table
        List<UserInfo> GetAllUserInfos();
            
        [OperationContract]
        //Returns a product based on it's id from the Product table
        Product GetAProduct(int id);

        [OperationContract]
        //Returns a product based on it's id from the Product table
        User GetAUser(int id);

        [OperationContract]
        //Returns a product based on it's id from the Product table
        UserInfo GetAUserInfos(int id);

        [OperationContract]
        //add a product to the Product table
        void AddProduct(Product product);

        [OperationContract]
        //add a product to the Product table
        void AddUser(User user);

        [OperationContract]
        //add a product to the Product table
        void AddUserInfos(UserInfo userInfo);

        [OperationContract]
        //edit a product from the Product table
        void EditProduct(Product product);

        [OperationContract]
        //edit a product from the Product table
        void EditUser(User user);

        [OperationContract]
        //edit a product from the Product table
        void EditUserInfos(UserInfo userInfo);

        [OperationContract]
        //remove a product from the Product table
        void DeleteProduct(int id);

        [OperationContract]
        //remove a product from the Product table
        void DeleteUser(int id);

        [OperationContract]
        //remove a product from the Product table
        void DeleteUserInfos(int id);

        [OperationContract]
        //get a users account information by inputting a username
        User GetUserByUsername(string username);

        [OperationContract]
        //get products greater than and equal to price from the Product table
        List<Product> GetProductsGreaterThanOrEqualToPrice(double price);
    }
}
