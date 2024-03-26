using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductMenager productManager = new ProductMenager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(50,75))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}