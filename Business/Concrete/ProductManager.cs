﻿using Business.Abstract;
using Business.Constatns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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
        private EfCategoryDal efCategoryDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public ProductManager(EfCategoryDal efCategoryDal)
        {
            this.efCategoryDal = efCategoryDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded);
        }
        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 14)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintnenaceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetByID(int ProductId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == ProductId));
            //Burada fonksiyon list döndürmüyor, Product döndürüyor. Bu yüzden GetAll yerine Get kullandık.
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice > min && p.UnitPrice < max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


    }
}
