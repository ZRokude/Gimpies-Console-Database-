using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Dynamic;
using System.Runtime.Remoting.Contexts;
using System.Security.Claims;

namespace Console_Gimpie__with_database_
{
    internal class Program
    {
        
        public static SqlCommand com;
        public static SqlDataAdapter SDA;
        public static DataTable DataList;
        public static SqlDataReader DataReaderResult;
        public static int LoginAttempts = 0, BuyItem, ChooseID, Value;
        public static int[] BuyValue = new int[Value];
        static void Main()
        {
            while(true)
            {
                Console.WriteLine("Welcome to Gimpies");
                Console.WriteLine("Do you have account?");
                Console.WriteLine("Press Y/N for yes or no");
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    Login();
                    break;


                }
                else if (Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    Console.Clear();
                    CreateAccount();
                }
                else
                {
                    FunctionAcces.Instance.CreateEmpptyLine();
                    Console.WriteLine("Wrong Input");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        static void Login()
        {
            
            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            string pass = FunctionAcces.Instance.MaskedPasswordInput();
            try
            {
                string UserCheck = ("SELECT * FROM DataUser WHERE Username = '" + user +"' AND Password = '" + pass + "'");
                DataTable result = DataAccess.Instance.ExecuteDataTableUser(UserCheck);
                if (result.Rows.Count > 0)
                {
                    Console.Clear();
                    
                    Menu();
                }
                else if (LoginAttempts >= 3)
                {
                    FunctionAcces.Instance.CreateEmpptyLine();
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
                else
                {
                    LoginAttempts++;
                    Console.WriteLine("Username or Password is Invalid!");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    Login();
                }
            }
            catch
            {
                Console.WriteLine("Error");
                Login();
            }


        }
        static void Menu()
        {
            Table.PrintTable();
            string MainMenu = "Main Menu";
            Console.SetCursorPosition((Console.WindowWidth - MainMenu.Length) / 2, Console.CursorTop);
            Console.WriteLine(MainMenu);
            FunctionAcces.Instance.CreateEmpptyLine(); // empty line
            Console.WriteLine("Click the following letter or number in boxes to proceed\n[B] Basket: \n[1.]Shoes List");
            FunctionAcces.Instance.CreateEmpptyLine(); FunctionAcces.Instance.CreateEmpptyLine();// empty line
            try
            {
                if (Console.ReadKey(true).Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    ShoesList();
                }
                else if(Console.ReadKey(true).Key == ConsoleKey.B)
                {
                    Console.Clear();
                    Basket();
                }
                else
                {
                    Console.WriteLine("Wrong Button");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    Menu();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Wrong Input, Please Put the Correct Input");
                Console.WriteLine($"Error: {e.Message}");
                System.Threading.Thread.Sleep(10000);
                Console.Clear();
                Menu();
            }


        }
        public static void ShoesTable()
        {

            string ProductListCheck = "SELECT * FROM ProductList";
            DataAccess.Instance.DataReaderProductList(ProductListCheck);
        }
        static void ShoesList()
        {
            ShoesTable();
            try
            {
                FunctionAcces.Instance.CreateEmpptyLine(); Console.WriteLine("Please put the ID for item you'd want to buy \nEnter 0 to go back to menu."); FunctionAcces.Instance.CreateEmpptyLine();
                ChooseID = int.Parse(Console.ReadLine());
                string ProductListCheckID = "SELECT * FROM ProductList WHERE ID = '" + ChooseID + "'";
                DataTable ProductListResult = DataAccess.Instance.ExecuteDataTableUser(ProductListCheckID);
                
                if (ProductListResult.Rows.Count > 0)
                {
                    DataList = ProductListResult;
                    AddMenu();
                }
                else if(ChooseID == 0)
                {
                    Menu();
                }
                else
                {
                    Console.WriteLine("Invalid Input, Please Put the Right ID");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    ShoesList();
                }    
            }
            catch
            {
                Console.WriteLine("Invalid Input, Please Put the Correct Syntax");
                System.Threading.Thread.Sleep(10000);
                Console.Clear();
                ShoesList();
            }
        }
        static void AddMenu()
        {
            Console.WriteLine("How many do you want to buy?\nPlease proceed only with number.");
            try
            {
                Value = int.Parse(Console.ReadLine());
                if (Convert.ToInt32(DataList.Rows[0].ItemArray[6]) -Convert.ToInt32(Value) >= 0)
                {
                    Console.WriteLine("You've succesfully added the item to the basket.\nPress anything to go back to menu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop);FunctionAcces.Instance.Clear2AboveCurrentConsoleLine(); FunctionAcces.Instance.Clear1AboveCurrentConsoleLine();FunctionAcces.Instance.ClearCurrentConsoleLine();
                    Console.WriteLine("We don't have enough Item in the storage"); Console.SetCursorPosition(0, Console.CursorTop - 1);
                    System.Threading.Thread.Sleep(500);FunctionAcces.Instance.ClearCurrentConsoleLine(); AddMenu();
                }

                
            }
            catch
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                FunctionAcces.Instance.Clear2AboveCurrentConsoleLine(); FunctionAcces.Instance.Clear1AboveCurrentConsoleLine();
                Console.WriteLine("Invalid Input, Please Put the Correct Syntax");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                System.Threading.Thread.Sleep(500);
                FunctionAcces.Instance.ClearCurrentConsoleLine();
                AddMenu();
            }
        }
       static void Basket()
        {

            string ProductListCheck ="SELECT * FROM ProductList WHERE ID = '" + ChooseID + "'";
            DataAccess.Instance.DataReaderProductList(ProductListCheck);
            FunctionAcces.Instance.CreateEmpptyLine();
            Console.WriteLine("You have: " + BuyValue + " For \nAre You Sure Want to Proceed?\nPress Y for yes and N for No");
            try
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    try
                    {
                        // Product Update in Database
                        string ProductListUpdate ="UPDATE ProductList SET Quantity = Quantity - '" + Value + "' WHERE ID = '" + ChooseID + "'";
                        DataAccess.Instance.UpdateProductList(ProductListUpdate);
                        //DataAccess.Instance.DataAccessConnection().Close();
                        FunctionAcces.Instance.CreateEmpptyLine();
                        Console.WriteLine("Purchase Succesful, Thank you for the Buy! :D"); 
                        System.Threading.Thread.Sleep(500);
                        FunctionAcces.Instance.CreateEmpptyLine();
                        Console.WriteLine("Press anything to go back to menu");
                        Console.ReadKey(); Console.Clear(); 
                        Menu();
                    }
                    catch
                    {
                        Console.WriteLine("There is Something Error");
                        Console.ReadKey();
                        Menu();
                    }
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Menu();
                }
            }
            catch
            {
                Console.WriteLine("Wrong Input, Please Put the Correct Input");
                System.Threading.Thread.Sleep(10000);
                FunctionAcces.Instance.ClearCurrentConsoleLine();
            }
        }
        static void CreateAccount()
        {
            string CreateAccountPage = "Create Account Page";
            Console.SetCursorPosition((Console.WindowWidth - CreateAccountPage.Length) / 2, Console.CursorTop);
            Console.WriteLine(CreateAccountPage);
            Console.Write("Username: "); string Username = Console.ReadLine();
            Console.Write("Password: "); string Password = Console.ReadLine();
            string UserInsertCheck ="INSERT INTO DataUser (ID, Role, Username, Password) VALUES (@ID, @Role, @Username, @Password)";
            string UserCheck = ("SELECT * FROM DataUser WHERE Username = '" + Username + "'");
            //com.CommandType = CommandType.StoredProcedure;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                Console.WriteLine("Invalid Input"); System.Threading.Thread.Sleep(500);
                CreateAccount();
            }
            else
            {
                try
                {
                    Random rnd = new Random();
                    int RandomNum = rnd.Next(0, 9999);
                    // connect to the database
                    DataTable UserResult = DataAccess.Instance.ExecuteDataTableUser(UserCheck);

                    if (UserResult.Rows.Count > 0)
                    {
                        Console.WriteLine("Username is already exist, please use another username");
                    }
                    else
                    {
                        string Role = "User";
                        // add item to all tables item
                        DataAccess.Instance.InsertUser(UserInsertCheck, Password, Username, Role, RandomNum);
                        //com.Parameters.AddWithValue("@Username", Username);
                        //com.Parameters.AddWithValue("@Password", Password);
                        //com.Parameters.AddWithValue("@Role", Role);
                        //com.Parameters.AddWithValue("@ID", RandomNum);
                        // check the execute as statement
                        //int a = com.ExecuteNonQuery();
                        //DataAccess.Instance.DataAccessConnection().Close();
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Press anything to go to back login page");
                        Console.ReadKey();
                        Console.Clear();
                        Login();
                    }
                }
                catch
                {
                    Console.WriteLine("Error");
                    Console.Clear();
                    CreateAccount();
                }
            }
        }

    }
}
