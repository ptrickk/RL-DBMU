using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Commands;
using System.Windows.Forms;

namespace RL_DBMU
{
    class Program
    {

        private static PlayerList _playerList = new PlayerList();
        private static MeasurementList _measurementList = new MeasurementList();
        private static bool running = false;

        public static PlayerList PlayerList { get { return _playerList; } set { _playerList = value; } }
        public static MeasurementList MeasurementList { get { return _measurementList; } set { _measurementList = value; } }
        
        [STAThread]
        static void Main(string[] args)
        {
            CommandListener.Add("help", new HelpCommandExecuter());
            CommandListener.Add("logout", new LogoutCommandExecuter());
            CommandListener.Add("list", new ListCommandExecuter());
            CommandListener.Add("fetch", new FetchCommandExecuter());
            CommandListener.Add("sql", new SQLCommandExecuter());
            CommandListener.Add("chart", new ChartCommandExecuter());
            CommandListener.Add("add", new AddCommandExecuter());
            CommandListener.Add("analyze", new AnalyzeCommandExecuter());

            running = true;

            while (running)
            {

                ConsoleCommand cmd = new ConsoleCommand(Console.ReadLine());
                int result = CommandListener.CheckCommand(cmd);

                if (result == 0)
                {
                    Utils.WriteLine("§4Der Befehl §c" + cmd.Command + " §4ist nicht bekannt.");
                }

            }

        }

        public static void Stop()
        {
            running = false;
        }

    }
}
