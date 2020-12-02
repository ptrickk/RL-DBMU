using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DMBU
{

    public enum MeasurementDataType
    {
        INT,
        DATE,
        VARCHAR,
        UNKNOWN
    }

    public class MeasurementData
    {
        private string _name;
        private string _value;
        private MeasurementDataType _type;

        public string Name { get { return _name; } }
        public string Value { get { return _value; } }
        public MeasurementDataType Type { get { return _type; } }

        public MeasurementData(string name, string value, MeasurementDataType type)
        {
            _value = value;
            _name = name;
            _type = type;
        }

        public MeasurementData(string name, int value, MeasurementDataType type)
        {
            _value = value.ToString();
            _name = name;
            _type = type;
        }

        public MeasurementData(string name, DateTime value, MeasurementDataType type)
        {
            _value = value.ToString();
            _name = name;
            _type = type;
        }

        public void Print()
        {
            Console.WriteLine(_type.ToString() + " : " +  _name + ":\t\t\t" + _value);
            //Console.SetCursorPosition(0, 0);
        }
    }

    public class Measurement
    {

        private List<MeasurementData> _measurementData = new List<MeasurementData>();

        private int _measurementID;
        private DateTime _date;
        private int _playerID;

        public int MeasurementID { get { return _measurementID; } }
        public int PlayerID { get { return _playerID; } }
        public DateTime Date { get { return _date; } }

        public Measurement(int measurementID, DateTime date, int playerID)
        {
            _measurementID = measurementID;
            _date = date;
            _playerID = playerID;
        }

        public void Add(MeasurementData data)
        {
            if (HasMeasurementWithName(data.Name))
            {
                return;
            }
            _measurementData.Add(data);
        }

        public void Add(string name, string value)
        {
            MeasurementData data = new MeasurementData(name, value, MeasurementDataType.INT);
            if (HasMeasurementWithName(data.Name))
            {
                return;
            }
            _measurementData.Add(data);
        }

        public void Add(string name, int value)
        {
            MeasurementData data = new MeasurementData(name, value, MeasurementDataType.INT);
            if (HasMeasurementWithName(data.Name))
            {
                return;
            }
            _measurementData.Add(data);
        }

        /*public Measurement(int measurementID, DateTime date, int playerID, int games, int wins, int goals, int torschüsse, int vorlagen, int paraden, int hereingaben, int befreiungsschläge, int retter, int zerstörungen, int v3, int v2, int v1)
        {
            _measurementID = measurementID;
            _date = date;
            _playerID = playerID;

            datenList.Add(new MeasurementData("Spiele", , MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Siege", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Tore", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Torschüsse", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Vorlagen", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Paraden", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Hereingaben", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Befreiungsschläge", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Retter", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("Zerstörungen", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("3v3", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("2v2", id, MeasurementDataType.INT));
            datenList.Add(new MeasurementData("1v1", id, MeasurementDataType.INT));

            datenDict.Add("null", new MeasurementData("MessungsID", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Datum", id, MeasurementDataType.DATE));
            datenDict.Add("null", new MeasurementData("SpielerID", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Spiele", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Siege", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Tore", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Torschüsse", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Vorlagen", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Paraden", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Hereingaben", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Befreiungsschläge", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Retter", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("Zerstörungen", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("3v3", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("2v2", id, MeasurementDataType.INT));
            datenDict.Add("null", new MeasurementData("1v1", id, MeasurementDataType.INT));

        }*/

        public bool HasMeasurementWithName(string name)
        {
            foreach (MeasurementData data in _measurementData)
            {
                if (data.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public MeasurementData GetMeasurementByName(string name)
        {
            if (HasMeasurementWithName(name))
            {
                foreach(MeasurementData data in _measurementData)
                {
                    if (data.Name == name)
                    {
                        return data;
                    }
                }
            }
            return null;
        }

        public void Print()
        {
            Console.WriteLine("-- Measurement --");
            Console.WriteLine("MeasurementID:\t\t" + _measurementID);
            Console.WriteLine("Date:\t\t\t" + _date.Day + "." + _date.Month + "." + _date.Year);
            Console.WriteLine("PlayerID:\t\t" + _playerID);
            foreach (MeasurementData data in _measurementData)
            {
                data.Print();
            }
            Console.WriteLine();
        }

    }

    public class MeasurementList
    {
        private List<Measurement> _measurements = new List<Measurement>();

        public int Count { get { return _measurements.Count; } }

        public bool HasMeasurement(Measurement measurement)
        {
            foreach (Measurement Lmeasurement in _measurements)
            {
                if (Lmeasurement.MeasurementID == measurement.MeasurementID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasMeasurementID(int id)
        {
            foreach (Measurement Lmeasurement in _measurements)
            {
                if (Lmeasurement.MeasurementID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(Measurement measurement)
        {
            if (HasMeasurement(measurement))
            {
                return;
            }
            _measurements.Add(measurement);
        }

        public void Remove(Measurement measurement)
        {
            if (HasMeasurement(measurement))
            {
                _measurements.Remove(measurement);
            }
        }

        public void Clear()
        {
            _measurements.Clear();
        }

        public void PrintAll()
        {
            foreach (Measurement measurement in _measurements)
            {
                measurement.Print();
            }
        }

        public Measurement GetByID(int measurementID)
        {
            if(!HasMeasurementID(measurementID))return null;
            
            foreach(Measurement measurment in _measurements)
            {
                if (measurment.MeasurementID == measurementID) return measurment;
            }

            return null;
        }

        public Measurement GetByIndex(int index)
        {
            if (index >= _measurements.Count) return null;
            else return _measurements[index];
        }

        public MeasurementList GetByPlayerID(int playerID)
        {
            MeasurementList temp = new MeasurementList();

            foreach (Measurement measurment in _measurements)
            {
                if (measurment.PlayerID == playerID) temp.Add(measurment);
            }

            return temp;
        }
    }
}