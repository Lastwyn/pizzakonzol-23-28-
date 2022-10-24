using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace consoleadatbazis
{
    class _25feladat
    {
        public static void Command(MySqlConnection connection)
        {
            Console.WriteLine("25.A rendelések összértéke alapján mi a vevők sorrendje? ");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT vnev, SUM(db * par) FROM vevo JOIN rendeles USING(vazon) JOIN tetel USING(razon) JOIN pizza USING(pazon) GROUP BY vnev ORDER BY SUM(db*par) DESC";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string vnev = dr.GetString("vnev");
                        int db = dr.GetInt32("SUM(db * par)");
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
