using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace consoleadatbazis
{
    class _23feladat
    {
        
       public static void Command(MySqlConnection connection)
        {
            Console.WriteLine("23.Hány házhoz szállítása volt az egyes futároknak? ");
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT fnev, COUNT(fazon) FROM futar JOIN rendeles USING(fazon) GROUP By futar.fnev";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        string fnev = dr.GetString("fnev");
                        int fazon = dr.GetInt32("COUNT(fazon)");
                        Console.WriteLine($"\t{fnev}  \t{fazon}");
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
