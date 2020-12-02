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

            

            string measurementQuery = "SELECT * FROM messung Order by Datum ASC";

            MySqlConnection connection = EstablishConnection();
            MySqlCommand measurementCommand = new MySqlCommand(measurementQuery, connection);
            measurementCommand.CommandTimeout = 60;

            MySqlDataReader reader;

            // Let's do it !
            try
            {
                // Open the database
                OpenConnection(connection);
                
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
                CloseConnection(connection);
            }
            catch (Exception ex)
            {
                // Show any error message.
                Console.WriteLine(ex.ToString());
            }

            QueryPlayers(playerList);

            Console.WriteLine("Alle Daten wurden eingelesen.");
            Console.ReadLine();

            playerList.PrintAll();

            Console.WriteLine("Press any key to print measurements.");
            Console.ReadLine();

            measurementList.PrintAll();

            Console.ReadLine();

        }


        static MySqlConnection EstablishConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=rocketleague;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            return databaseConnection;
        }

        static void OpenConnection(MySqlConnection connection)
        {
            connection.Open();
        }

        static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }

        static void ExecuteQuery(string query)
        {

            MySqlConnection connection = EstablishConnection();

            MySqlCommand command = new MySqlCommand(query, connection);
            command.CommandTimeout = 60;

            try
            {
                OpenConnection(connection);

                MySqlDataReader reader = command.ExecuteReader();

                CloseConnection(connection);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void QueryPlayers(PlayerList list)
        {
            PlayerList playerList = list;

            string playerQuery = "SELECT * FROM spieler";

            MySqlConnection connection = EstablishConnection();
            MySqlCommand playerCommand = new MySqlCommand(playerQuery, connection);
            playerCommand.CommandTimeout = 60;


            MySqlDataReader reader;

            try
            {
                OpenConnection(connection);
                reader = playerCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Player player = new Player(reader.GetInt32("SpielerID"), reader.GetString("Name"), reader.GetString("Spielername"));

                        playerList.Add(player);
                    }
                }
                else
                {
                    Console.WriteLine("No Players found.");
                }

                reader.Close();

                CloseConnection(connection);
            }
            catch (Exception ex)
            {
                // Show any error message.
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
