using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commands;
using RL_DBMU;

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
            if (command.Command.Length == 0)
            {
                return 2;
            }
            foreach (KeyValuePair<string, CommandExecuter> pair in _executers)
            {
                if (pair.Key == command.Command || pair.Value.alias.Contains(command.Command))
                {
                    pair.Value.Execute(command.Command, command.Arguments);
                    return 1;
                }
            }
            return 0;
        }

    }
}
