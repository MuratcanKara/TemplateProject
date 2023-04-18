using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            OrderManager orderManager = new OrderManager(new EfOrderDal());
            orderManager.GetById(2);

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            Console.WriteLine(categoryManager.GetById(3).CategoryName);
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetAllByUnitPrice(10, 15))
            {
                Console.WriteLine(p.ProductName);
            }
        }
    }
}