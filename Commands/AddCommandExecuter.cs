using RL_DBMU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commands
{
    public class AddCommandExecuter : CommandExecuter
    {

        public AddCommandExecuter()
        {
            helpMessage = "§eadd <§7m§e|§7pl§e>";
        }

        public override void Execute(string cmd, string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
            }
            else if (args.Length == 1)
            {
                if (args[0] == "m")
                {
                    
                }
                else if (args[0] == "pl")
                {

                }
                else
                {
                    PrintHelp();
                }
            }
            else if (args.Length == 2)
            {
                int playerID;
                if (int.TryParse(args[1], out playerID))
                {
                    if (Program.PlayerList.IsEmpty)
                    {
                        Utils.WriteLine("§fDie Spielerliste ist leer.");
                        Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch pl §8benutzen");
                    }
                    else if (Program.PlayerList.HasPlayerID(playerID))
                    {
                        if (args[0] == "m")
                        {
                            Application.EnableVisualStyles();
                            Application.Run(new AddDataForm(Program.PlayerList.GetPlayerByPlayerID(playerID)));
                        }
                        else
                        {
                            PrintHelp();
                        }
                    }
                    else
                    {
                        Utils.WriteLine("§fDie Spielerliste enthält keinen Spieler mit der Spielernummer §c" + playerID);
                    }
                }
                else
                {
                    PrintHelp();
                }
            }
        }
    }
}
