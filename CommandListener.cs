using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL_DMBU;

namespace RL_DBMU
{
    public class CommandListener
    {

        private static Dictionary<string, CommandExecuter> _executers = new Dictionary<string, CommandExecuter>();

        public static void Add(string command, CommandExecuter executer)
        {
            _executers.Add(command, executer);
        }

        public static int CheckCommand(ConsoleCommand command)
        {
            if (_executers.ContainsKey(command.Command))
            {
                _executers[command.Command].Execute(command.Command, command.Arguments);
                return 1;
            }
            return 0;
        }

    }
}
