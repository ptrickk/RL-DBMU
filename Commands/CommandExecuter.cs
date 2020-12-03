using RL_DBMU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public abstract class CommandExecuter
    {
        public string[] alias = { };
        public string helpMessage;
        public abstract void Execute(string cmd, string[] args);
        protected virtual void PrintHelp()
        {
            Utils.WriteLine(helpMessage);
        }

    }
}
