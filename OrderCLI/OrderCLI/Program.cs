/***************************************************************************************
 # AUTHOR    : Ömer Yavuz                                                              #     
 # PURPOSE   : Developing a console-based program that can order RAM components        #
 # LANGUAGE  : C# 10.0                                                                 #          
 # FRAMEWORK : .NET 5.0                                                                #              
 # VERSION   : 1.0                                                                     #          
 #**************************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;

namespace OrderCLI
{
    internal class OrderCLI
    {
        static int customerCounter = 0; // Global variable for number of customers 
        static int orderCounter = 0; // Global variable for number of orders
        public static void Main(String[] args)
        {
            var ordersDataList = new List<Order>(); // Orders Database
            var customersDataList = new List<Customer>(); // Customer Database
            var productsDataList = new List<Product> // Product Database
            {
                new Product{ Id = 1, Trademark ="GSKILL", Type="DDR5", Capacity="32GB", Canal="Dual Kit", 
                    Frequency="6000MHz",  Color="Black", Stock=5, Price=10233.22 },
                new Product{ Id = 2, Trademark ="GSKILL", Type="DDR5", Capacity="64GB", Canal="Dual Kit", 
                    Frequency="6000MHz",  Color="Silver", Stock=10, Price=18837.39 },
                new Product{ Id = 3, Trademark ="CORSAIR", Type="DDR5", Capacity="32GB", Canal="Dual Kit", 
                    Frequency="5600MHz",  Color="White", Stock=5, Price=8237.56 },
                new Product{ Id = 4, Trademark ="CORSAIR", Type="DDR5", Capacity="64GB", Canal="Dual Kit", 
                    Frequency="5200MHz",  Color="Black", Stock=10, Price=12685.84 },
                new Product{ Id = 5, Trademark ="PNY", Type="DDR4", Capacity="8GB", Canal="Single Kit", 
                    Frequency="3200MHz",  Color="Black", Stock=25, Price=559.99 },
                new Product{ Id = 6, Trademark ="Thermaltake", Type="DDR4", Capacity="16GB", Canal="Single Kit", 
                    Frequency="4000MHz",  Color="RGB", Stock=15, Price=2912.75 },
                new Product{ Id = 7, Trademark ="GoodRam", Type="DDR4", Capacity="8GB", Canal="Single Kit", 
                    Frequency="3200MHz",  Color="Red", Stock=25, Price=703.46 },
                new Product{ Id = 8, Trademark ="GoodRam", Type="DDR4", Capacity="16GB", Canal="Single Kit", 
                    Frequency="3600MHz",  Color="Silver", Stock=15, Price=1499.52 }
            };
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Title = ("Console-Based RAM Ordering Program by Naakgash");
            Console.WriteLine("Welcome Dear Customer :) Please Use NumPad During the Program...");
            Thread.Sleep(2000);
        checkPoint0: // From Line 58 & Line 120 & Line 131
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Please Enter Your TC Number");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("--> ");
            string tcNumberTemp = Console.ReadLine();
            if(tcNumberTemp.Length != 11 || !Customer.IsAllDigit(tcNumberTemp)) // Checking the entered TC number
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("\nTc number must be 11 characters long and consist of digits only...");
                Console.Write("Please try again...");
                Thread.Sleep(2000);
                Console.Clear();
                goto checkPoint0; // To Line 44
            }
            foreach (var it in customersDataList) // Search the customer database for the entered TC number
            {
                if (it.TcNumber.Equals(tcNumberTemp)) // Checking the entered TC number with customer database
                {
                checkPoint1: // From Line 83 & Line 86 & Line 96
                    Console.ForegroundColor= ConsoleColor.DarkGreen;
                    Console.Clear();
                    Console.WriteLine("\tWelcome again, {0} {1}\n\t   How can we help you? ", it.Name, it.Surname);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\n**************************************");
                    Console.WriteLine("* Press '1' to new order             *");
                    Console.WriteLine("* Press '2' to view your orders      *");
                    Console.WriteLine("* Press '3' to re-enter a TC number  *");
                    Console.WriteLine("* Press '0' to exit                  *");
                    Console.WriteLine("**************************************\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("--> ");
                    ConsoleKey consoleKey0 = Console.ReadKey().Key;
                    Console.Beep();
                    switch (consoleKey0)
                    {
                        case (ConsoleKey.NumPad1):
                            CreateOrder(productsDataList, ordersDataList, it);
                            goto checkPoint1; // To Line 64
                        case ConsoleKey.NumPad2:
                            GetOrder(ordersDataList, it);
                            goto checkPoint1; // To Line 64
                        case ConsoleKey.NumPad3:
                            goto checkPoint0; // to Line 44
                        case ConsoleKey.NumPad0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\nYou entered an invalid value. Please try again...");
                            Thread.Sleep(1500);
                            goto checkPoint1; // To Line 64
                    }
                }
            }
        checkPoint2: // From Line 129
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There is no user associated with the TC number you entered...\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("**************************************");
            Console.WriteLine("* Press '1' to create a new account  *");
            Console.WriteLine("* Press '2' to re-enter a TC number  *");
            Console.WriteLine("* Press '0' to exit                  *");
            Console.WriteLine("**************************************\n");
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.Write("--> ");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            Console.Beep();
            switch (consoleKey)
            {
                case ConsoleKey.NumPad1:
                    CreateCustomer(customersDataList);
                    break;
                case ConsoleKey.NumPad2:
                    goto checkPoint0; // To Line 44
                case ConsoleKey.NumPad0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\nYou entered an invalid value. Please try again...");
                    Thread.Sleep(1500);
                    Console.Clear();
                    goto checkPoint2; // To Line 100
            }
            goto checkPoint0; // To Line 44
        }
        public static void CreateCustomer(List<Customer> customersDataList)
        {
            Console.Clear();
            OrderCLI.customerCounter++;
            Customer customer = new();
        checkPointName: // From Line 154
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Please Enter Your Name ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("--> ");
            try
            {
                customer.Name = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nName must be between 3 and 15 characters long and consist of letters only...");
                Console.Write("Please try again...");
                Thread.Sleep(2000);
                Console.Clear();
                goto checkPointName; // To Line 138
            }
        checkPointSurname: // From Line 172 
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nPlease Enter Your Surname ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("--> ");
            try
            {
                customer.Surname = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSurame must be between 3 and 15 characters and consist of letters only.");
                Console.Write("Please try again...");
                Thread.Sleep(2000);
                Console.Clear();
                goto checkPointSurname; // To Line 156
            }
        checkPointTcNumber: // From Line 190
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nPlease Enter Your TC number as 11 digits");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("--> ");
            try
            {
                customer.TcNumber = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTc number must be 11 characters and consist of digits only");
                Console.Write("Please try again...");
                Thread.Sleep(2000);
                Console.Clear();
                goto checkPointTcNumber; // To Line 174
            }
        checkPointGsmNumber: // From Line 209    
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nPlease Enter Your GSM Number as 10 digits without the leading zero ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("--> ");
            try
            {
                customer.GsmNumber = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGsm number must be 10 characters and consist of digits only " +
                    "and without the leading zero");
                Console.Write("Please try again...");
                Thread.Sleep(2000);
                Console.Clear();
                goto checkPointGsmNumber; // To Line 192
            }
        checkPointAddress: // From Line 227
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nPlease Enter Your Address ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("--> ");
            try
            {
                customer.Address = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAddress must be more than 25 characters...");
                Console.Write("Please try again...");
                Thread.Sleep(2000);
                Console.Clear();
                goto checkPointAddress; // To Line 211
            }
            customer.Id = customerCounter;
            customersDataList.Add(customer);
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.Write("\nThe new account has been successfully created...");
            Thread.Sleep(1500);
            Console.Clear();
        }
        public static void CreateOrder(List<Product> productsDataList, List<Order> ordersDataList, 
            Customer customer)
        {
        checkPoint3: // From Line 289
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please select the type of item you want to buy\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("*********************************************************************************" +
                "**************************************");
            Console.WriteLine("*{0,4}\t{1,13}\t{2,13}\t{3,13}\t{4,13}\t{5,13}\t{6,13}\t{7,13} *", "Id", "Name", 
                "Type", "Capacity", "Frequency", "Color", "Stock", "Price($)");
            foreach (var it in productsDataList)
            {
                Console.WriteLine("*{0,4}\t{1,13}\t{2,13}\t{3,13}\t{4,13}\t{5,13}\t{6,13}\t{7,13} *", it.Id, 
                    it.Trademark, it.Type, it.Capacity, it.Frequency, it.Color, it.Stock, it.Price);
            }
            Console.WriteLine("*********************************************************************************" +
                "**************************************\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("--> ");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            Console.Beep();
            switch (consoleKey)
            {
                case ConsoleKey.NumPad1:
                    PrepareOrder(productsDataList, ordersDataList, customer, consoleKey);
                    break;
                case ConsoleKey.NumPad2:
                    PrepareOrder(productsDataList, ordersDataList, customer, consoleKey);
                    break;
                case ConsoleKey.NumPad3:
                    PrepareOrder(productsDataList, ordersDataList, customer, consoleKey);
                    break;
                case ConsoleKey.NumPad4:
                    PrepareOrder(productsDataList, ordersDataList, customer, consoleKey);
                    break;
                case ConsoleKey.NumPad5:
                    PrepareOrder(productsDataList, ordersDataList, customer, consoleKey);
                    break;
                case ConsoleKey.NumPad6:
                    PrepareOrder(productsDataList, ordersDataList, customer, consoleKey);
                    break;
                case ConsoleKey.NumPad7:
                    PrepareOrder(productsDataList, ordersDataList, customer, consoleKey);
                    break;
                case ConsoleKey.NumPad8:
                    PrepareOrder(productsDataList, ordersDataList, customer, consoleKey);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\nYou entered an invalid value. Please try again...");
                    Thread.Sleep(1500);
                    goto checkPoint3; // To Line 239
            }
        }
        public static void PrepareOrder(List<Product> productsDataList, List<Order> ordersDataList, 
            Customer customer, ConsoleKey consoleKey)
        {
            Console.Clear();
            foreach (var it in productsDataList)
            {
                if (it.Id == (((int)consoleKey) - 96))
                {
                checkPoint4: // From Line 319
                    Console.ForegroundColor= ConsoleColor.DarkGreen;
                    Console.WriteLine("Your chosen product {0} {1} {2} ${3}\n", it.Trademark, it.Capacity, 
                        it.Color, it.Price);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("How many do you want to buy?\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("--> ");
                    int quantity;
                    try
                    {
                        quantity = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nYou entered an invalid value. Please try again...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        goto checkPoint4; // To Line 300
                    }
                    if (!it.CheckStock(quantity))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Stock shortage. Please try again...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    }

                checkPoint5: // From Line 371
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Unit price: $" + it.Price + " Quantity: " + quantity + 
                        " Total price: $" + (quantity * it.Price));
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("* Press '1' if you are confirming the order *");
                    Console.WriteLine("* Press '2' to cancel the order             *");
                    Console.WriteLine("* Press '0' to exit                         *");
                    Console.WriteLine("*********************************************\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("--> ");
                    ConsoleKey consoleKey2 = Console.ReadKey().Key;
                    Console.Beep();
                    switch (consoleKey2)
                    {
                        case ConsoleKey.NumPad1:
                            OrderCLI.orderCounter++;
                            ordersDataList.Add(new Order
                            {
                                Id = orderCounter,
                                TotalPrice = quantity * it.Price,
                                Quantity = quantity,
                                CustomerTcNumber = customer.TcNumber,
                                CustomerName = customer.Name,
                                CustomerSurname = customer.Surname,
                                CustomerGsmNumber = customer.GsmNumber,
                                CustomerAdress = customer.Address,
                                ProductTrademark = it.Trademark,
                                ProductType = it.Type,
                                ProductCapacity = it.Capacity,
                                ProductCanal = it.Canal,
                                ProductFrequency = it.Frequency,
                                ProductColor = it.Color
                            });
                            it.DecrementStock(quantity);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\nYour order has been successfully created...");
                            Thread.Sleep(1500);
                            break;
                        case ConsoleKey.NumPad2:
                            Console.Clear();
                            break;
                        case ConsoleKey.NumPad0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\nYou entered an invalid value. Please try again...");
                            Thread.Sleep(1500);
                            goto checkPoint5; // To Line 321
                    }
                }
            }
        }
        public static void GetOrder(List<Order> ordersDataList, Customer customer)
        {
            Boolean flag = false;
            Console.Clear();
            foreach (var it in ordersDataList)
            {
                if (it.CustomerTcNumber.Equals(customer.TcNumber))
                {
                    flag = true;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Order No: " + it.Id);
                    Console.WriteLine("Customer TC Number: " + it.CustomerTcNumber);
                    Console.WriteLine("Customer Name: " + it.CustomerName);
                    Console.WriteLine("Customer Surname: " + it.CustomerSurname);
                    Console.WriteLine("Customer GSM Number: " + it.CustomerGsmNumber);
                    Console.WriteLine("Customer Adress: " + it.CustomerAdress);
                    Console.WriteLine("Product Trademark: " + it.ProductTrademark);
                    Console.WriteLine("Product Type: " + it.ProductType);
                    Console.WriteLine("Product Capacity: " + it.ProductCapacity);
                    Console.WriteLine("Product Canal: " + it.ProductCanal);
                    Console.WriteLine("Product Frequency: " + it.ProductFrequency);
                    Console.WriteLine("Product Color: " + it.ProductColor);
                    Console.WriteLine("Product Quantity: " + it.Quantity);
                    Console.WriteLine("Total Price: $" + it.TotalPrice);
                    Console.ForegroundColor= ConsoleColor.Black;
                    Console.WriteLine("\n************************************\n");
                }
            }
            if (flag == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You do not have an order registered to your account...");
                Thread.Sleep(1500);
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Console.Beep();
            }
        }
    }
}