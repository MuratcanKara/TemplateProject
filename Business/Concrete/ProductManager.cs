using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>max >= p.UnitPrice && p.UnitPrice >=min);
        }
    }
}
