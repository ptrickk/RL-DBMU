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

    /// <summary>
    /// Stores values of data 
    /// </summary>
    public class MeasurementData
    {
        /// <summary>
        /// the name of the column in the database
        /// </summary>
        private string _name;
        /// <summary>
        /// the value we are pulling from the database
        /// </summary>
        private string _value;
        /// <summary>
        /// the datatype that the value is stored with in the database
        /// </summary>
        private MeasurementDataType _type;
        /// <summary>
        /// get for the name of the column in the database
        /// </summary>
        public string Name { get { return _name; } }
        /// <summary>
        /// get for the value we are storing from the database
        /// </summary>
        public string Value { get { return _value; } } // get for _value
        /// <summary>
        /// get for the datatype that the value is stored with in the database
        /// </summary>
        public MeasurementDataType Type { get { return _type; } } // 

        /// <summary>
        /// Basic constructor for creating a new measurment segment
        /// </summary>
        /// <param name="name">the name of the column in the database</param>
        /// <param name="value">the value we are pulling from the database</param>
        /// <param name="type">the datatype that the value is stored with in the database</param>
        public MeasurementData(string name, string value, MeasurementDataType type)
        {
            _value = value;
            _name = name;
            _type = type;
        }
        /// <summary>
        /// Basic constructor for creating a new measurment segment
        /// </summary>
        /// <param name="name">the name of the column in the database</param>
        /// <param name="value">the value we are pulling from the database. its automaticly converted to a string</param>
        /// <param name="type">the datatype that the value is stored with in the database</param>
        public MeasurementData(string name, int value, MeasurementDataType type)
        {
            _value = value.ToString();
            _name = name;
            _type = type;
        }
        /// <summary>
        /// Basic constructor for creating a new measurment segment which stores a date
        /// </summary>
        /// <param name="name">the name of the column in the database</param>
        /// <param name="value">the date that should be stored</param>
        /// <param name="type">the datatype that the value is stored with in the database (preffered: DATE)</param>
        public MeasurementData(string name, DateTime value, MeasurementDataType type)
        {
            _value = value.ToString();
            _name = name;
            _type = type;
        }

        /// <summary>
        /// prints out the type, name and value of the measurment segment
        /// </summary>
        public void Print()
        {
            Console.WriteLine(_type.ToString() + " : " +  _name + ":\t\t\t" + _value);
            //Console.SetCursorPosition(0, 0);
        }
    }
    /// <summary>
    /// stores and manages a row of data from the messung-table
    /// </summary>
    public class Measurement
    {
        /// <summary>
        /// stores the segments of the measurment
        /// </summary>
        private List<MeasurementData> _measurementData = new List<MeasurementData>();
        /// <summary>
        /// the unique id of the measurment
        /// </summary>
        private int _measurementID;
        /// <summary>
        /// the date of the measurment
        /// </summary>
        private DateTime _date;
        /// <summary>
        /// the playerID of the measurment
        /// </summary>
        private int _playerID;
        /// <summary>
        /// get the unique id of the measurment
        /// </summary>
        public int MeasurementID { get { return _measurementID; } }
        /// <summary>
        /// get the date of the measurment
        /// </summary>
        public DateTime Date { get { return _date; } }
        /// <summary>
        /// get the playerID of the measurment
        /// </summary>
        public int PlayerID { get { return _playerID; } }

        /// <summary>
        /// constructor for a measurment
        /// </summary>
        /// <param name="measurementID">the unique id of the measurment</param>
        /// <param name="date">the date of the measurment</param>
        /// <param name="playerID">the playerID of the measurment</param>
        public Measurement(int measurementID, DateTime date, int playerID)
        {
            _measurementID = measurementID;
            _date = date;
            _playerID = playerID;
        }
        /// <summary>
        /// adds a measurment segment to the measurment. checks if the name of the measurment isnt already added.
        /// </summary>
        /// <param name="data">the segment that should be added if the name of the measurment isnt already added</param>
        public void Add(MeasurementData data)
        {
            if (HasMeasurementWithName(data.Name))
            {
                return;
            }
            _measurementData.Add(data);
        }
        /// <summary>
        /// creates a new MeasurmentData with parsed parameters, which is added to the measurment.
        /// its only added if there isnt a MeasurmentData in the Measurment with the same name
        /// </summary>
        /// <param name="name">the name of the measurent segment that will be created and added</param>
        /// <param name="value">the value of the measurent segment that will be created and added</param>
        public void Add(string name, string value)
        {
            MeasurementData data = new MeasurementData(name, value, MeasurementDataType.INT);
            if (HasMeasurementWithName(data.Name))
            {
                return;
            }
            _measurementData.Add(data);
        }
        /// <summary>
        /// creates a new MeasurmentData with parsed parameters, which is added to the measurment.
        /// its only added if there isnt a MeasurmentData in the Measurment with the same name
        /// </summary>
        /// <param name="name">the name of the measurent segment that will be created and added</param>
        /// <param name="value">the value of the measurent segment that will be created and added</param>
        public void Add(string name, int value)
        {
            MeasurementData data = new MeasurementData(name, value, MeasurementDataType.INT);
            if (HasMeasurementWithName(data.Name))
            {
                return;
            }
            _measurementData.Add(data);
        }
        /// <summary>
        /// checks if the MeasurmentData-List has a MeasurmentData with the same name.
        /// </summary>
        /// <param name="name">the name that is getting checked for</param>
        /// <returns>true if there is a MeasurementData with the same name and false if not</returns>
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
        /// <summary>
        /// Searches for a MeasurementData by its name
        /// </summary>
        /// <param name="name">the name that is used to identify the MeasurmentData</param>
        /// <returns>the MeasurmentData that has the same name as the parameter. if there is none NULL is returned</returns>
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
        /// <summary>
        /// prints out the Measurment with its measurmentID, its date, its playrID and every MeasurmentData in it
        /// </summary>
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
    /// <summary>
    /// stores and manages all the data from the messung-table
    /// </summary>
    public class MeasurementList : IEnumerable
    {
        private List<Measurement> _measurements = new List<Measurement>();//stores all measurments
        /// <summary>
        /// returns the length of the _measurements list
        /// </summary>
        public int Count { get { return _measurements.Count; } }
        /// <summary>
        /// returns if the _measuremnts list is empty
        /// </summary>
        public bool IsEmpty { get { return _measurements.Count == 0; } }
        public Measurement this[int index]// get and set for _measurments
        {
            get { return _measurements[index]; }
            set { _measurements[index] = value; }
        }
        /// <summary>
        /// Checks if the parsed <paramref name="measurement"/>  is equal to a measurment in the list
        /// </summary>
        /// <param name="measurement">the measurment that is being checked for an identical copy in the list</param>
        /// <returns>true if there is an identical measurment in the list and false if not</returns>
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
        /// <summary>
        /// checks the list for an measurment with the same measurmentID as the value of <paramref name="id"/> 
        /// </summary>
        /// <param name="id">the id that is being checked for in the list</param>
        /// <returns>true if there is a measurment in the list with an identical measurmentId and false if not</returns>
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
        /// <summary>
        /// Adds a measurment to the _measurments list. 
        /// it only adds the measuremnt if there is no identical measurment in the list
        /// </summary>
        /// <param name="measurement"></param>
        public void Add(Measurement measurement)
        {
            if (HasMeasurement(measurement))
            {
                return;
            }
            _measurements.Add(measurement);
        }
        /// <summary>
        /// removes a measurment for the _measurments list
        /// </summary>
        /// <param name="measurement">removes every measurement that is identical to this one</param>
        public void Remove(Measurement measurement)
        {
            if (HasMeasurement(measurement))
            {
                _measurements.Remove(measurement);
            }
        }
        /// <summary>
        /// deletes every measurment in the _measurments list
        /// </summary>
        public void Clear()
        {
            _measurements.Clear();
        }
        /// <summary>
        /// prints out every measurment in the _measurments list
        /// </summary>
        public void PrintAll()
        {
            foreach (Measurement measurement in _measurements)
            {
                measurement.Print();
            }
        }
        /// <summary>
        /// searches for a measurment with an matching measurmentID
        /// </summary>
        /// <param name="measurementID">the id that is being searched for in the _measurments list</param>
        /// <returns>the measurment with identical measuremntID as <paramref name="measurementID"/> and null if there is not matching measurment</returns>
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
        /// <summary>
        /// returns a measurment at a specific index in the list if the index is not out of bounds
        /// </summary>
        /// <param name="index">the index of the measurment that should be returned</param>
        /// <returns>the measuremnt at the selected index and null if the index is out of bounds</returns>
        public Measurement GetByListIndex(int index)
        {
            if (index >= 0 && index < _measurements.Count  ) 
            {
                return _measurements[index];
            }
            return null;
        }
        /// <summary>
        /// checks the _measurment list for measurments with an identical playerID as the value of <paramref name="playerID"/>
        /// </summary>
        /// <param name="playerID">the playerID that is being checked for</param>
        /// <returns>true if there is atleast one measurment with the parsed playerID and false if there are none</returns>
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
        /// <summary>
        /// creates a new MeasurmentList with all measurments that have the same playerID as the value of <paramref name="playerID"/>
        /// </summary>
        /// <param name="playerID">the playerID that is used for selecting the measurments for the new MeasurmentList that is returned</param>
        /// <returns>a MeasurmentList with every measurment that has the same playerID as the value of <paramref name="playerID"/></returns>
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
        /// <summary>
        /// searches for the latest measurment in the _measurment list (by date) of the player with the parsed <paramref name="playerID"/> 
        /// </summary>
        /// <param name="playerID">the playerID of the newest measurment (by date) we are looking for</param>
        /// <returns>the latest measurment of all the measurments by a certain player which is specified by <paramref name="playerID"/> </returns>
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
        /// <returns>the Enumerator of the _measurments list</returns>
        public IEnumerator GetEnumerator()
        {
            return _measurements.GetEnumerator();
        }
    }
}