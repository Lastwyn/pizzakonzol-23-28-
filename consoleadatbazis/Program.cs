using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace consoleadatbazis
{
    class Program
    {
       
        public static void Main(string[] args)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            bool fusson = true;
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            do
            {
                Console.WriteLine("Kérem adja meg a feladat sorszámát(23-28)!\nHa kiszeretne lépni a programból nyömjon egy 0-át!");
                int kerdesszama = Convert.ToInt32(Console.ReadLine());
                switch (kerdesszama)
                {
                    case 23:
                        _23feladat.Command(connection);
                        break;
                    case 24:
                        _24feladat.Command(connection);
                        break;
                    case 25:
                        _25feladat.Command(connection);
                        break;
                    case 26:
                        _26feladat.Command(connection);
                        break;
                    case 27:
                        _27feladat.Command(connection);
                        break;
                    case 28:
                        _28feladat.Command(connection);
                        break;
                    case 0:
                        fusson = false;
                        break;
                }
            } while (fusson);
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();

        }
    }
}
