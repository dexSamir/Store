﻿using core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class Product
    {
        private static int _id = 0; 
        private string _name;
        private double _price;
        private Helper.Enum.Type _type;

        public int Id { get ; private set;  }
        public string Name { get; set; }
        public Helper.Enum.Type Type { get; set; }

        public double Price {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new PriceMustBeGratherThanZeroException("Qiymet 0-dan kicik ola bilmez"); 
                }
                else
                {
                    _price = value; 
                }
            }
        }
        public Product(string name, double price,  Helper.Enum.Type type )
        {
            _id++; 
            Id = _id;
            Name = name;
            Price = price; 
            Type = type;
        }
        public void ShowFullInfo()
        {
            Console.WriteLine($"Id:{Id} Name:{Name} Price:{Price} Type:{Type}\n");
        }
    }
}
