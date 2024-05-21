﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task_2
{
    internal class Product
    {
        private string name;
        private int price;
        private Category category;
        private bool hasSpecialBox;
        private int extraPrice;
        public Product(string _name,int _price) { 
            this.name = _name;
            this.price = _price;
            SetPrice(_price);
        }

        public Product(string _name, int _price, bool _hasSpecialBox, int _extraPrice)
        {
            this.name = _name;
            this.price = _price;
            this.hasSpecialBox = _hasSpecialBox;
            this.extraPrice = _extraPrice;
            SetPrice(_price);
        }

        public Product(Product _product) 
        {
            this.name = _product.name;
            this.price = _product.price;
            this.hasSpecialBox = _product.hasSpecialBox;
            this.extraPrice = _product.extraPrice;
            SetPrice(_product.price);
        }

        public bool SetPrice(int price)
        {
            if (price <= 0)
            {
                Console.WriteLine("Invalid price");
                return false;
            }
            this.price = price;
            return true;
        }

        public string GetProductName() { return  name; }
        public int GetPrice() { return price; }
        public bool GetHasSpecialBox() { return hasSpecialBox; }
        public int GetExtraPrice() {  return extraPrice; }

        public string ToString()
        {
            return $"\t- product name: {name}, price: {price}, category: {category}, special box: {hasSpecialBox}, extra price: {extraPrice}";
        }
    }
}
