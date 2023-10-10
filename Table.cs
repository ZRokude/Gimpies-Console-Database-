using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Web;

namespace Console_Gimpie__with_database_
{
    internal class Table
    {

        public static SqlCommand com;
        public static SqlDataAdapter SDA;
        public static DataTable DataList;
        public static SqlDataReader DataReader;
        public static int tableWidth = 100;
        public static string[] DataListArray;
        public static void PrintTable()
        { 
            Console.Clear();
            PrintLine();
            string ProductListCheck = "SELECT * FROM ProductList";
            DataList = DataAccess.Instance.ExecuteDataTableProductList(ProductListCheck);

            //DataListArray = DataList.Rows[0].ItemArray.Select(item => item.ToString()).ToArray();
            //PrintRow("Test", "test 2");    

            //PrintLine();



            DataAccess.Instance.DataAccessConnection().Open();
            com = new SqlCommand("SELECT * FROM ProductList", DataAccess.Instance.DataAccessConnection());
            DataReader = com.ExecuteReader();
            for (int i = 0; i < DataReader.FieldCount; i++)
            {

                PrintRow(DataReader.GetName(i));

            }
            PrintLine();
            while (DataReader.Read())
            {

                for (int i = 0; i < DataReader.FieldCount; i++)
                {
                    PrintRow(Convert.ToString(DataReader.GetValue(i)));

                }
                PrintLine();
            }
            DataAccess.Instance.DataAccessConnection().Close();
            //PrintRow("COlumn 1", "Column 2", "Column 3", "Column 4", "Column 4", "Column 4", "Column 4", "Column 4");
            //PrintLine();
            //PrintRow("Nike", "Nike", "Nike", "Column 4", "Column 4", "Column 4", "Column 4", "Column 4", "Column 4");

            //PrintRow("Puma", "Puma", "Puma", "Column 4", "Column 4", "Column 4", "Column 4", "Column 4", "Column 4");
            Console.ReadLine();
        }
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        //DataAccess.Instance.DataAccessConnection().Open();
        //com = new SqlCommand("SELECT * FROM ProductList", DataAccess.Instance.DataAccessConnection());
        //DataReader = com.ExecuteReader();
        //for (int i = 0; i < DataReader.FieldCount; i++)
        //{

        //    PrintRow(DataReader.GetName(i));

        //}
        //PrintLine();
        //while (DataReader.Read())
        //{

        //    for (int i = 0; i < DataReader.FieldCount; i++)
        //    {
        //        PrintRow(Convert.ToString(DataReader.GetValue(i)));

        //    }
        //    PrintLine();
        //}
        //DataAccess.Instance.DataAccessConnection().Close();

    }
}
