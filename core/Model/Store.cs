using core.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            int newCount = Products.Length - 1;
            Product[] NewArr = new Product[newCount];
            int index = 0;
            bool found = false;

            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Id != id)
                {
                    if (index < newCount) NewArr[index++] = Products[i];
                }
                else
                {
                    found = true;
                    Console.WriteLine($"Id:{id} ile mehsul silindi");
                }
            }

            if (!found)
            {
                Console.WriteLine($"Id:{id} ile mehsul tapilmadi");
                return Products;
            }

            Products = NewArr;
            return Products;
        }

        public void GetProduct(int id)
        {
            bool found = false;

            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Id == id)
                {
                    Console.WriteLine($"Id:{id} Name:{Products[i].Name} Price:{Products[i].Price}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Id:{id} ile mehsul tapilmadi");
            }
        }

        public Product[] FilterProductByName(string name)
        {
            int count = 0; 
            for(int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Name == name)
                {
                    count++; 
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"{name} tipində məhsul tapılmadı");
                return new Product[0];
            }

            Product[] FilteredProducts = new Product[count];
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
            int count = 0;
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Type == type)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"{type} tipində məhsul tapılmadı");
                return new Product[0];
            }

            Product[] FilteredProducts = new Product[count];
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
        public void ShowFullInfo()
        {
            foreach(var item in Products)
            {
                Console.WriteLine($"Id:{item.Id} Name:{item.Name} Price:{item.Price} Type:{item.Type}");
            }
        }
    }
}
