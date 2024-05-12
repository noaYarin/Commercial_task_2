using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string programName = "Commercial";
            Manager manager = new Manager(programName);
            const int EXIT = 8;
            int userSelection = 0;

            initiateData(manager); // Template Data

            while (userSelection != EXIT)
            {
                Console.WriteLine();
                Console.WriteLine("---------Menu---------");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("(1) Add new buyer");
                Console.WriteLine("(2) Add new seller");
                Console.WriteLine("(3) Add product for seller");
                Console.WriteLine("(4) Add product to shopping cart");
                Console.WriteLine("(5) Pay order");
                Console.WriteLine("(6) Show buyers details");
                Console.WriteLine("(7) Show sellers details");
                Console.WriteLine("(8) EXIT");
                Console.Write("Enter your choice: ");
                userSelection = int.Parse(Console.ReadLine());

                switch (userSelection)
                {
                    case 1:
                        Console.WriteLine("Add name,\npassword\nand address that include - street , street number, city, country");
                        Address userAddr = new Address(Console.ReadLine(), int.Parse(Console.ReadLine()), 
                           Console.ReadLine(), Console.ReadLine());
                        manager.addBuyer(Console.ReadLine(), Console.ReadLine(), userAddr);
                        break;
                    case 2:
                       //
                        break;
                    case 3:
                      //
                        break;
                    case 4:
                        AddProductToCart(manager);
                        break;
                    case 5:
                        //PayOrder(manger);
                        break;
                    case 6:
                        //
                        break;
                    case 7:
                        // for only tests
                        manager.ShowAllProducts();
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

        static void PayOrder(Manager manager)
        {
            Console.WriteLine("What name of the buyer: ");
            string name = Console.ReadLine();
            manager.payOrderAllCart("chen");
        }


        static void AddProductToCart(Manager manger)
        {
            Console.WriteLine("\nYou choose add prodct to shopping cart");
            Console.Write("Enter a product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter the product price: ");
            int productPrice = int.Parse(Console.ReadLine());
            Console.Write("Enter which type of category from this list: [Kids, Electronics, Offices, Cloths]: ");
            string category = Console.ReadLine();
            Console.Write("Do you want add a special package? [Yes / No]: ");
            string specialBoxStr = Console.ReadLine();
            bool isSpecialBox = false;
            int extraPrice = 0;
            if (specialBoxStr == "yes")
            {
                isSpecialBox = true;
                Console.Write("how much is it to add a package box? ");
                extraPrice = int.Parse(Console.ReadLine());
            }

            else if (specialBoxStr == "no")
                isSpecialBox = false;

            manger.addMyProduct(new Product(productName, productPrice)); // To Do fix constructor
        }


        static void initiateData(Manager manager)
        {
            //Template Data
            Address addr1 = new Address("Zamenhof", 3, "Netanya", "ISR");
            manager.addBuyer("Chen", "12345", addr1);
            Address addr2 = new Address("Kikar HaAtsmaut", 34, "Netanya", "ISR");
            manager.addBuyer("Ben", "12345", addr2);
            Address addr3 = new Address("Kikar HaAtsmaut", 34, "Netanya", "ISR");
            manager.addBuyer("Aviv", "12345", addr3);

            manager.addMyProduct(new Product("Chen", 45));
            manager.addMyProduct(new Product("Chen", 35));
            manager.addMyProduct(new Product("Chen", 444));
            manager.addMyProduct(new Product("Ben", 444));
        }




    }
}
