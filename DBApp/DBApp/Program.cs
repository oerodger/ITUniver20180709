using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MSSQL"];
            if (connectionString == null)
            {
                Console.WriteLine("Не найдена строка подключения к БД");
                return;
            }
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                var command = new SqlCommand("select * from [User]", connection);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]} - {reader[2]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.StackTrace != null)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
