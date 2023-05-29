using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==20)
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
    }
}
