using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product has been added";
        public static string ProductNameInvalid = "Product's name is invalid";
        public static string ProductsListed = "Product(s) have been listed";
        public static string MaintenanceTime = "The system was closed";
        public static string CheckProductCountOfCategoryErr= "The highest limit has been exceeded!";
        public static string CheckProductsNamesSameOrNotErr = "There's already a product with the same name!";
        public static string OutOfCategoryLimit = "The category has reached its limit!";
    }
}
