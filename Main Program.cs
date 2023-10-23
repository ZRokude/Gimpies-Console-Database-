using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Gimpie__Database_
{
    internal class MainProgram
    {
        public static DataTable DataList, UserLogin;
        public static int LoginAttempts = 0, BuyItem, ChooseSize, Value, UserID, PurchaseID;
        public static decimal Price;
        public static string ChooseBrand, ChooseType, ChooseColor;

        public static int[] TotalValue, TotalProductID, TotalPurchaseID;
       

        
        static void Main(string[] args)
        {
            Welcome(); 
        }
        static void Welcome()
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
                DataTable UserCheckResult = DataAccess.Instance.ExecuteDataTable(UserCheck);
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
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " +e.Message);
                Login();
            }


        }
        static void Menu()
        {
            string MainMenu = "Main Menu";
            Console.SetCursorPosition((Console.WindowWidth - MainMenu.Length) / 2, Console.CursorTop);
            Console.WriteLine(MainMenu);
            FunctionAccess.Instance.CreateEmpptyLine(); // empty line
            Console.WriteLine("Click the following letter or number in boxes to proceed\n[B] Basket: \n[1.]Shoes List \n[L.] Log Out \n[0.]Exit");
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
                else if (Console.ReadKey(true).Key == ConsoleKey.L)
                {
                    Console.Clear();
                    Welcome();
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.D0)
                {
                    Environment.Exit(0);
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
            DataAccess.Instance.DataReaderCV(ProductListCheck);
        }
        static void ShoesList()
        {
            ShoesTable();
            // step 1 to choose item
            try
            {
                Console.WriteLine("Please write the Brand of the item \nEnter 0 to go back to menu.");
                FunctionAccess.Instance.CreateEmpptyLine();
                ChooseBrand = Console.ReadLine();
                string ProductListCheck = "SELECT * FROM ProductList WHERE Brand = '" + ChooseBrand + "'";
                DataTable ProductListResult = DataAccess.Instance.ExecuteDataTable(ProductListCheck);
                if (ProductListResult.Rows.Count > 0)
                {
                    StepType();
                }
                else if (ChooseBrand == "0")
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("We don't have the item you described");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    ShoesList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
                System.Threading.Thread.Sleep(5000);
                Console.Clear();
                ShoesList();
            }
        }
        static void StepType()
        {
            Console.WriteLine("Please write the Type of the item");
            ChooseType = Console.ReadLine();
            string ProductListCheck = "SELECT * FROM ProductList WHERE Brand = '" + ChooseBrand + "' AND Type = '" + ChooseType + "'";
            DataTable ProductListResult = DataAccess.Instance.ExecuteDataTable(ProductListCheck);
            if (ProductListResult.Rows.Count > 0)
            {
                StepColor();
            }
            else if (ChooseType == "0")
            {
                Console.Clear();
                Menu();
            }
            else if (string.IsNullOrEmpty(Convert.ToString(ProductListResult)))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1); FunctionAccess.Instance.Clear1AboveCurrentConsoleLine(); FunctionAccess.Instance.ClearCurrentConsoleLine();
                Console.WriteLine("We don't have the item you described"); Console.SetCursorPosition(0, Console.CursorTop - 1);
                System.Threading.Thread.Sleep(500); FunctionAccess.Instance.ClearCurrentConsoleLine(); StepType();
            }

        }
        static void StepColor()
        {
            Console.WriteLine("Please write the Color of the item");
            ChooseColor = Console.ReadLine();
            string ProductListCheck = "SELECT * FROM ProductList WHERE Brand = '" + ChooseBrand + "' AND Type = '" + ChooseType + "' AND Color = '"+ ChooseColor+"'";
            DataTable ProductListResult = DataAccess.Instance.ExecuteDataTable(ProductListCheck);
            if (ProductListResult.Rows.Count > 0)
            {
                StepSize();
            }
            else if (ChooseColor == "0")
            {
                Console.Clear();
                Menu();
            }
            else if (string.IsNullOrEmpty(Convert.ToString( ProductListResult)))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1); FunctionAccess.Instance.Clear1AboveCurrentConsoleLine(); FunctionAccess.Instance.ClearCurrentConsoleLine();
                Console.WriteLine("We don't have the item you described"); Console.SetCursorPosition(0, Console.CursorTop - 1);
                System.Threading.Thread.Sleep(500); FunctionAccess.Instance.ClearCurrentConsoleLine(); StepColor();
            }
        }
        static void StepSize()
        {
            Console.WriteLine("Please write the Size of the item");
            ChooseSize = int.Parse(Console.ReadLine());
            string ProductListCheck = "SELECT * FROM ProductList WHERE Brand = '" + ChooseBrand + "' AND Type = '" + ChooseType + "' AND Color = '" + ChooseColor + "' AND Size = '" + ChooseSize +"'";
            DataTable ProductListResult = DataAccess.Instance.ExecuteDataTable(ProductListCheck);
            if (ProductListResult.Rows.Count > 0)
            {
                DataList = ProductListResult;
                AddMenu();
            }
            else if (ChooseSize == 0)
            {
                Console.Clear();
                Menu();
            }
            else if (string.IsNullOrEmpty(Convert.ToString(ProductListResult)))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1); FunctionAccess.Instance.Clear1AboveCurrentConsoleLine(); FunctionAccess.Instance.ClearCurrentConsoleLine();
                Console.WriteLine("We don't have the item you described"); Console.SetCursorPosition(0, Console.CursorTop - 1);
                System.Threading.Thread.Sleep(500); FunctionAccess.Instance.ClearCurrentConsoleLine(); StepSize();

            }
        }
        
        static void AddMenu()
        {
            Console.WriteLine("How many do you want to buy?\nPlease proceed only with number.");
            Value =Convert.ToInt32(Console.ReadLine());
            if (Value == 0)
            {
                Console.Clear();
                Menu();
            }
            else if (Convert.ToInt32(DataList.Rows[0].ItemArray[6]) - Convert.ToInt32(Value) >= 0)
            {
                PurchaseID = FunctionAccess.Instance.RNGNumber();
                string ProductListCheck = "INSERT INTO PurchaseHistory (UserID, ProductID, Price, Quantity, PurchaseID, Paid) VALUES (@UserID, @ProductID, @Price, @Quantity, @PurchaseID, @Paid)";
                int ProductID = Convert.ToInt32(DataList.Rows[0].ItemArray[0]); int UserID = Convert.ToInt32(UserLogin.Rows[0].ItemArray[0]);
                decimal Price = Convert.ToDecimal(DataList.Rows[0].ItemArray[5]); string Paid = "No";
                DataAccess.Instance.InsertBuyHistory(ProductListCheck, ProductID, UserID, Price, Value, PurchaseID, Paid);
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
        static void Basket()
        {
            string No = "No";
            string ProductListCheck = "SELECT * FROM ProductList";
            DataAccess.Instance.DataReaderC(ProductListCheck);
            string PurchaseHistoryCheck = "SELECT * FROM PurchaseHistory WHERE UserID = '" + UserID + "' AND Paid = '" + No +"'" ;
            DataList = DataAccess.Instance.ExecuteDataTable(PurchaseHistoryCheck);
            // add quantity item to array
            for (int i = 0; i<DataList.Rows.Count; i++)
            {
                ListTotalValue.TotalValue.Add(Convert.ToInt32(DataList.Rows[i].ItemArray[2]));
            }
            TotalValue = ListTotalValue.TotalValue.ToArray();
            //write down the value of the item that hasnt been paid on the account
            for (int i = 0; i < DataList.Rows.Count; i++)
            {
                //to read the value of datareader where equals to datalist productID
                string ProductListValue = "SELECT * FROM ProductList WHERE ID = '" + DataList.Rows[i].ItemArray[1].ToString() + "'";
                DataAccess.Instance.DataReaderV(ProductListValue);
            }
            FunctionAccess.Instance.CreateEmpptyLine();
            //for (int i = 0; i < ListTotalValue.TotalValue.Count; i++)
            //{
            //    Console.WriteLine("You have: " + TotalValue[i] + " For ID" + TotalProductID[i]);
            //}
            Console.WriteLine("Are you sure want to Proceed? \nPress Y for Continue \nPress N for Cancel the Payment \nPress 0 to Quit");
            try
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    if (DataList.Rows.Count > 0)
                    {
                        // Update the data of shoes in Database
                        for (int i = 0; i < DataList.Rows.Count; i++)
                        {
                            string ProductListUpdate = "UPDATE ProductList SET Quantity = Quantity - '" + TotalValue[i] + "' WHERE ID = '" + DataList.Rows[i].ItemArray[1] + "'";
                            DataAccess.Instance.SQLCmd(ProductListUpdate);
                        }
                        FunctionAccess.Instance.CreateEmpptyLine();
                        Console.WriteLine("Purchase Succesful, Thank you for the Buy! :D");
                        System.Threading.Thread.Sleep(500);
                        FunctionAccess.Instance.CreateEmpptyLine();
                        Console.WriteLine("Press anything to go back to menu");
                        Console.ReadKey(); Console.Clear();
                        DataAccess.Index = 0; ListTotalValue.TotalValue.Clear();
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("You don't have item selected");
                        System.Threading.Thread.Sleep(500);
                        Console.Clear(); Basket();
                    }
                    
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    if (DataList.Rows.Count > 0)
                    {
                        for (int i = 0; i < DataList.Rows.Count; i++)
                        {
                            string ProductListDelete = "DELETE PurchaseHistory WHERE ProductID = '" + DataList.Rows[i].ItemArray[1] + "' AND PurchaseID = '" + DataList.Rows[i].ItemArray[4] + "'";
                            DataAccess.Instance.SQLCmd(ProductListDelete);
                        }
                       
                        FunctionAccess.Instance.CreateEmpptyLine();
                        Console.WriteLine("Press Anything to go Back to Menu");
                        Console.ReadKey(); Console.Clear(); DataAccess.Index = 0; ListTotalValue.TotalValue.Clear();
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("You don't have item selected");
                        System.Threading.Thread.Sleep(500);
                        Console.Clear(); Basket();
                    }
                   
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.D0)
                {
                    Console.Clear(); DataAccess.Index = 0; ListTotalValue.TotalValue.Clear();
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
                    DataTable UserResult = DataAccess.Instance.ExecuteDataTable(UserCheck);

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

