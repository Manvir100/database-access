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
        //Returns a product based on it's id from the Product table
        Product GetAProduct(int id);

        [OperationContract]
        //add a product to the Product table
        void AddProduct(Product product);

        [OperationContract]
        //edit a product from the Product table
        void EditProduct(Product product);

        [OperationContract]
        //remove a product from the Product table
        void DeleteProduct(Product product);

        [OperationContract]
        //get products based on price from the Product table
        List<Product> GetProductsByPrice(double price);
    }
}
