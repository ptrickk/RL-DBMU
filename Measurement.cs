using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DBMU
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

    public class MeasurementList : IEnumerable
    {
        private List<Measurement> _measurements = new List<Measurement>();

        public int Count { get { return _measurements.Count; } }
        public bool IsEmpty { get { return _measurements.Count == 0; } }
        public Measurement this[int index]
        {
            get { return _measurements[index]; }
            set { _measurements[index] = value; }
        }

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

        public Measurement GetMeasurementByMeasurementID(int measurementID)
        {
            if (HasMeasurementID(measurementID))
            {
                foreach (Measurement measurment in _measurements)
                {
                    if (measurment.MeasurementID == measurementID) 
                    { 
                        return measurment; 
                    }
                }
            }
            return null;
        }

        public Measurement GetByListIndex(int index)
        {
            if (index < _measurements.Count) 
            {
                return _measurements[index];
            }
            return null;
        }

        public bool HasMeasurementsWithPlayerID(int playerID)
        {
            foreach (Measurement measurement in _measurements)
            {
                if (measurement.PlayerID == playerID)
                {
                    return true;
                }
            }
            return false;
        }

        public MeasurementList GetListByPlayerID(int playerID)
        {
            MeasurementList temp = null;
            if (HasMeasurementsWithPlayerID(playerID))
            {
                temp = new MeasurementList();

                foreach (Measurement measurment in _measurements)
                {
                    if (measurment.PlayerID == playerID)
                    {
                        temp.Add(measurment);
                    }
                }
            }
            return temp;
        }

        public Measurement GetLatestMeasurementFromPlayerByPlayerID(int playerID)
        {
            MeasurementList playerList = GetListByPlayerID(playerID);

            if (playerList == null)
            {
                return null;
            }

            DateTime latest = new DateTime();
            Measurement latestMeasurement = playerList.GetByListIndex(0);

            for (int i = 0; i < playerList.Count; i++)
            {
                Measurement current_measurement = playerList.GetByListIndex(i);
                DateTime current = current_measurement.Date;

                if (i == 0 || latest < current)
                {
                    latestMeasurement = current_measurement;
                    latest = current;
                }

            }

            return latestMeasurement;
        }

        public IEnumerator GetEnumerator()
        {
            return _measurements.GetEnumerator();
        }
    }
}