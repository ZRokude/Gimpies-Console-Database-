using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Gimpie__Database_
{
    internal class FunctionAccess
    {
        private static readonly FunctionAccess instance = new FunctionAccess();
        static FunctionAccess()
        {

        }
        private FunctionAccess()
        {

        }

        public static FunctionAccess Instance
        {
            get
            {
                return instance;
            }

        }


        public string MaskedPasswordInput()
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
        public void CreateEmpptyLine()
        {
            int i;
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine("");
            }
        }
        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public void Clear1AboveCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop - 1;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public void Clear2AboveCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop - 2;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public int RNGNumber()
        {
            Random rnd = new Random();
            int RandomNumber = int.Parse("800" + rnd.Next(1, 99999).ToString());
            return  RandomNumber;
        }
        public void InsertList (int a, int b)
        {
            //ListTotalValue NewValue = new ListTotalValue
            //{
            //    Value = a
            //};
            //ListTotalValue.TotalValue.Add(NewValue);
            //ListTotalProductID NewProductID = new ListTotalProductID
            //{
            //    ProductID = b
            //};
            //ListTotalProductID.TotalProductID.Add(NewProductID);
        }

    }
}
