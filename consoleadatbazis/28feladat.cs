using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace consoleadatbazis
{
    class _28feladat
    {
        public static void Command(MySqlConnection connection)
        {
            Console.WriteLine("28.Ki ette a legtöbb pizzát? ");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT vnev, SUM(db) FROM vevo JOIN rendeles USING(vazon) JOIN tetel USING(razon) GROUP BY vnev ORDER BY SUM(db)  DESC LIMIT 1";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string vnev = dr.GetString("vnev");
                        int db = dr.GetInt32("SUM(db)");
                        Console.WriteLine($"\t{vnev}  \t{db}");
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
