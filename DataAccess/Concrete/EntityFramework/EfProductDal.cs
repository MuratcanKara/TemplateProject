﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        //public bool GetByMemberOfCategories(Product product)
        //{
        //    using (NorthwindContext context = new NorthwindContext())
        //    {
        //        var quantityOfCategories = context.Set<Product>().Select(p => p.CategoryId).Count();

        //        if (quantityOfCategories >10)
        //        {
        //            throw new Exception("New item(s) cannot be added because of the max limit of each categories!");                 
        //        }
        //        else
        //        {
        //            return true;
        //        }             
        //    }


        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };
                return result.ToList();
            }
        }
    }
}  

