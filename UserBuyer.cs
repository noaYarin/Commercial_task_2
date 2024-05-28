﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class UserBuyer
    {

        private string name;
        private string password;
        private Address address;
        private Order[] orders;
        private Product[] products;
        private int size = 2;
        private int productSizeLogic = 0;

        public UserBuyer(){
            products = new Product[size];
        }
        public UserBuyer(string name, string password, Address address)
        {
            SetBuyer(name, password, address);
        }
        public UserBuyer(UserBuyer other)
        {
            SetBuyer(other.name, other.password, other.address);
         }

        public string GetBuyerName() { return name; }
        public string GetBuyerCity() { return address.GetCity(); }

        public Product[] GetProductsArr() { return products; }
      

        public bool SetBuyer(string name, string password, Address address)
        {
            if (SetName(name) && SetPassword(password))
            {
                this.address = new Address(address); 
                this.name = name;
                return true;
            }
            return false;
        }

        public bool SetOrderArr(UserBuyer _UserBuyer)
        {
            Order[] newOrder;
            
            if (orders == null)
            {
                orders = new Order[1];
            }
            else
            {
                newOrder = new Order[orders.Length + 1];
                orders.CopyTo(newOrder, 0);
                orders = newOrder;
            }

            this.orders[orders.Length - 1] = new Order(_UserBuyer, products, productSizeLogic);
            return true;
        }


        public bool SetName(string name)
        {
            if (name != null && !Validation.IsContainDigit(name) && name.Length < 10)
            {
                return true;
            }
            return false;
        }


        public bool SetPassword(string password)
        {
           return Validation.IsValidPassword(password);
        }

        public void ToStringAllProducts()
        {
            if(products != null)
            {
                foreach (var productDetail in products)
                {
                    if(productDetail != null)
                        Console.WriteLine(productDetail.ToString());
                }
            }
        }

        public void ToStringHistoryProducts()
        {
            if(orders!= null)
            {
                Console.WriteLine("\tHistrory shopping:");
                foreach (var order in orders)
                {
                    Console.WriteLine(order.ToString());
                    order.HistroyCart();
                }
            }
        }

        public bool RemoveAllCartProducts()
        {
            for(int i = 0; i< products.Length; i++)
            {
                products[i] = null;
            }
            productSizeLogic = 0;
            return true;
        }


        public int GetPriceCart()
        {
            int priceCart = 0;
            if (products != null)
                foreach (Product productDetail in products)
                {
                    priceCart += productDetail.GetPrice();
                }
            return priceCart;
        }


        public bool SetProduct(Product productDetails)
        {
            Product[] tempNewProducts;
           if(productSizeLogic==products.Length)
            {
                tempNewProducts = new Product[products.Length * size];
                products.CopyTo(tempNewProducts, 0);
                products = tempNewProducts;

            }
            products[productSizeLogic] = productDetails;
            productSizeLogic++;
            return true;
        }

        public string ToString()
        {
            return "Customer name: " + name +", Address: " + address.ToString();
        }
    }
}
