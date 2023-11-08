using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //Claim
        //Password's must be hashed! (MD5, SHA1 etc.) /There is no way to return it.
        //Hashing : storing datas as unreadable things. It even gives different hashes to same datas.
        //Salting : Empowering the data that users enter.
        //Rainbow table : A way to break into an account through using Hash datas that already exist.
        //Encryption : These datas can be returned back to their original forms. They can be reached by true key(s).

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //if (_productDal.GetByMemberOfCategories(product))
            //{
            //    _productDal.Add(product);
            //    return new SuccessResult(Messages.ProductAdded);
            //}
            //else
            //{
            //    return new ErrorResult();
            //}

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategory(product.CategoryId),CheckIfProductsNamesSameOrNot(product.ProductName),
                CheckIfCategoryExceeded(product.CategoryId));

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==19)
            {
                return new DataErrorResult<List<Product>>(Messages.MaintenanceTime);
            }
            
            return new DataSuccessResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed); 
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return new DataSuccessResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new DataSuccessResult<List<Product>>(_productDal.GetAll(p=>max >= p.UnitPrice && p.UnitPrice >=min),Messages.ProductsListed);
        }


        public IDataResult<Product> GetById(int Id)
        {
            return new DataSuccessResult<Product>(_productDal.Get(p => p.ProductId == Id),Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new DataSuccessResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        private IResult CheckIfProductCountOfCategory(int categoryId)
        {
            var quantity = _productDal.GetAll(p=>p.CategoryId == categoryId).Count();
            if (quantity > 10)
            {
                return new ErrorResult(Messages.CheckProductCountOfCategoryErr);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductsNamesSameOrNot(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName);
            if (result.IsNullOrEmpty())
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CheckProductsNamesSameOrNotErr);
        }

        //private IResult CheckIfCategoriesReachedLimit(int categoryId)
        //{
        //    var instance = (ICategoryService)Activator.CreateInstance(typeof(CategoryManager));
        //    var quantity = instance.GetAll().Data.Where(c => c.CategoryId == categoryId).Count();
        //    if (quantity > 15)
        //    {
        //        return new ErrorResult(Messages.OutOfCategoryLimit);
        //    }
        //    return new SuccessResult();
        //}

        private IResult CheckIfCategoryExceeded(int categoryId)
        {
            var quantity = _categoryService.GetAll().Data.Where(c => c.CategoryId == categoryId).Count();
            if (quantity > 15)
            {
                return new ErrorResult(Messages.OutOfCategoryLimit);
            }
            return new SuccessResult();
        }

    }
}
