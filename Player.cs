using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DMBU
{
    public class Player
    {

        private int _playerID;
        private string _name;
        private string _playerName;

        public int PlayerID { get { return _playerID; } }
        public string Name { get { return _name; } }
        public string PlayerName { get { return _playerName; } }

        public Player(int playerID, string name, string playerName)
        {
            _playerID = playerID;
            _name = name;
            _playerName = playerName;
        }

        public void Print()
        {
            Console.WriteLine("-- " + _playerName + " --");
            Console.WriteLine("ID:\t\t\t" + _playerID);
            Console.WriteLine("Name:\t\t\t" + _name);
            Console.WriteLine("Playername:\t\t" + _playerName);
            Console.WriteLine();
        }

    }

    public class PlayerList
    {
        private List<Player> _players = new List<Player>();

        public bool HasPlayer(Player player)
        {
            foreach (Player Lplayer in _players)
            {
                if (Lplayer.PlayerID == player.PlayerID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasPlayerID(int id)
        {
            foreach (Player Lplayer in _players)
            {
                if (Lplayer.PlayerID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasPlayerName(string playerName)
        {
            foreach (Player Lplayer in _players)
            {
                if (Lplayer.PlayerName == playerName)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(Player player)
        {
            if (HasPlayer(player))
            {
                return;
            }
            _players.Add(player);
        }

        public void Remove(Player player)
        {
            if (HasPlayer(player))
            {
                _players.Remove(player);
            }
        }

        public void PrintAll()
        {
            foreach (Player player in _players)
            {
                player.Print();
            }
        }
    }
}
