﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task_2
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            const string programName = "E-commerce Project\nSubmitted by Noa-Yarin Levi and Chen Brown";
            Manager manager = new Manager(programName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(programName + "\n");
            Console.ResetColor();

            const int EXIT = 8;
            int userSelection = 0;

            InitialData(manager);

            while (userSelection != EXIT)
            {
                Console.WriteLine();
                Console.WriteLine("---------------Menu----------------\n");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("(1) Add new buyer");
                Console.WriteLine("(2) Add new seller");
                Console.WriteLine("(3) Add product for seller");
                Console.WriteLine("(4) Add product to shopping cart");
                Console.WriteLine("(5) Pay order");
                Console.WriteLine("(6) Show buyers details");
                Console.WriteLine("(7) Show sellers details");
                Console.WriteLine("(8) EXIT");
                Console.Write("\nEnter your choice: ");
                userSelection = int.Parse(Console.ReadLine());

                switch (userSelection)
                {
                    case 1:
                        AddBuyer(manager);
                        break;
                    case 2:
                        AddSeller(manager);
                        break;
                    case 3:
                        AddProductToSeller(manager);
                        break;
                    case 4:
                        AddProductToCart(manager);
                        break;
                    case 5:
                        Payment(manager);
                        break;
                    case 6:
                        manager.ShowAllBuyers();
                        break;
                    case 7:
                        manager.ShowAllSellers();
                        break;
                    case 8:
                        Console.WriteLine("Goodbye :) ");
                        break;
                    default:
                        Console.WriteLine("Invalid option! try again");
                        break;
                }
            }
        }

        private static void InitialData(Manager manager)
        {
            Address addr1 = new Address("abc", 124, "Netanya", "ISR");

            manager.AddUserBuyer("tom", "54885!@", addr1);
            manager.AddUserBuyer("tomy", "5@4885!", addr1);

            manager.AddUserSeller("chen", "15@4885!", addr1);
            manager.AddUserSeller("alex", "54885!@", addr1);
            Category category =new Category();
            manager.AddNewProduct(new Product("Table", 54,category), "chen");
            manager.AddNewProduct(new Product("picture", 154, category), "chen");
            manager.AddNewProduct(new Product("monitor", 254, category), "alex");

            manager.AddProductToCart("tom", "chen", "Table");
            manager.AddProductToCart("tom", "alex", "monitor");
        }


        private static void AddBuyer(Manager manager)
        {
            string name = NameOfUser();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Address buyerAddr = GetAddress();
            if (!(manager.AddUserBuyer(name, password, buyerAddr)))
            {
                Console.WriteLine("\nBuyer not added, try again");
                return;
            }
            Console.WriteLine("\nBuyer successfully added!");

        }

        private static void AddSeller(Manager manager)
        {
            string name = NameOfUser();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Address sellerAddr = GetAddress();
            if (manager.AddUserSeller(name, password, sellerAddr))
            {
                Console.WriteLine("\nSeller successfully added!");
            }
            else
            {
                Console.WriteLine("\nSeller not added, try again");
            }
        }

        private static Address GetAddress()
        {
            Console.WriteLine("Enter street:");
            string street = Console.ReadLine();
            Console.WriteLine("Enter street number:");
            int streetNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter city:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter country:");
            string country = Console.ReadLine();

            return new Address(street, streetNumber, city, country);
        }


        static void AddProductToSeller(Manager manager)
        {
            Console.Write("Enter seller name: ");
            string sellerName = Console.ReadLine();
            Console.Write("Enter product name: ");
            string name = Console.ReadLine().ToLower();
            Console.Write("Enter product price: ");
            int price = int.Parse(Console.ReadLine());
            Category category = manager.AddCategory();
            if (category != null)
            {
                manager.AddNewProduct(new Product(name, price, false, 0, category), sellerName);
                Console.WriteLine("\nProduct successfully added!");
            }
            else
            {
                Console.WriteLine("\nProduct not added");
            }
        }


        static void AddProductToCart(Manager manager)
        {
            Console.Write("Enter a buyer name: ");
            string buyerName = Console.ReadLine();
            Console.Write("Enter a seller name: ");
            string sellerName = Console.ReadLine();
            Console.Write("Enter a product name: ");
            string productName = Console.ReadLine().ToLower();
            Console.Write("Do you want add a special package? [Yes / No]: ");
            string specialBoxStr = Console.ReadLine();
            bool isSpecialBox = false;
            int extraPrice = 0;
            if (specialBoxStr.ToLower() == "yes")
            {
                isSpecialBox = true;
                Console.Write("How much is it to add a package box? ");
                extraPrice = int.Parse(Console.ReadLine());
            }
            else if (specialBoxStr.ToLower() == "no")
            {
                isSpecialBox = false;
            }

            if (manager.AddProductToCart(buyerName, sellerName, productName))
                Console.WriteLine("\nProduct successfully added!");
            else
                Console.WriteLine("\nProduct not added");
        }

        static void Payment(Manager manager)
        {
            string name = NameOfUser();
            if (!manager.PaymentCart(name))
            {
                Console.WriteLine("\nInvalid name");
            }
            else
            {
                Console.WriteLine("\nOrder completed");
            }
        }

        static string NameOfUser()
        {
            Console.Write("Enter name of user: ");
            return (Console.ReadLine()).ToLower();
        }
    }
}