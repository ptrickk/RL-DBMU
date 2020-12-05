using RL_DBMU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public class FetchCommandExecuter : CommandExecuter
    {
        public override void Execute(string cmd, string[] args)
        {
            if (args.Length == 0)
            {
                Utils.WriteLine("§efetch <§7pl§e|§7m§e|§7a§e>");
            }
            else if (args.Length == 1)
            {
                if (args[0] == "pl")
                {
                    Utils.WriteLine("§fSpielerdaten werden abgerufen...");
                    Utils.FetchPlayers(Program.PlayerList);
                    Utils.WriteLine("§fSpielerdaten wurden abgerufen.");
                }
                else if (args[0] == "m")
                {
                    Utils.WriteLine("§fMessungsdaten werden abgerufen...");
                    Utils.FetchMeasurements(Program.MeasurementList);
                    Utils.WriteLine("§fMessungsdaten wurden abgerufen.");
                }
                else if (args[0] == "a")
                {
                    Utils.WriteLine("§fSpielerdaten werden abgerufen...");
                    Utils.FetchPlayers(Program.PlayerList);
                    Utils.WriteLine("§fSpielerdaten wurden abgerufen.");
                    Utils.WriteLine("");
                    Utils.WriteLine("§fMessungsdaten werden abgerufen...");
                    Utils.FetchMeasurements(Program.MeasurementList);
                    Utils.WriteLine("§fMessungsdaten wurden abgerufen.");
                }
            }
        }
    }
}
