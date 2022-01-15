using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            return _productDal.GetAll();//hangi productdal geldiyse onun getAll methodu çalışacak.
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
