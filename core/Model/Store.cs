using core.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Type = core.Helper.Enum.Type;

namespace core.Model
{
    public class Store
    {
        public string Name { get; set; }    
        public Product[] Products;
        public Store(string name)
        {
            Name = name;
            Products = new Product[0];
        }
        public Product[] AddProducts(params Product[] products)
        {
            int oldCount = Products.Length; 
            Product[] newProducts = new Product[Products.Length+ products.Length];
            for (int i = 0; i < Products.Length; i++) 
            {
                newProducts[i] = Products[i]; 
            }
            for (int i = 0; i < products.Length; i++)
            {
                newProducts[oldCount + i] = products[i];
            }
            Products = newProducts;
            return newProducts;
        }
        public Product[] RemoveProduct(int id)
        {
            Product[] removedProducts = new Product[Products.Length - 1];
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Id != id) 
                {
                    removedProducts[i] = Products[i];
                }
                else
                {
                    Console.WriteLine($"Id:{id} Name:{Products[i].Name} Price:{Products[i].Price} Product-u silindi");
                }
            }
            Products = removedProducts;
            return Products;
        }
        public void GetProduct(int id)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Id == id)
                {
                    Console.WriteLine($"Id:{id} Name:{Products[i].Name} Price:{Products[i].Price}");
                    break; 
                }
            }
        }
        public Product[] FilterProductByName(string name)
        {
            Product[] FilteredProducts = new Product[Products.Length];
            int index = 0; 
            for (int i = 0;i < Products.Length;i++)
            {
                if(Products[i].Name == name)
                {
                    FilteredProducts[index++] =  Products[i];
                }
               
            }
            Products = FilteredProducts; 
            return Products;
        }
        public Product[] FilterProductByType(Type type)
        {
            Product[] FilteredProducts = new Product[Products.Length];
            int index = 0;
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Type == type)
                {
                    FilteredProducts[index++] = Products[i];
                }

            }
            Products = FilteredProducts;
            return Products;
        }
    }
}
