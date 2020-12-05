using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DBMU
{
    public class ConsoleCommand
    {
        private string _command = "";
        private List<string> _arguments = new List<string>();

        public string Command { get { return _command; } }
        public string[] Arguments { get { return _arguments.ToArray(); } }
        public int ArgumentCount { get { return _arguments.Count; } }

        public ConsoleCommand(string raw)
        {
            string[] temp = raw.Split(null);
            _command = temp[0];
            for (int i = 1; i < temp.Length; i++)
            {
                _arguments.Add(temp[i]);
            }
        }

        public void Print()
        {
            Console.WriteLine("-- Command --");
            Console.WriteLine("Command: " + Command);
            Console.WriteLine("ArgsCount: " + ArgumentCount);
            Console.WriteLine("Args: ");
            int i = 0;
            foreach (string arg in _arguments)
            {
                Console.WriteLine(i + ": " + arg);
                i++;
            }
            Console.WriteLine();
        }

    }

}
