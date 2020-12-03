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

        static bool running = false;

        static void Main(string[] args)
        {

            PlayerList playerList = new PlayerList();
            MeasurementList measurementList = new MeasurementList();

            FetchPlayers(playerList);
            FetchMeasurements(measurementList);

            WriteLine("Alle Daten wurden eingelesen.");
            Console.ReadLine();

            running = true;

            while (running)
            {

                ConsoleCommand cmd = new ConsoleCommand(Console.ReadLine());

                if (cmd.Command == "help")
                {
                    if (cmd.ArgumentCount == 0)
                    {
                        WriteLine("§ehelp §f: Lists all commands");
                        WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                        WriteLine("§eq §f: Closes command prompt");
                        WriteLine("§elogout §f: Closes command prompt");
                    }
                }

                if (cmd.Command == "list")
                {
                    if (cmd.ArgumentCount == 0)
                    {
                        WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                    }
                    else if (cmd.ArgumentCount == 1)
                    {
                        if (cmd.Arguments[0] == "pl")
                        {
                            playerList.PrintAll();
                        }
                        else if (cmd.Arguments[0] == "m")
                        {
                            measurementList.PrintAll();
                        }
                        else
                        {
                            WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                        }
                    }
                    else if (cmd.ArgumentCount == 2)
                    {
                        WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                    }
                    else if (cmd.ArgumentCount == 3)
                    {
                        int id;
                        if (cmd.Arguments[1] == "-i" && int.TryParse(cmd.Arguments[2], out id))
                        {
                            if (cmd.Arguments[0] == "pl")
                            {
                                if (playerList.HasPlayerID(id))
                                {
                                    playerList.GetPlayerByPlayerID(id).Print();
                                }
                                else
                                {
                                    WriteLine("§fKein Spieler mit der SpielerID §e" + id + " §fgefunden");
                                }
                            }
                            else if (cmd.Arguments[0] == "m")
                            {
                                if (measurementList.HasMeasurementID(id))
                                {

                                }
                                else
                                {
                                    WriteLine("§fKeine Messung mit der MessungsID §e" + id + " §fgefunden");
                                }
                            }
                            else
                            {
                                WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                            }
                        }
                    }
                    else
                    {
                        WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                    }
                }

                if (cmd.Command == "q" || cmd.Command == "logout")
                {
                    running = false;
                }

            }

        }

        static void WriteLine(string raw)
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
            Console.ForegroundColor = ConsoleColor.White;
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

        static void AddPlayer(string name, string playername)
        {
            ExecuteQuery("INSERT INTO `spieler` (`SpielerID`, `Name`, `Spielername`) VALUES (NULL, '" + name + "', '" + playername + "');");
        }

        static void FetchPlayers(PlayerList list)
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

        static void FetchMeasurements(MeasurementList list)
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

                        Measurement m = new Measurement(
                            reader.GetInt32("MessungsID"),
                            reader.GetDateTime("Datum"),
                            reader.GetInt32("SpielerID")
                            );

                        for (int i = 3; i < reader.FieldCount; i++)
                        {
                            m.Add(reader.GetName(i), reader.GetInt32(reader.GetName(i)));
                        }

                        list.Add(m);
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

        static Measurement getLatestMeasurment(MeasurementList list, int spielerID)
        {
            MeasurementList playerList = list.GetByPlayerID(spielerID);

            DateTime newest = new DateTime();
            Measurement newest_measurement = playerList.GetByIndex(0);

            for (int i = 0; i < playerList.Count; i++)
            {
                Measurement current_measurement = playerList.GetByIndex(i);
                DateTime current = current_measurement.Date;

                if (i == 0 || newest < current)
                {
                    newest_measurement = current_measurement;
                    newest = current;
                }

            }

            return newest_measurement;
        }

    }
}
