using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        //çağırıldığı yerden hangi peoductDal gönderilirse onun referansını tutabilecek interface verdiğimiz için
        //InMemory de olabilir EntityFramework de olabilir dapper da olabilir daha sonraki zamanlarda 
        //ama burda bir şey değiştirmene gerek kalmaz.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded); //new SuccessResult(); da verilebilirdi.
               
            }
            catch(Exception e)
            {
                return new ErrorResult(e.Message); //new ErrorResult() da olabilirdi.
                {

                };
            }
           
        }

        public IDataResult<List<Product>> GetAll()
        {
            var control = true;
            if (!control)
            {
                return new ErrorDataResult<List<Product>>(Messages.DefaultError);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);//hangi productdal geldiyse onun getAll methodu çalışacak.
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            try {
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
            }
            catch(Exception e)
            {
                return new ErrorDataResult<List<Product>>();
            }
           
        }

        public IDataResult<Product> GetById(int productId)
        {
            try
            {
                return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
            }
            catch(Exception e)
            {
                return new ErrorDataResult<Product>();
            }
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            try
            {
                return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
            }
            catch(Exception e)
            {
                return new ErrorDataResult<List<Product>>();
            }
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            try
            {
                return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails());
            }
            catch(Exception e)
            {
                return new ErrorDataResult<List<ProductDetailDto>>();
            }
           
        }
    }
}
