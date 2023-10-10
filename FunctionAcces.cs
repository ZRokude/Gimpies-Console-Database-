using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Gimpie__with_database_
{
    internal class FunctionAcces
    {
        private static readonly FunctionAcces instance = new FunctionAcces();
        static FunctionAcces()
        {

        }
        private FunctionAcces()
        {

        }
        
        public static FunctionAcces Instance
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
    }
}
