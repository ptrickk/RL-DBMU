using RL_DBMU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commands
{
    public class ChartCommandExecuter : CommandExecuter
    {

        public ChartCommandExecuter()
        {
            helpMessage = "§echart <§7Feld§e> <§7SpielerID§e> [§7--a§e|§7--d§e]";
        }

        public override void Execute(string cmd, string[] args)
        {
            //chart <id>
            if (args.Length == 0)
            {
                PrintHelp();
            }
            else if (args.Length == 1)
            {
                //Declare PlayerID
                int playerID;

                //TryParse playerID
                if (int.TryParse(args[0], out playerID))
                {
                    //check if measurementList is empty or not
                    if (!Program.MeasurementList.IsEmpty)
                    {

                        //check if measurementList has entries with playerID
                        if (Program.MeasurementList.HasMeasurementsWithPlayerID(playerID))
                        {
                            //open the window with the chart
                            Application.EnableVisualStyles();
                            Application.Run(new ChartForm(Program.MeasurementList.GetListByPlayerID(playerID)));
                        }
                        else
                        {
                            Utils.WriteLine("§fDie Messungsliste enthält keine Messung mit der Spielernummer §c" + playerID);
                        }
                    }
                    else
                    {
                        Utils.WriteLine("§fDie Messungsliste ist leer.");
                        Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch m §8benutzen");
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
