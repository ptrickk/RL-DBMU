using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DBMU
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
            Utils.WriteLine("§8---§7--- §f" + _playerName + " §7---§8---");
            Utils.WriteLine("§6ID:\t\t\t§e" + _playerID);
            Utils.WriteLine("§6Name:\t\t\t§e" + _name);
            Utils.WriteLine("§6Playername:\t\t§e" + _playerName);
            Utils.WriteLine("");
        }

    }

    public class PlayerList : IEnumerable
    {
        private List<Player> _players = new List<Player>();

        public int Count { get { return _players.Count; } }
        public bool IsEmpty { get { return _players.Count == 0; } }
        public Player this[int index]
        {
            get { return _players[index]; }
            set { _players[index] = value; }
        }

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

        public Player GetPlayerByPlayerID(int playerID)
        {
            if (HasPlayerID(playerID))
            {
                foreach (Player player in _players) {
                    if (player.PlayerID == playerID)
                    {
                        return player;
                    }
                }
            }
            return null;
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

        public void Clear()
        {
            _players.Clear();
        }

        public void PrintAll()
        {
            foreach (Player player in _players)
            {
                player.Print();
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _players.GetEnumerator();
        }
    }
}
