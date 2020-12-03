using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DBMU
{
    public class Utils
    {

        public static void WriteLine(string raw)
        {
            raw = raw.Replace("§", "$§");
            string[] strings = raw.Split('$');
            bool background = false;
            foreach (string str in strings)
            {
                //background = false;
                string temp = str;
                ConsoleColor color = ConsoleColor.White;
                if (str.StartsWith("§"))
                {
                    string colorCode = str.Substring(str.IndexOf("§"), 2);
                    temp = str.Replace(colorCode, null);
                    switch (colorCode)
                    {
                        case "§l":
                            //background = true;
                            break;
                        case "§0":
                            color = ConsoleColor.Black;
                            break;
                        case "§1":
                            color = ConsoleColor.DarkBlue;
                            break;
                        case "§2":
                            color = ConsoleColor.DarkGreen;
                            break;
                        case "§3":
                            color = ConsoleColor.DarkCyan;
                            break;
                        case "§4":
                            color = ConsoleColor.DarkRed;
                            break;
                        case "§5":
                            color = ConsoleColor.DarkMagenta;
                            break;
                        case "§6":
                            color = ConsoleColor.DarkYellow;
                            break;
                        case "§7":
                            color = ConsoleColor.Gray;
                            break;
                        case "§8":
                            color = ConsoleColor.DarkGray;
                            break;
                        case "§9":
                            color = ConsoleColor.Blue;
                            break;
                        case "§a":
                            color = ConsoleColor.Green;
                            break;
                        case "§b":
                            color = ConsoleColor.Cyan;
                            break;
                        case "§c":
                            color = ConsoleColor.Red;
                            break;
                        case "§d":
                            color = ConsoleColor.Magenta;
                            break;
                        case "§e":
                            color = ConsoleColor.Yellow;
                            break;
                        case "§f":
                            color = ConsoleColor.White;
                            break;
                    }
                }
                if (background)
                {
                    if (color == ConsoleColor.White)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.BackgroundColor = color;
                }
                else
                {
                    Console.ForegroundColor = color;
                }
                Console.Write(temp);
            }
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
