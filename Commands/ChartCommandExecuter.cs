using RL_DBMU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commands
{
    public class ChartCommandExecuter : CommandExecuter
    {

        public ChartCommandExecuter()
        {
            helpMessage = "§echart <§7Feld§e> <§7SpielerID§e> [§7--a§e|§7--d§e]";
        }

        public override void Execute(string cmd, string[] args)
        {
            //chart <f> <id> --a
            //chart <f> <id> --d
            //chart <f> <id> --d/a -i <id>
            if (args.Length == 0)
            {
                PrintHelp();
            }
            else if (args.Length == 1)
            {
                PrintHelp();
            }
            else if (args.Length == 2)
            {
                //Declare PlayerID
                int playerID;

                //TryParse playerID
                if (int.TryParse(args[1], out playerID))
                {
                    //check if measurementList is empty or not
                    if (!Program.MeasurementList.IsEmpty)
                    {

                        //check if measurementList has entries with playerID
                        if (Program.MeasurementList.HasMeasurementsWithPlayerID(playerID))
                        {

                            //create Value list for the chartForm contructor
                            List<List<int>> values = new List<List<int>>();
                            values.Add(new List<int>());
                            List<DateTime> dates = new List<DateTime>();

                            //Loop through measurements
                            foreach (Measurement measurement in Program.MeasurementList.GetListByPlayerID(playerID))
                            {
                                //check if measurement has entrie with the given field name
                                if (measurement.HasMeasurementWithName(args[0]))
                                {
                                    //tryparse value to int
                                    int value;
                                    if (int.TryParse(measurement.GetMeasurementByName(args[0]).Value, out value))
                                    {
                                        //add value to values
                                        values[0].Add(value);
                                        dates.Add(measurement.Date);
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            //open the window with the chart
                            Application.EnableVisualStyles();
                            Application.Run(new ChartForm(values, dates));
                        }
                        else
                        {
                            Utils.WriteLine("§fDie Messungsliste enthält keine Messung mit der Spielernummer §c" + playerID);
                        }
                    }
                    else
                    {
                        Utils.WriteLine("§fDie Messungsliste ist leer.");
                        Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch m §8benutzen");
                    }
                }
            }
            else if (args.Length == 3)
            {

                string option = args[2];

                //print complete option
                if (option == "--a")
                {

                    //Declare PlayerID
                    int playerID;

                    //TryParse playerID
                    if (int.TryParse(args[1], out playerID))
                    {
                        //check if measurementList is empty or not
                        if (!Program.MeasurementList.IsEmpty)
                        {

                            //check if measurementList has entries with playerID
                            if (Program.MeasurementList.HasMeasurementsWithPlayerID(playerID))
                            {

                                //create Value list for the chartForm contructor
                                List<List<int>> values = new List<List<int>>();
                                values.Add(new List<int>());
                                List<DateTime> dates = new List<DateTime>();

                                //Loop through measurements
                                foreach (Measurement measurement in Program.MeasurementList.GetListByPlayerID(playerID))
                                {
                                    //check if measurement has entrie with the given field name
                                    if (measurement.HasMeasurementWithName(args[0]))
                                    {
                                        //tryparse value to int
                                        int value;
                                        if (int.TryParse(measurement.GetMeasurementByName(args[0]).Value, out value))
                                        {
                                            //add value to values
                                            values[0].Add(value); 
                                            dates.Add(measurement.Date);
                                        }
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                //open the window with the chart
                                Application.EnableVisualStyles();
                                Application.Run(new ChartForm(values, dates));
                            }
                            else
                            {
                                Utils.WriteLine("§fDie Messungsliste enthält keine Messung mit der Spielernummer §c" + playerID);
                            }
                        }
                        else
                        {
                            Utils.WriteLine("§fDie Messungsliste ist leer.");
                            Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch m §8benutzen");
                        }
                    }
                }
                else if (option == "--d") //print difference option
                {

                    //Declare PlayerID
                    int playerID;

                    //TryParse playerID
                    if (int.TryParse(args[1], out playerID))
                    {
                        //check if measurementList is empty or not
                        if (!Program.MeasurementList.IsEmpty)
                        {

                            //check if measurementList has entries with playerID
                            if (Program.MeasurementList.HasMeasurementsWithPlayerID(playerID))
                            {

                                //create Value list for the chartForm contructor
                                List<List<int>> values = new List<List<int>>();
                                values.Add(new List<int>());
                                List<DateTime> dates = new List<DateTime>();

                                //Loop through measurements
                                MeasurementList temp = Program.MeasurementList.GetListByPlayerID(playerID);
                                for (int i = 1; i < temp.Count; i++)
                                {
                                    Measurement currentMeasurement = temp[i];
                                    Measurement prevMeasurement = temp[i - 1];
                                    //check if measurement has entrie with the given field name
                                    if (currentMeasurement.HasMeasurementWithName(args[0]) && prevMeasurement.HasMeasurementWithName(args[0]))
                                    {
                                        //tryparse value to int
                                        int previousValue;
                                        int currentValue;
                                        if (int.TryParse(currentMeasurement.GetMeasurementByName(args[0]).Value, out currentValue) && int.TryParse(prevMeasurement.GetMeasurementByName(args[0]).Value, out previousValue))
                                        {
                                            //add value to values
                                            values[0].Add(currentValue - previousValue);
                                            dates.Add(currentMeasurement.Date);
                                        }
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                //open the window with the chart
                                Application.EnableVisualStyles();
                                Application.Run(new ChartForm(values, dates));
                            }
                            else
                            {
                                Utils.WriteLine("§fDie Messungsliste enthält keine Messung mit der Spielernummer §c" + playerID);
                            }
                        }
                        else
                        {
                            Utils.WriteLine("§fDie Messungsliste ist leer.");
                            Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch m §8benutzen");
                        }
                    }
                }
                else
                {
                    PrintHelp();
                }
            }
            else if (args.Length == 4)
            {

            }
            else if (args.Length == 5)
            {

                string option = args[2];
                string option2 = args[3];

                if (option2 == "-i")
                {

                    //print complete option
                    if (option == "--a")
                    {

                        //Declare PlayerID
                        int playerID;
                        int compareID;

                        //TryParse playerID
                        if (int.TryParse(args[1], out playerID) && int.TryParse(args[4], out compareID))
                        {
                            //check if measurementList is empty or not
                            if (!Program.MeasurementList.IsEmpty)
                            {

                                //check if measurementList has entries with playerID
                                if (Program.MeasurementList.HasMeasurementsWithPlayerID(playerID) && Program.MeasurementList.HasMeasurementsWithPlayerID(compareID))
                                {

                                    //create Value list for the chartForm contructor
                                    List<List<int>> values = new List<List<int>>();
                                    values.Add(new List<int>());
                                    values.Add(new List<int>());
                                    List<DateTime> dates = new List<DateTime>();

                                    //Loop through measurements
                                    foreach (Measurement measurement in Program.MeasurementList.GetListByPlayerID(playerID))
                                    {
                                        //check if measurement has entrie with the given field name
                                        if (measurement.HasMeasurementWithName(args[0]))
                                        {
                                            //tryparse value to int
                                            int value;
                                            if (int.TryParse(measurement.GetMeasurementByName(args[0]).Value, out value))
                                            {
                                                //add value to values
                                                values[0].Add(value);
                                                dates.Add(measurement.Date);
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }

                                    foreach (Measurement measurement in Program.MeasurementList.GetListByPlayerID(compareID))
                                    {
                                        //check if measurement has entrie with the given field name
                                        if (measurement.HasMeasurementWithName(args[0]))
                                        {
                                            //tryparse value to int
                                            int value;
                                            if (int.TryParse(measurement.GetMeasurementByName(args[0]).Value, out value))
                                            {
                                                //add value to values
                                                values[1].Add(value);
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    //open the window with the chart
                                    Application.EnableVisualStyles();
                                    Application.Run(new ChartForm(values, dates));
                                }
                                else
                                {
                                    Utils.WriteLine("§fDie Messungsliste enthält keine Messung mit der Spielernummer §c" + playerID);
                                }
                            }
                            else
                            {
                                Utils.WriteLine("§fDie Messungsliste ist leer.");
                                Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch m §8benutzen");
                            }
                        }
                    }
                    else if (option == "--d") //print difference option
                    {

                        //Declare PlayerID
                        int playerID;

                        //TryParse playerID
                        if (int.TryParse(args[1], out playerID))
                        {
                            //check if measurementList is empty or not
                            if (!Program.MeasurementList.IsEmpty)
                            {

                                //check if measurementList has entries with playerID
                                if (Program.MeasurementList.HasMeasurementsWithPlayerID(playerID))
                                {

                                    //create Value list for the chartForm contructor
                                    List<List<int>> values = new List<List<int>>();
                                    values.Add(new List<int>());
                                    List<DateTime> dates = new List<DateTime>();

                                    //Loop through measurements
                                    MeasurementList temp = Program.MeasurementList.GetListByPlayerID(playerID);
                                    for (int i = 1; i < temp.Count; i++)
                                    {
                                        Measurement currentMeasurement = temp[i];
                                        Measurement prevMeasurement = temp[i - 1];
                                        //check if measurement has entrie with the given field name
                                        if (currentMeasurement.HasMeasurementWithName(args[0]) && prevMeasurement.HasMeasurementWithName(args[0]))
                                        {
                                            //tryparse value to int
                                            int previousValue;
                                            int currentValue;
                                            if (int.TryParse(currentMeasurement.GetMeasurementByName(args[0]).Value, out currentValue) && int.TryParse(prevMeasurement.GetMeasurementByName(args[0]).Value, out previousValue))
                                            {
                                                //add value to values
                                                values[0].Add(currentValue - previousValue);
                                                dates.Add(currentMeasurement.Date);
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    //open the window with the chart
                                    Application.EnableVisualStyles();
                                    Application.Run(new ChartForm(values, dates));
                                }
                                else
                                {
                                    Utils.WriteLine("§fDie Messungsliste enthält keine Messung mit der Spielernummer §c" + playerID);
                                }
                            }
                            else
                            {
                                Utils.WriteLine("§fDie Messungsliste ist leer.");
                                Utils.WriteLine("§8Entweder ist die Datenbank leer oder du musst noch §7fetch m §8benutzen");
                            }
                        }
                    }
                    else
                    {
                        PrintHelp();
                    }
                }
                else
                {
                    PrintHelp();
                }
            }
        }
    }
}
