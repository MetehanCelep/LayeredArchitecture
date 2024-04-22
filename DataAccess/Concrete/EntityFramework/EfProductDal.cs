using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto 
                             { ProductId=p.ProductId,
                               CategoryName = c.CategoryName,
                               ProductName=p.ProductName,
                               UnitsInStock=p.UnitsInStock
                             } ;
                //LINQ te ürünler ve kategorileri eğer ürünün CategoryId si ve kategorinin CategoryId si eşit ise join et demek.
                return result.ToList();
            }
        }
    }
}
