using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var product in productManager.GetByUnitPrice(50,75))
            {
                Console.WriteLine(product.ProductName + "\n");
            }
            foreach(var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
            
        }
    }
}