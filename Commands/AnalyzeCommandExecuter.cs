using RL_DBMU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commands
{
    public class AnalyzeCommandExecuter : CommandExecuter
    {
        public AnalyzeCommandExecuter()
        {
            helpMessage = "§eanalyze <§7pid§e> [§7n§e]";
            alias = new string[] { "az" };
        }

        public override void Execute(string cmd, string[] args)
        {
            if(args.Length == 0)
            {
                PrintHelp();
            }
            else if(args.Length == 1)
            {
                PrintHelp();
            }
            else if(args.Length == 2)
            {
                int playerID = -1;
                if(int.TryParse(args[0], out playerID))
                {
                    if (Program.MeasurementList.HasMeasurementsWithPlayerID(playerID))
                    {
                        if(args[1] == "n")
                        {
                            MeasurementList playerList = Program.MeasurementList.GetListByPlayerID(playerID);
                            Measurement m = playerList.GetLatestMeasurementFromPlayerByPlayerID(playerID);
                            playerList.Remove(m);
                            Measurement prev = playerList.GetLatestMeasurementFromPlayerByPlayerID(playerID);

                            AnalyticsSheet sheet = new AnalyticsSheet(m, prev);
                            sheet.Print();
                        }
                        else if(args[1] == "c")
                        {
                            MeasurementList playerList = Program.MeasurementList.GetListByPlayerID(playerID);

                            Application.EnableVisualStyles();
                            Application.Run(new AnalyzeForm(playerList));
                        }
                        else
                        {
                            PrintHelp();
                        }
                    }
                    else
                    {
                        Utils.WriteLine("§fDie Messungsliste enthält keine Messung mit der Spielernummer §c" + playerID);
                    }
                }
            }
            else
            {
                PrintHelp();
            }
        }
    }
}
