# Gimpies
Gimpies Code
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Account_Tester
{
    //comment Thibault 
    internal class Program
    {
        static void Main(string[] args)
        {

            while(true)
            {
                bool gimpies = true;
                do
                {
                    string usernameCorrect = "b";
                    string passwordCorrect = "a";




                    Console.WriteLine("Welcome to Gimpies website!"); // homescreen
                    Console.ReadKey();
                    Console.Clear();
                    //Login Attempts counter
                    int loginAttempts = 0;
                    bool login = true;
                    //login attempts up to 3 times
                    do
                    {

                        Console.Write("Username: ");
                        string usernameInput = Console.ReadLine();
                        Console.Write("Password: ");
                        string passwordInput = MaskedPasswordInput();



                        if (usernameInput != usernameCorrect || passwordInput != passwordCorrect)// number counter for login  
                        {
                            loginAttempts++;

                            if (loginAttempts == 1)
                            {
                                Console.WriteLine("You have 2 attempts left");
                                System.Threading.Thread.Sleep(500);
                                Console.Clear();

                            }
                            if (loginAttempts == 2)
                            {
                                Console.WriteLine("You have 1 attempt left");
                                System.Threading.Thread.Sleep(500);
                                Console.Clear();

                            }
                            if (loginAttempts > 2)
                            {
                                Console.Clear();
                                Console.WriteLine("You have used all of your attempts"); // attempts failed 3
                                System.Threading.Thread.Sleep(500);
                                Console.Write("Application will be shutdown in ");
                                for (int a = 10; a >= 0; a--)
                                {
                                    Console.CursorLeft = 32;
                                    Console.Write("{0} ", a);
                                    System.Threading.Thread.Sleep(1000);

                                    if (a == 0)
                                        Environment.Exit(0);
                                }

                            }

                        }

                        else
                        {
                            Console.WriteLine("Login successful");
                            Console.ReadKey();

                            Console.Clear();
                            login = false;

                            break;
                        }
                    } while (login);

                    //Display the result

                    // Quantity Number variable
                    int NikeAirMaxPlusQuantityPurchaseSum, nikeAirMaxPlusQuantityPurchase, airMax1QuantityPurchaseSum, airMax1QuantityPurchase;
                    int nikeAirForce1QuantityPurchaseSum, nikeAirForceQuantityPurchase, nikeForce1LowQuantityPurchaseSum, nikeForce1LowQuantityPurchase;
                    NikeAirMaxPlusQuantityPurchaseSum = 0;
                    airMax1QuantityPurchaseSum = 0;
                    nikeAirForce1QuantityPurchaseSum = 0;
                    nikeForce1LowQuantityPurchaseSum = 0;

                    bool menuM = true;
                    do
                    {


                        bool voorraadMenu = true;

                        do
                        {

                            Console.WriteLine("Vorraad Menu");
                            System.Threading.Thread.Sleep(250);

                            Console.WriteLine("Choose the number below for further information.");
                            Console.WriteLine("");
                            Console.WriteLine("[B] Basket: ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("1. Nike Air Max Plus");
                            Console.WriteLine("2. Air Max 1");
                            Console.WriteLine("3. Nike  Air Force 1");
                            Console.WriteLine("4. Nike Force 1 Low");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");

                            Console.WriteLine("Press 0 to Log Out");
                            Console.WriteLine();
                            Console.WriteLine();
                            string nikeAirMaxPlus = "1";
                            string airMax1 = "2";
                            string nikeAirForce1 = "3";
                            string nikeForce1Low = "4";
                            string answerChoose = Console.ReadLine();


                            // Nike Air Max Plus Menu
                            if (answerChoose == nikeAirMaxPlus)
                            {
                                while (true)
                                {
                                    bool menu = true; // condition Menu
                                    do // pages 1 continue or back
                                    {
                                        Console.Clear();// Information 
                                        Console.WriteLine("Brand: Nike");
                                        Console.WriteLine("Type: Air Max Plus");
                                        Console.WriteLine("Color");
                                        Console.WriteLine("");

                                        Console.WriteLine("Quantity: ");
                                        Console.WriteLine("Price: ");
                                        Console.WriteLine("");


                                        bool quantityNumber = true;
                                        do
                                        {
                                            // number quantity

                                            Console.WriteLine("Typ the number for how many you want to but");
                                            if (int.TryParse(Console.ReadLine(), out nikeAirMaxPlusQuantityPurchase)) //input quantity number
                                            {
                                                if (nikeAirMaxPlusQuantityPurchase >= 0)
                                                {
                                                    NikeAirMaxPlusQuantityPurchaseSum = NikeAirMaxPlusQuantityPurchaseSum + nikeAirMaxPlusQuantityPurchase;
                                                    menu = false;  // break through theloop menu
                                                    quantityNumber = false; // break through the loop quantitymenu
                                                    break;
                                                }
                                                else // redo again
                                                {
                                                    Console.WriteLine("Wrong Input, Please Write it again");
                                                    System.Threading.Thread.Sleep(500);
                                                    quantityNumber = false;
                                                    break;
                                                }

                                            }
                                            else // redo again
                                            {
                                                Console.WriteLine("Wrong Input, Please Write it again");
                                                System.Threading.Thread.Sleep(500);

                                                quantityNumber = false;
                                                Console.Clear();
                                                break;

                                            }
                                        } while (quantityNumber);
                                    } while (menu);

                                    Console.WriteLine("");
                                    Console.ReadKey();
                                    Console.WriteLine("Click anything to back");
                                    string back = Console.ReadLine();
                                    if (back == "ABC") // execute return to menu
                                    {
                                        Console.Clear();

                                        break;


                                    }
                                    else // execute return to menu
                                    {
                                        Console.Clear();

                                        break;
                                    }

                                }

                                Console.Clear(); // go back to main menu page
                            }

                            // Air Max 1 Menu
                            if (answerChoose == airMax1)
                            {
                                while (true)
                                {
                                    bool menu = true; // condition Menu 
                                    do // pages 1 continue or back
                                    {
                                        Console.Clear();// Information
                                        Console.WriteLine("Brand: Nike");
                                        Console.WriteLine("Type: Air Max 1");
                                        Console.WriteLine("Color");
                                        Console.WriteLine("");

                                        Console.WriteLine("Quantity: ");
                                        Console.WriteLine("Price: ");
                                        Console.WriteLine("");


                                        bool quantityNumber = true;
                                        do
                                        {
                                            // number quantity

                                            Console.WriteLine("Typ the number for how many you want to but");
                                            if (int.TryParse(Console.ReadLine(), out airMax1QuantityPurchase)) //input quantity number
                                            {
                                                if (airMax1QuantityPurchase >= 0)
                                                {
                                                    airMax1QuantityPurchaseSum = airMax1QuantityPurchaseSum + airMax1QuantityPurchase;
                                                    menu = false;  // break through theloop menu
                                                    quantityNumber = false; // break through the loop quantitymenu
                                                    break;
                                                }
                                                else // redo again
                                                {
                                                    Console.WriteLine("Wrong Input, Please Write it again");
                                                    System.Threading.Thread.Sleep(500);
                                                    quantityNumber = false;
                                                    break;
                                                }

                                            }
                                            else // redo again
                                            {
                                                Console.WriteLine("Wrong Input, Please Write it again");
                                                System.Threading.Thread.Sleep(500);

                                                quantityNumber = false;
                                                Console.Clear();
                                                break;

                                            }
                                        } while (quantityNumber);
                                    } while (menu);

                                    Console.WriteLine("");
                                    Console.ReadKey();
                                    Console.WriteLine("Click anything to back");
                                    string back = Console.ReadLine();
                                    if (back == "ABC") // execute return to menu
                                    {
                                        Console.Clear();

                                        break;
                                    }
                                    else // execute return to menu
                                    {
                                        Console.Clear();

                                        break;
                                    }

                                }

                                Console.Clear(); // go back to main menu page
                            }

                            //Nike Air Force 1 Menu
                            if (answerChoose == nikeAirForce1)
                            {
                                while (true)
                                {
                                    bool menu = true; // condition Menu 
                                    do // pages 1 continue or back
                                    {
                                        Console.Clear();// Information 
                                        Console.WriteLine("Brand: Nike");
                                        Console.WriteLine("Type: Air Force 1");
                                        Console.WriteLine("Color");
                                        Console.WriteLine("");

                                        Console.WriteLine("Quantity: ");
                                        Console.WriteLine("Price: ");
                                        Console.WriteLine("");


                                        bool quantityNumber = true;
                                        do
                                        {
                                            // number quantity

                                            Console.WriteLine("Typ the number for how many you want to but");
                                            if (int.TryParse(Console.ReadLine(), out nikeAirForceQuantityPurchase)) //input quantity number
                                            {
                                                if (nikeAirForceQuantityPurchase >= 0)
                                                {
                                                    nikeAirForce1QuantityPurchaseSum = nikeAirForce1QuantityPurchaseSum + nikeAirForceQuantityPurchase;
                                                    menu = false;  // break through theloop menu
                                                    quantityNumber = false; // break through the loop quantitymenu
                                                    break;
                                                }
                                                else // redo again
                                                {
                                                    Console.WriteLine("Wrong Input, Please Write it again");
                                                    System.Threading.Thread.Sleep(500);
                                                    quantityNumber = false;
                                                    break;
                                                }

                                            }
                                            else // redo again
                                            {
                                                Console.WriteLine("Wrong Input, Please Write it again");
                                                System.Threading.Thread.Sleep(500);

                                                quantityNumber = false;
                                                Console.Clear();
                                                break;

                                            }
                                        } while (quantityNumber);
                                    } while (menu);

                                    Console.WriteLine("");
                                    
                                    Console.WriteLine("Click anything to back");
                                    string back = Console.ReadLine();
                                    if (back == "ABC") // execute return to menu
                                    {
                                        Console.Clear();

                                        break;


                                    }
                                    else // execute return to menu
                                    {
                                        Console.Clear();

                                        break;
                                    }

                                }

                                Console.Clear(); // go back to main menu page
                            }

                            // Nike Air Force Menu
                            if (answerChoose == nikeForce1Low)
                            {
                                while (true)
                                {
                                    bool menu = true; // condition Menu 
                                    do // pages 1 continue or back
                                    {
                                        Console.Clear();// Information
                                        Console.WriteLine("Brand: Nike");
                                        Console.WriteLine("Type: Force 1 Low");
                                        Console.WriteLine("Color");
                                        Console.WriteLine("");

                                        Console.WriteLine("Quantity: ");
                                        Console.WriteLine("Price: ");
                                        Console.WriteLine("");


                                        bool quantityNumber = true;
                                        do
                                        {
                                            // number quantity

                                            Console.WriteLine("Typ the number for how many you want to but");
                                            if (int.TryParse(Console.ReadLine(), out nikeForce1LowQuantityPurchase)) //input quantity number
                                            {
                                                if (nikeForce1LowQuantityPurchase >= 0)
                                                {
                                                    nikeForce1LowQuantityPurchaseSum = nikeForce1LowQuantityPurchaseSum + nikeForce1LowQuantityPurchase;
                                                    menu = false;  // break through theloop menu
                                                    quantityNumber = false; // break through the loop quantitymenu
                                                    break;
                                                }
                                                else // redo again
                                                {
                                                    Console.WriteLine("Wrong Input, Please Write it again");
                                                    System.Threading.Thread.Sleep(500);
                                                    quantityNumber = false;
                                                    break;
                                                }

                                            }
                                            else // redo again
                                            {
                                                Console.WriteLine("Wrong Input, Please Write it again");
                                                System.Threading.Thread.Sleep(500);

                                                quantityNumber = false;
                                                Console.Clear();
                                                break;

                                            }
                                        } while (quantityNumber);
                                    } while (menu);

                                    Console.WriteLine("");
                                    Console.ReadKey();
                                    Console.WriteLine("Click anything to back");
                                    string back = Console.ReadLine();
                                    if (back == "ABC") // execute return to menu
                                    {
                                        Console.Clear();

                                        break;


                                    }
                                    else // execute return to menu
                                    {
                                        Console.Clear();

                                        break;
                                    }

                                }

                                Console.Clear(); // go back to main menu page
                            }
                            if (answerChoose == "b" || answerChoose == "B")
                            {
                                while (true)
                                {
                                    bool removeM2 = true;
                                    do
                                    {
                                        Console.Clear();
                                        if (NikeAirMaxPlusQuantityPurchaseSum >= 1)
                                        {
                                            Console.WriteLine("You have " + NikeAirMaxPlusQuantityPurchaseSum + " Nike Air Max Plus.");
                                        }
                                        if (airMax1QuantityPurchaseSum >= 1)
                                        {
                                            Console.WriteLine("You have " + airMax1QuantityPurchaseSum + " Air Max 1");
                                        }
                                        if (nikeForce1LowQuantityPurchaseSum >= 1)
                                        {
                                            Console.WriteLine("You have " + nikeForce1LowQuantityPurchaseSum + " Nike Force 1 Low");
                                        }
                                        if (nikeAirForce1QuantityPurchaseSum >= 1)
                                        {
                                            Console.WriteLine("You have " + nikeAirForce1QuantityPurchaseSum + " Nike Air Force 1");
                                        }
                                        bool removeM = true;
                                        do
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("Do you want to remove?");
                                            Console.WriteLine("[1.] Nike Air Max Plus");
                                            Console.WriteLine("[2.] AirMax 1");
                                            Console.WriteLine("[3.] Nike Force 1 Low");
                                            Console.WriteLine("[4.] Nike Air Force 1");
                                            Console.WriteLine("Press N to go back");
                                            string remove = Console.ReadLine();

                                            if (remove == "1")
                                            {
                                                NikeAirMaxPlusQuantityPurchaseSum = 0;
                                                Console.Clear();
                                                removeM2 = false;
                                                removeM = false;
                                                break;
                                            }
                                            if (remove == "2")
                                            {
                                                airMax1QuantityPurchaseSum = 0;
                                                Console.Clear();
                                                removeM2 = false;
                                                removeM = false;
                                                break;
                                            }
                                            if (remove == "3")
                                            {
                                                nikeForce1LowQuantityPurchaseSum = 0;
                                                Console.Clear();
                                                removeM2 = false;
                                                removeM = false;
                                                break;
                                            }
                                            if (remove == "4")
                                            {
                                                nikeAirForce1QuantityPurchaseSum = 0;
                                                Console.Clear();
                                                removeM2 = false;
                                                removeM = false;
                                                break;
                                            }
                                            else if (Console.ReadKey().Key == ConsoleKey.N)
                                            {
                                                removeM = false;
                                                removeM2 = false;
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Wrong input, please try again.");
                                                System.Threading.Thread.Sleep(500);
                                                Console.Clear();
                                                break;
                                            }

                                        } while (removeM);
                                    } while (removeM2);


                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Press anything if you to go back.");
                                    string back = Console.ReadLine();
                                    if (back == "ABC") // execute return to menu
                                    {
                                        Console.Clear();

                                        break;


                                    }
                                    else // execute return to menu
                                    {
                                        Console.Clear();

                                        break;
                                    }
                                }

                            }
                            if (answerChoose == "0")
                            {
                                Console.Clear();

                                while (true)
                                {
                                    Console.WriteLine("Are you sure to proceed");
                                    Console.WriteLine();
                                    Console.WriteLine("Press Y/N for Yes or No");

                                    if (Console.ReadKey().Key == ConsoleKey.Y)
                                    {

                                        Console.Clear();


                                        System.Threading.Thread.Sleep(500);
                                        voorraadMenu = false;
                                        menuM = false;

                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        System.Threading.Thread.Sleep(500);
                                        break;
                                    }
                                }


                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }


                        } while (voorraadMenu);
                    } while (menuM);
                    

                } while (gimpies);
            }

                
        }
        static string MaskedPasswordInput()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (char.IsControl(key.KeyChar))
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }


    }   

}
