﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server, Postgres ...
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera",UnitPrice=500,UnitInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon",UnitPrice=1500,UnitInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye",UnitPrice=150,UnitInStock=65},
                new Product{ProductId=5, CategoryId=3, ProductName="Fare",UnitPrice=85,UnitInStock=1}
            };
        }

        public void Add(Product product)
        {
               _products.Add(product);
        }

        public void Delete(Product product)
        {
            /* Normal Yöntem
             Product producToDelete=null;
            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    producToDelete = p;
                }
            }
            _products.Remove(producToDelete);*/

            //LINQ
            Product producToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(producToDelete);

        }

        public List<Product> Getall()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
            // Gönderilen ürün id'sine sahip olan listedeki ürünü bul
            Product producToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            producToUpdate.ProductName=product.ProductName;
            producToUpdate.ProductId=product.ProductId; 
            producToUpdate.UnitPrice=product.UnitPrice; 
            producToUpdate.UnitInStock=product.UnitInStock;


        }
    }
}
