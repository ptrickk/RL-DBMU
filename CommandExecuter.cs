using RL_DMBU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DBMU
{
    public abstract class CommandExecuter
    {

        public abstract void Execute(string cmd, string[] args);

    }
}
