using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal() //constructor
        {
            //Dbden geliyor gibi
            _products = new List<Product> { 
                new Product{ ProductId=1,CategoryId=1,ProductName="Defter", UnitPrice=15,UnitsInStock=1000},
                new Product{ ProductId=2,CategoryId=1,ProductName="Kalem", UnitPrice=10,UnitsInStock=10000},
                new Product{ ProductId=3,CategoryId=1,ProductName="Silgi", UnitPrice=5,UnitsInStock=100},
                new Product{ ProductId=4,CategoryId=2,ProductName="Telefon", UnitPrice=5000,UnitsInStock=100},
                new Product{ ProductId=5,CategoryId=2,ProductName="Laptop", UnitPrice=20000,UnitsInStock=80},
                new Product{ ProductId=6,CategoryId=2,ProductName="Klavye", UnitPrice=150,UnitsInStock=120},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product) diyerek silinmez.
            //çünkü parametre olarak gelen referans ile products listesindeki aynı özelliklere sahip product aynı referansta tutulmuyor.

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.ProductId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
