using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingWebService
{
    [MetadataType(typeof(ColumnProperty))]
    public partial class Product
    {

    }

    public class ColumnProperty
    {
        [Key]
        public int Id { get; set; }
    }
}