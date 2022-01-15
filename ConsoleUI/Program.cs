using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal()); //burada daha sonra inMemory değil entityFramework verse
            //onun kodları çalışacak.
            //Business katmanında hiçbir değişiklik yapmana gerek kalmayacak.
           // ProductTest();
            Console.WriteLine("**************************");
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach(var category in categoryManager.GetAll()) {
                Console.WriteLine(category.CategoryName);
            }


        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }

            foreach (var product in productManager.GetByUnitPrice(2, 100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
