using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace consoleadatbazis
{
    class _26feladat
    {
        public static void Command(MySqlConnection connection)
        {
            Console.WriteLine("26.Melyik a legdrágább pizza?");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT pnev, MAX(par) FROM pizza LIMIT 1";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string pnev = dr.GetString("pnev");
                        int par = dr.GetInt32("MAX(par)");
                        Console.WriteLine($"\t{pnev}  \t{par}");
                    }

                }
                connection.Close();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
