using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var p in productManager.GetAllByUnitPrice(10,15))
            {
                Console.WriteLine(p.ProductName);
            }
        }
    }
}