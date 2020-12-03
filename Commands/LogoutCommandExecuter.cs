using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL_DBMU;

namespace Commands
{
    public class LogoutCommandExecuter : CommandExecuter
    {

        public LogoutCommandExecuter()
        {
            alias = new string[] { "q", "quit", "logout", "lg" };
        }

        public override void Execute(string cmd, string[] args)
        {

            if (alias.Contains(cmd))
            {
                Program.Stop();
            }

        }
    }
}
