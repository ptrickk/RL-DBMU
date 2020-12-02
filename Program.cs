using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RL_DMBU
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Messung> messungen = new List<Messung>();
            // Change the username, password and database according to your needs
            // You can ignore the database option if you want to access all of them.
            // 127.0.0.1 stands for localhost and the default port to connect.
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=rocketleague;";
            // Your query,
            //string query = "SELECT Spiele, Siege, Tore, Torschüsse, Vorlagen, Paraden, Hereingaben, Befreiungsschläge, Retter, Zerstörungen, 3v3, 2v2, 1v1 FROM messung WHERE SpielerID = 1 ORDER BY Datum DESC";
            string query = "SELECT * FROM messung Order by Datum ASC";

            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            // Let's do it !
            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                // All succesfully executed, now do something

                // IMPORTANT : 
                // If your query returns result, use the following processor :

                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Messung m = new Messung(
                            reader.GetInt32(0),
                            reader.GetDateTime(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5),
                            reader.GetInt32(6),
                            reader.GetInt32(7),
                            reader.GetInt32(8),
                            reader.GetInt32(9),
                            reader.GetInt32(10),
                            reader.GetInt32(11),
                            reader.GetInt32(12),
                            reader.GetInt32(13),
                            reader.GetInt32(14),
                            reader.GetInt32(15)
                            );

                        messungen.Add(m);
                    }

                    

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                // Finally close the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Alle Daten wurden eingelesen!");
            Console.ReadLine();

            /*
             * Menü
             * 1: Hinzufügen
             * 2: Bearbeiten
             * 3: Tabelle ausgeben
             * 
             */

            int vorher = 0;
            int current = 0;
            foreach (KeyValuePair<DateTime, int> s in Messung.getIntValueWithDate(Messung.getMessungenBySID(1, messungen), "Spiele"))
            {
                current = s.Value;
                Console.WriteLine(current + " Differenz von: +" + (current - vorher) + " Datum: " + s.Key.ToShortDateString());
                vorher = current;
            }

            
            Console.ReadLine();

        }
    }
}
