﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShoppingService" in both code and config file together.
    [ServiceContract]
    public interface IShoppingService
    {
        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        Product GetAProduct(int id);

        [OperationContract]
        void AddProduct(Product product);

        [OperationContract]
        void EditProduct(Product product);

        [OperationContract]
        void DeleteProduct(Product product);
    }
}
