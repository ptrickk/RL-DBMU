using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DBMU
{
    public class Utils
    {

        public static MySqlConnection EstablishConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=rocketleague;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            return databaseConnection;
        }

        public static void OpenConnection(MySqlConnection connection)
        {
            connection.Open();
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }

        public static MySqlDataReader ExecuteQuery(string query)
        {

            MySqlConnection connection = EstablishConnection();

            MySqlCommand command = new MySqlCommand(query, connection);
            command.CommandTimeout = 60;
            MySqlDataReader reader = null; 
            try
            {
                OpenConnection(connection);

                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                //CloseConnection(connection);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return reader;
        }

        public static void AddPlayer(string name, string playername)
        {
            ExecuteQuery("INSERT INTO `spieler` (`SpielerID`, `Name`, `Spielername`) VALUES (NULL, '" + name + "', '" + playername + "');");
        }

        public static void FetchPlayers(PlayerList list)
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

        public static void FetchMeasurements(MeasurementList list)
        {
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

                        Measurement measurement = new Measurement(
                            reader.GetInt32("MessungsID"),
                            reader.GetDateTime("Datum"),
                            reader.GetInt32("SpielerID")
                            );

                        for (int i = 3; i < reader.FieldCount; i++)
                        {
                            measurement.Add(reader.GetName(i), reader.GetInt32(reader.GetName(i)));
                        }

                        list.Add(measurement);
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
        }

        public static void WriteLine(string raw)
        {
            raw = raw.Replace("§", "$§");
            string[] strings = raw.Split('$');
            bool background = false;
            foreach (string str in strings)
            {
                //background = false;
                string temp = str;
                ConsoleColor color = ConsoleColor.White;
                if (str.StartsWith("§"))
                {
                    string colorCode = str.Substring(str.IndexOf("§"), 2);
                    temp = str.Replace(colorCode, null);
                    switch (colorCode)
                    {
                        case "§l":
                            //background = true;
                            break;
                        case "§0":
                            color = ConsoleColor.Black;
                            break;
                        case "§1":
                            color = ConsoleColor.DarkBlue;
                            break;
                        case "§2":
                            color = ConsoleColor.DarkGreen;
                            break;
                        case "§3":
                            color = ConsoleColor.DarkCyan;
                            break;
                        case "§4":
                            color = ConsoleColor.DarkRed;
                            break;
                        case "§5":
                            color = ConsoleColor.DarkMagenta;
                            break;
                        case "§6":
                            color = ConsoleColor.DarkYellow;
                            break;
                        case "§7":
                            color = ConsoleColor.Gray;
                            break;
                        case "§8":
                            color = ConsoleColor.DarkGray;
                            break;
                        case "§9":
                            color = ConsoleColor.Blue;
                            break;
                        case "§a":
                            color = ConsoleColor.Green;
                            break;
                        case "§b":
                            color = ConsoleColor.Cyan;
                            break;
                        case "§c":
                            color = ConsoleColor.Red;
                            break;
                        case "§d":
                            color = ConsoleColor.Magenta;
                            break;
                        case "§e":
                            color = ConsoleColor.Yellow;
                            break;
                        case "§f":
                            color = ConsoleColor.White;
                            break;
                    }
                }
                if (background)
                {
                    if (color == ConsoleColor.White)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.BackgroundColor = color;
                }
                else
                {
                    Console.ForegroundColor = color;
                }
                Console.Write(temp);
            }
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Write(string raw)
        {
            raw = raw.Replace("§", "$§");
            string[] strings = raw.Split('$');
            bool background = false;
            foreach (string str in strings)
            {
                //background = false;
                string temp = str;
                ConsoleColor color = ConsoleColor.White;
                if (str.StartsWith("§"))
                {
                    string colorCode = str.Substring(str.IndexOf("§"), 2);
                    temp = str.Replace(colorCode, null);
                    switch (colorCode)
                    {
                        case "§l":
                            //background = true;
                            break;
                        case "§0":
                            color = ConsoleColor.Black;
                            break;
                        case "§1":
                            color = ConsoleColor.DarkBlue;
                            break;
                        case "§2":
                            color = ConsoleColor.DarkGreen;
                            break;
                        case "§3":
                            color = ConsoleColor.DarkCyan;
                            break;
                        case "§4":
                            color = ConsoleColor.DarkRed;
                            break;
                        case "§5":
                            color = ConsoleColor.DarkMagenta;
                            break;
                        case "§6":
                            color = ConsoleColor.DarkYellow;
                            break;
                        case "§7":
                            color = ConsoleColor.Gray;
                            break;
                        case "§8":
                            color = ConsoleColor.DarkGray;
                            break;
                        case "§9":
                            color = ConsoleColor.Blue;
                            break;
                        case "§a":
                            color = ConsoleColor.Green;
                            break;
                        case "§b":
                            color = ConsoleColor.Cyan;
                            break;
                        case "§c":
                            color = ConsoleColor.Red;
                            break;
                        case "§d":
                            color = ConsoleColor.Magenta;
                            break;
                        case "§e":
                            color = ConsoleColor.Yellow;
                            break;
                        case "§f":
                            color = ConsoleColor.White;
                            break;
                    }
                }
                if (background)
                {
                    if (color == ConsoleColor.White)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.BackgroundColor = color;
                }
                else
                {
                    Console.ForegroundColor = color;
                }
                Console.Write(temp);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
