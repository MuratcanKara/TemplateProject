using Core.Entities.Concrete;
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
        public static string AuthorizationDenied = "You have not been authorizated!";
        public static string UserRegistered = "User has been registered succesfully!";
        public static string UserNotFound = "User is not found!";
        public static string PasswordError = "Password is incorrect!";
        public static string SuccessfulLogin = "Login has been emerged!";
        public static string UserAlreadyExists = "That user is already exist!";
        public static string AccessTokenCreated = "Access Token has been created successfully!";
    }
}
