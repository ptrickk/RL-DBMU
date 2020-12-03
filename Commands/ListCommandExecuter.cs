using RL_DBMU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public class ListCommandExecuter : CommandExecuter
    {

        public ListCommandExecuter()
        {
            alias = new string[] { "ls" };
        }
        public override void Execute(string cmd, string[] args)
        {
            if (args.Length == 0)
            {
                Utils.WriteLine("§elist <§7pl§e|§7m§e> [§7-id§e] <§7ID§e>");
            }
            else if (args.Length == 1)
            {
                if (args[0] == "pl")
                {
                    if (Program.PlayerList.IsEmpty)
                    {
                        Utils.WriteLine("§fDie Spielerliste ist leer.");
                    }
                    else
                    {
                        Program.PlayerList.PrintAll();
                    }
                }
                else if (args[0] == "m")
                {
                    if (Program.MeasurementList.IsEmpty)
                    {
                        Utils.WriteLine("§fDie Messungsliste ist leer.");
                    }
                    else
                    {
                        Program.MeasurementList.PrintAll();
                    }
                }
            }
            else if (args.Length == 2)
            {

            }
            else if (args.Length == 3)
            {
                if (args[1] == "-id")
                {
                    int id;
                    if (int.TryParse(args[2], out id))
                    {
                        if (args[0] == "pl")
                        {
                            if (Program.PlayerList.IsEmpty)
                            {
                                Utils.WriteLine("§fDie Spielerliste ist leer.");
                                Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch pl §8benutzen");
                            }
                            else
                            {
                                if (Program.PlayerList.HasPlayerID(id))
                                {
                                    Program.PlayerList.GetPlayerByPlayerID(id).Print();
                                }
                                else
                                {
                                    Utils.WriteLine("§fDie Spielerliste enthält keinen Spieler mit der Spielernummer §c" + id);
                                }
                            }
                        }
                        else if (args[0] == "m")
                        {
                            if (Program.MeasurementList.IsEmpty)
                            {
                                Utils.WriteLine("§fDie Messungsliste ist leer.");
                                Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch m §8benutzen");
                            }
                            else
                            {
                                if (Program.MeasurementList.HasMeasurementID(id))
                                {
                                    Program.MeasurementList.GetMeasurementByMeasurementID(id).Print();
                                }
                                else
                                {
                                    Utils.WriteLine("§fDie Messungsliste enthält keine Messung mit der Messungsnummer §c" + id);
                                }
                            }
                        }
                    }
                }
            }
            else if (args.Length == 4)
            {

            }
        }
    }
}

/* if (cmd.Command == "list")
                {
                    if (cmd.ArgumentCount == 0)
                    {
                        Utils.WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                    }
                    else if (cmd.ArgumentCount == 1)
                    {
                        if (cmd.Arguments[0] == "pl")
                        {
                            playerList.PrintAll();
                        }
                        else if (cmd.Arguments[0] == "m")
                        {
                            measurementList.PrintAll();
                        }
                        else
                        {
                            Utils.WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                        }
                    }
                    else if (cmd.ArgumentCount == 2)
                    {
                        Utils.WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                    }
                    else if (cmd.ArgumentCount == 3)
                    {
                        int id;
                        if (cmd.Arguments[1] == "-i" && int.TryParse(cmd.Arguments[2], out id))
                        {
                            if (cmd.Arguments[0] == "pl")
                            {
                                if (playerList.HasPlayerID(id))
                                {
                                    playerList.GetPlayerByPlayerID(id).Print();
                                }
                                else
                                {
                                    Utils.WriteLine("§fKein Spieler mit der SpielerID §e" + id + " §fgefunden");
                                }
                            }
                            else if (cmd.Arguments[0] == "m")
                            {
                                if (measurementList.HasMeasurementID(id))
                                {
                                    measurementList.GetLatestMeasurementFromPlayerByPlayerID(id).Print();
                                }
                                else
                                {
                                    Utils.WriteLine("§fKeine Messung mit der MessungsID §e" + id + " §fgefunden");
                                }
                            }
                            else
                            {
                                Utils.WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                            }
                        }
                    }
                    else
                    {
                        Utils.WriteLine("§elist §f[§epl | m§f] §8-i <id>§f: Lists data from given database");
                    }
                }
             */
