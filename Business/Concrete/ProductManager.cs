﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        private IProductDal _productDal;

        public ProductManager()
        {
            _productDal = new EfProductDal();
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Product>>();
            }
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            var result = _productDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Product>();
            }
            return new SuccessDataResult<Product>(result, Messages.ProductGeted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<ProductDto>> GetAllByDto()
        {
            var result = _productDal.GetProductDtos();
            if (result == null)
            {
                return new ErrorDataResult<List<ProductDto>>();
            }
            return new SuccessDataResult<List<ProductDto>>(result, Messages.ProductsListed);
        }
    }
}
