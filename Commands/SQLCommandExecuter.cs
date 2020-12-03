using MySql.Data.MySqlClient;
using RL_DBMU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public class SQLCommandExecuter : CommandExecuter
    {
        public override void Execute(string cmd, string[] args)
        {
            if (args.Length == 0)
            {
                Utils.WriteLine("§esql <§7Befehl§e>");
            }
            else
            {
                MySqlDataReader reader = Utils.ExecuteQuery(String.Join(" ", args));

                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string name = reader.GetName(i);
                            Utils.Write("§f" + name + " §7| ");
                        }
                        Console.WriteLine();

                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string name = reader.GetName(i);
                                string value = reader.GetString(name);
                                Utils.Write("§6" + value + " §7| ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                    reader.Close();
                }
            }
        }
    }
}
