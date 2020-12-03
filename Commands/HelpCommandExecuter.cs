using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL_DBMU;

namespace Commands
{
    public class HelpCommandExecuter : CommandExecuter
    {

        public HelpCommandExecuter()
        {
            //alias = new string[] { };
        }

        public override void Execute(string cmd, string[] args)
        {
            if (args.Length == 0)
            {
                Utils.WriteLine("§ehelp§f: Zeigt dieses Menü");
                Utils.WriteLine("§elist <§7pl§e|§7m§e> [§7-id§e] <§7ID§e>§f: Listet Daten auf");
                Utils.WriteLine("§esql <§7Befehl§e>§f: SQLBefehle ausführen");
                Utils.WriteLine("§efetch <§7pl§e|§7m§e>§f: Daten aus den Tabellen laden");
                Utils.WriteLine("§elogout§f: Programm schließen");
            }
        }
    }
}
