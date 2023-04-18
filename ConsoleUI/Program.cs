using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductTest();

            //OrderTest();

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
            foreach (var orders in orderManager.GetAll())
            {
                Console.WriteLine(orders.ShipCity); // FARKLI ŞEHİRLERİ GETİRMEYİ ARAŞTIR, AYNILARINI GETİRMEMESİNİ SAĞLAMAYI ARAŞTIR.//
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetProductDetails())
            {
                Console.WriteLine(p.ProductName + " / " + p.CategoryName);
            }
        }
    }
}