using System;
using System.Data;
using System.Data.SQLite;

namespace ConsoleMSQL
{
    class Program
    {
        static void Main(string[] args)
        {



            using (SQLiteConnection connection = new SQLiteConnection("Data Source=DataBase.db"))
            {
                // Define a t-SQL query string that has a parameter for orderID.
                //const string sql = "SELECT * FROM Sales.Orders WHERE orderID = @orderID";
                const string sql = "SELECT * FROM Orders";
                // Create a SqlCommand object.
                using (SQLiteCommand sqlCommand = new SQLiteCommand(sql, connection))
                {


                    try
                    {
                        connection.Open();

                        // Run the query by calling ExecuteReader().
                        using (SQLiteDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                Console.Write(dataReader.GetName(0) + '\t'
                                    + dataReader.GetName(1) + '\t'
                                    + dataReader.GetName(2) + '\t'
                                    + dataReader.GetName(3) + '\t'
                                    + dataReader.GetName(4) + '\t'
                                    + dataReader.GetName(5) + '\n');


                                while (dataReader.Read())
                                {
                                    Console.Write(dataReader.GetValue(0).ToString() + '\t'
                                                 + dataReader.GetValue(1).ToString() + '\t'
                                                 + dataReader.GetValue(2).ToString() + '\t'
                                                 + dataReader.GetValue(3).ToString() + '\t'
                                                 + dataReader.GetValue(4).ToString() + '\t'
                                                 + dataReader.GetValue(5).ToString() + '\n'
                                                 );
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Запрос не может быть выведен в консоль.");
                    }
                    finally
                    {
                        // Close the connection.
                        connection.Close();
                    }
                }
            }

            Console.ReadLine();
        }
    }
}