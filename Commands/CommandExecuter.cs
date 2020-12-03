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
        public abstract void Execute(string cmd, string[] args);

    }
}
