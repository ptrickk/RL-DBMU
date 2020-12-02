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

            PlayerList playerList = new PlayerList();
            MeasurementList measurementList = new MeasurementList();
            // Change the username, password and database according to your needs
            // You can ignore the database option if you want to access all of them.
            // 127.0.0.1 stands for localhost and the default port to connect.
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=rocketleague;";
            // Your query,
            //string query = "SELECT Spiele, Siege, Tore, Torschüsse, Vorlagen, Paraden, Hereingaben, Befreiungsschläge, Retter, Zerstörungen, 3v3, 2v2, 1v1 FROM messung WHERE SpielerID = 1 ORDER BY Datum DESC";
            string playerQuery = "SELECT * FROM spieler";
            string measurementQuery = "SELECT * FROM messung Order by Datum ASC";

            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand playerCommand = new MySqlCommand(playerQuery, databaseConnection);
            MySqlCommand measurementCommand = new MySqlCommand(measurementQuery, databaseConnection);

            playerCommand.CommandTimeout = 60;
            measurementCommand.CommandTimeout = 60;

            MySqlDataReader reader;

            // Let's do it !
            try
            {
                // Open the database
                databaseConnection.Open();
                // Execute the player query
                reader = playerCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create player with data from query
                        Player player = new Player(reader.GetInt32("SpielerID"), reader.GetString("Name"), reader.GetString("Spielername"));

                        playerList.Add(player);
                    }
                }
                else
                {
                    Console.WriteLine("No Players found.");
                }

                reader.Close();

                //prepare measurement command
                reader = measurementCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Measurement m = new Measurement(
                            reader.GetInt32("MessungsID"),
                            reader.GetDateTime("Datum"),
                            reader.GetInt32("SpielerID")
                            );

                        for (int i = 3; i < reader.FieldCount; i++)
                        {
                            m.Add(reader.GetName(i), reader.GetInt32(reader.GetName(i)));
                        }

                        measurementList.Add(m);
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

            Console.WriteLine("Alle Daten wurden eingelesen.");
            Console.ReadLine();

            playerList.PrintAll();

            Console.WriteLine("Press any key to print measurements.");
            Console.ReadLine();

            measurementList.PrintAll();

            Console.ReadLine();

        }
    }
}
