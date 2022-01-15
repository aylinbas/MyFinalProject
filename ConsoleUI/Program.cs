﻿using Business.Concrete;
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
            ProductManager productManager = new ProductManager(new EfProductDal());
        
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("**************************");
            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("**************************");
            foreach (var product in productManager.GetByUnitPrice(2,100))
            {
                Console.WriteLine(product.ProductName);
            }


            Console.WriteLine("Hello World!");
        }
    }
}
