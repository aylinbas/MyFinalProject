using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //IEntity repositoryde yazdıklarımız ile burdaki get all add update gibi methodları yazmaya ihtiyacımız kalmıyor.
        //sadece IEntity repositoryden inherit etmemiz yetiyor
        //List<Product> GetAll();
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);
        //List<Product> GetAllByCategoryId(int categoryId);

        List<ProductDetailDto> GetProductDetails();
    }
}
