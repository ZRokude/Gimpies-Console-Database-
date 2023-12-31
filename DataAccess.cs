﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Gimpie__Database_
{
    public sealed class DataAccess
    {
        private readonly SqlConnection connect = new SqlConnection(@"Data Source=ZRoku\SQLEXPRESS;Initial Catalog=Gimpie;Integrated Security=True");
        private string connectingString = @"Data Source=ZRoku\SQLEXPRESS;Initial Catalog=Gimpie;Integrated Security=True";
        public static SqlCommand com;
        public static SqlDataAdapter SDA;
        public static DataTable DataList;
        public static SqlDataReader DataReader;
        private static DataAccess instance = new DataAccess();
        private static readonly object padlock = new object();
        public static int Index = 0;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DataAccess()
        {
        }

        private DataAccess()
        {
        }

        public static DataAccess Instance
        {
            get
            {
                return instance;
            }
        }
        public DataTable ExecuteDataTable(string query)
        {
            DataList = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                using (com = new SqlCommand(query, connection))
                {
                    using (SDA = new SqlDataAdapter(com))
                    {
                        SDA.Fill(DataList);

                    }

                }
            }
            return DataList;
        }
        public void SQLCmd(string Query)
        {

            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                using (com = new SqlCommand(Query, connection))
                {
                    com.ExecuteNonQuery();
                }
                //connection.Close();
            }

        }
        public SqlDataReader DataReaderCV(string ProductListCheck)
        {

            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                using (com = new SqlCommand(ProductListCheck, connection))
                {
                    DataReader = com.ExecuteReader();
                    for (int i = 1; i < DataReader.FieldCount; i++)
                    {
                        Console.Write(DataReader.GetName(i) + "\t");
                    }
                    Console.WriteLine("");
                    while (DataReader.Read())
                    {
                        for (int i = 1; i < DataReader.FieldCount; i++)
                        {
                            if (Convert.ToInt32(DataReader.GetValue(6)) <= 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(DataReader.GetValue(i) + "\t");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write(DataReader.GetValue(i) + "\t");
                            }
                        }
                        Console.WriteLine("");
                    }
                }

            }
            return DataReader;

        }
        public SqlDataReader DataReaderC(string ProductListColumn)
        {
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                using (com = new SqlCommand(ProductListColumn, connection))
                {
                    DataReader = com.ExecuteReader();
                    for (int i = 1; i < DataReader.FieldCount; i++)
                    {
                        Console.Write(DataReader.GetName(i) + "\t");
                    }
                    Console.WriteLine("");
                }
            }
            return DataReader;
        }
        public SqlDataReader DataReaderV(string ProductListCheck)
        {
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                using (com = new SqlCommand(ProductListCheck, connection))
                {
                    
                    DataReader = com.ExecuteReader();
                    while (DataReader.Read())
                    {
                        for (int i = 1; i < 6; i++)
                        {
                            if (Convert.ToInt32(DataReader.GetValue(6)) <= 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(DataReader.GetValue(i) + "\t");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write(DataReader.GetValue(i) + "\t");
                            }
                        }
                        if (Convert.ToInt32(DataReader.GetValue(6)) <= 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(MainProgram.TotalValue[Index]);
                            Console.ForegroundColor = ConsoleColor.White;
                            Index++;
                        }
                        else
                        {
                            Console.Write(MainProgram.TotalValue[Index]);
                            Index++;
                        }
                    }
                    Console.WriteLine("");
                }
            }
            return DataReader;
        }
        public void InsertUser(string UserInsertCheck, string Password, string Username, string Role, int RandomNum)
        {
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                using (com = new SqlCommand(UserInsertCheck, connection))
                {
                    com.Parameters.AddWithValue("@Username", Username);
                    com.Parameters.AddWithValue("@Password", Password);
                    com.Parameters.AddWithValue("@Role", Role);
                    com.Parameters.AddWithValue("@ID", RandomNum);
                    int a = com.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data Saved");
                    }
                }
            }
        }

        public void InsertBuyHistory(string ProductListCheck, int ProductID, int UserID, decimal Price, int Quantity, int PurchaseID, string Paid)
        {
            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                using (com = new SqlCommand(ProductListCheck, connection))
                {
                    com.Parameters.AddWithValue("@UserID", UserID);
                    com.Parameters.AddWithValue("@ProductID", ProductID);
                    com.Parameters.AddWithValue("@Quantity", Quantity);
                    com.Parameters.AddWithValue("@Price", Price);
                    com.Parameters.AddWithValue("@PurchaseID", PurchaseID);
                    com.Parameters.AddWithValue("@Paid", Paid);
                    int a = com.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data History Saved to Server");
                    }
                }
            }
        }
    }
}
