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

            OrderTest();

            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            Console.WriteLine(categoryManager.GetById(3).CategoryName);
        }

        private static void OrderTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            
            var uniqueCities = new HashSet<string>(); //Unique elements: A HashSet<T> stores a collection of unique elements, meaning that each element is stored only once.

            foreach (var orders in orderManager.GetAll())
            {
                uniqueCities.Add(orders.ShipCity);
            }

            foreach (var cities in uniqueCities)
            {
                Console.WriteLine(cities);
            }

            //foreach (var orders in orderManager.GetAll().Select(o=> o.ShipCity).Distinct())
            //{
                
            //    Console.WriteLine(orders);

            //}
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var p in result.Data)
                {
                    Console.WriteLine(p.ProductName + " / " + p.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}