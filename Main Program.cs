using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Gimpie__Database_
{
    internal class Program
    {
        public static DataTable DataList, UserLogin;
        public static int LoginAttempts = 0, BuyItem, ChooseID, Value, UserID, PurchaseID;
        public static decimal Price;

        public static int[] TotalValue, TotalProductID, TotalPurchaseID;
       

        
        static void Main(string[] args)
        {
           
            while (true)
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
                    FunctionAccess.Instance.CreateEmpptyLine();
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
            string pass = FunctionAccess.Instance.MaskedPasswordInput();
            try
            {
                string UserCheck = ("SELECT * FROM DataUser WHERE Username = '" + user + "' AND Password = '" + pass + "'");
                DataTable UserCheckResult = DataAccess.Instance.ExecuteDataTableUser(UserCheck);
                if (UserCheckResult.Rows.Count > 0)
                {
                    UserLogin = UserCheckResult;
                    Console.Clear();
                    UserID = Convert.ToInt32(UserCheckResult.Rows[0].ItemArray[0]);
                    Menu();
                }
                else if (LoginAttempts >= 3)
                {
                    FunctionAccess.Instance.CreateEmpptyLine();
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
            string MainMenu = "Main Menu";
            Console.SetCursorPosition((Console.WindowWidth - MainMenu.Length) / 2, Console.CursorTop);
            Console.WriteLine(MainMenu);
            FunctionAccess.Instance.CreateEmpptyLine(); // empty line
            Console.WriteLine("Click the following letter or number in boxes to proceed\n[B] Basket: \n[1.]Shoes List");
            FunctionAccess.Instance.CreateEmpptyLine(); FunctionAccess.Instance.CreateEmpptyLine();// empty line
            try
            {
                if (Console.ReadKey(true).Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    ShoesList();
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.B)
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
            catch (Exception e)
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
                FunctionAccess.Instance.CreateEmpptyLine(); Console.WriteLine("Please put the ID for item you'd want to buy \nEnter 0 to go back to menu.");
                FunctionAccess.Instance.CreateEmpptyLine();
                ChooseID = int.Parse(Console.ReadLine());
                string ProductListCheckID = "SELECT * FROM ProductList WHERE ID = '" + ChooseID + "'";
                DataTable ProductListResult = DataAccess.Instance.ExecuteDataTableUser(ProductListCheckID);

                if (ProductListResult.Rows.Count > 0)
                {
                    DataList = ProductListResult;
                    AddMenu();
                }
                else if (ChooseID == 0)
                {
                    Console.Clear();
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
        public static void InsertListToArray()
        {
           
            TotalValue = ListTotalValue.TotalValue.ToArray(); TotalProductID = ListTotalProductID.TotalProductID.ToArray(); TotalPurchaseID = ListTotalPurchaseID.TotalPurchaseID.ToArray();
        }
        static void AddMenu()
        {
            Console.WriteLine("How many do you want to buy?\nPlease proceed only with number.");
            Value =Convert.ToInt32(Console.ReadLine());
            try
            {
                if (Convert.ToInt32(DataList.Rows[0].ItemArray[6]) - Convert.ToInt32(Value) >= 0)
                {
                    PurchaseID = FunctionAccess.Instance.RNGNumber();
                    string ProductListCheck = "INSERT INTO PurchaseHistory (UserID, ProductID, Price, Quantity, PurchaseID) VALUES (@UserID, @ProductID, @Price, @Quantity, @PurchaseID)";
                    int ProductID = Convert.ToInt32( DataList.Rows[0].ItemArray[0]);int UserID = Convert.ToInt32(UserLogin.Rows[0].ItemArray[0]);
                    decimal Price = Convert.ToDecimal(DataList.Rows[0].ItemArray[5]);
                    DataAccess.Instance.InsertBuyHistory(ProductListCheck, ProductID, UserID, Price , Value, PurchaseID);
                    ListTotalProductID.TotalProductID.Add(ProductID); ListTotalValue.TotalValue.Add(Value); ListTotalPurchaseID.TotalPurchaseID.Add(PurchaseID);
                    InsertListToArray();
                    Console.WriteLine("You've succesfully added the item to the basket.\nPress anything to go back to menu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop); FunctionAccess.Instance.Clear2AboveCurrentConsoleLine(); FunctionAccess.Instance.Clear1AboveCurrentConsoleLine();
                    FunctionAccess.Instance.ClearCurrentConsoleLine();
                    Console.WriteLine("We don't have enough Item in the storage"); Console.SetCursorPosition(0, Console.CursorTop - 1);
                    System.Threading.Thread.Sleep(500); FunctionAccess.Instance.ClearCurrentConsoleLine(); AddMenu();
                }
            }
            catch
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                FunctionAccess.Instance.Clear2AboveCurrentConsoleLine(); FunctionAccess.Instance.Clear1AboveCurrentConsoleLine();
                Console.WriteLine("Invalid Input, Please Put the Correct Syntax");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                System.Threading.Thread.Sleep(500);
                FunctionAccess.Instance.ClearCurrentConsoleLine();
                AddMenu();
            }
        }
        static void Basket()
        {

            string ProductListCheck = "SELECT * FROM ProductList";
            DataAccess.Instance.DataReaderColumnsProductList(ProductListCheck);
            for (int i = 0; i < ListTotalPurchaseID.TotalPurchaseID.Count; i++)
            {
                string ProductListValue = "SELECT * FROM ProductList WHERE ID = '" + TotalProductID[i] + "'";
                DataAccess.Instance.DataReaderItemsProductList(ProductListValue);
            }
            FunctionAccess.Instance.CreateEmpptyLine();
            for (int i = 0; i < ListTotalValue.TotalValue.Count; i++)
            {
                Console.WriteLine("You have: " + TotalValue[i] + " For ID" + TotalProductID[i]);
            }
            Console.WriteLine("Are you sure want to Proceed? \nPress Y for Continue \nPress N for Cancel the Payment \nPress 0 to Quit");
            try
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    // Product Update in Database
                    for (int i = 0; i < ListTotalPurchaseID.TotalPurchaseID.Count; i++)
                    {
                        string ProductListUpdate = "UPDATE ProductList SET Quantity = Quantity - '" + TotalValue[i] + "' WHERE ID = '" + TotalProductID[i] + "'";
                        DataAccess.Instance.UpdateProductList(ProductListUpdate);
                    }
                    ListTotalProductID.TotalProductID.Clear();ListTotalPurchaseID.TotalPurchaseID.Clear();ListTotalValue.TotalValue.Clear();
                    InsertListToArray();
                    FunctionAccess.Instance.CreateEmpptyLine();
                    Console.WriteLine("Purchase Succesful, Thank you for the Buy! :D");
                    System.Threading.Thread.Sleep(500);
                    FunctionAccess.Instance.CreateEmpptyLine();
                    Console.WriteLine("Press anything to go back to menu");
                    Console.ReadKey(); Console.Clear();
                    Menu();
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    for(int i = 0; i < ListTotalPurchaseID.TotalPurchaseID.Count;i++)
                    {
                        string ProductListDelete = "DELETE PurchaseHistory WHERE ProductID = '" + TotalProductID[i] + "' AND PurchaseID = '" + TotalPurchaseID[i] + "'";
                        DataAccess.Instance.UpdateProductList(ProductListDelete);
                    }
                    ListTotalProductID.TotalProductID.Clear(); ListTotalPurchaseID.TotalPurchaseID.Clear(); ListTotalValue.TotalValue.Clear();
                    InsertListToArray();
                    FunctionAccess.Instance.CreateEmpptyLine();
                    Console.WriteLine("Press Anything to go Back to Menu");
                    Console.ReadKey();Console.Clear();
                    Menu();
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.D0)
                {
                    Console.Clear();
                    Menu();
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
                System.Threading.Thread.Sleep(10000);
                FunctionAccess.Instance.ClearCurrentConsoleLine();
            }
        }
        static void CreateAccount()
        {
            string CreateAccountPage = "Create Account Page";
            Console.SetCursorPosition((Console.WindowWidth - CreateAccountPage.Length) / 2, Console.CursorTop);
            Console.WriteLine(CreateAccountPage);
            Console.Write("Username: "); string Username = Console.ReadLine();
            Console.Write("Password: "); string Password = Console.ReadLine();
            string UserInsertCheck = "INSERT INTO DataUser (ID, Role, Username, Password) VALUES (@ID, @Role, @Username, @Password)";
            string UserCheck = ("SELECT * FROM DataUser WHERE Username = '" + Username + "'");
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

