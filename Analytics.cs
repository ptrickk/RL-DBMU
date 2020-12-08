using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL_DBMU
{
    enum AnalticsDataType
    {
        PERCANTAGE,
        VALUE,
        DIFFERENCE,
        UNKOWN
    }

    class Analytics
    {
        private float _value;
        private string _name;
        private AnalticsDataType _type;

        public float Value { get { return _value; } }
        public string Name { get { return _name; } }
        public AnalticsDataType Type { get { return _type; } }

        public Analytics(float value, string name, AnalticsDataType type)
        {
            _value = value;
            _name = name;
            _type = type;
        }

        public Analytics(int value, string name, AnalticsDataType type)
        {
            _value = value;
            _name = name;
            _type = type;
        }

        public void Print()
        {
            string s_value = "error";
            switch (_type)
            {
                case AnalticsDataType.DIFFERENCE:s_value = ((int)_value).ToString(); break;
                case AnalticsDataType.PERCANTAGE:s_value = _value.ToString("P2"); break;
                case AnalticsDataType.VALUE: s_value = _value.ToString("n3"); break;
                default: s_value = _value.ToString(); break;
            }
            Utils.WriteLine($"§8{_type, 10}§6{_name, -20}§e{s_value, 10}");
        }
    }

    class AnalyticsSheet
    {
        private List<Analytics> _analytics = new List<Analytics>();
        private DateTime _date;

        private Measurement _reference;
        private Measurement _prev_reference;

        public List<Analytics> Analytics {  get { return _analytics; } }

        public DateTime Date { get { return _date; } }

        public AnalyticsSheet(Measurement measurement, Measurement prev)
        {
            _reference = measurement;
            _prev_reference = prev;

            GenerateAnalytics(_reference, _prev_reference);
        }

        public AnalyticsSheet(MeasurementList measurementList, int measurmentID, int prev_measurmentID)
        {
            _reference = measurementList.GetMeasurementByMeasurementID(measurmentID);
            _prev_reference = measurementList.GetMeasurementByMeasurementID(prev_measurmentID);

            GenerateAnalytics(_reference, _prev_reference);
        }

        public AnalyticsSheet(MeasurementList measurementList, int playerID)
        {
            _reference = measurementList.GetLatestMeasurementFromPlayerByPlayerID(playerID);
        }

        public void GenerateAnalytics(Measurement measurment, Measurement prev)
        {
            _date = measurment.Date;
            int count = 1;
            while(count <= 27)
            {
                float value = 0f;
                string name = "error";
                AnalticsDataType type = AnalticsDataType.UNKOWN;
                switch (count)
                {
                    case 1:
                        value = GetDifferenceInMeassurments(measurment, prev, "Spiele");
                        name = "Spiele";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 2:
                        value = GetDifferenceInMeassurments(measurment, prev, "Siege");
                        name = "Siege";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 3:
                        value = GetDifferenceInMeassurments(measurment, prev, "Tore");
                        name = "Tore";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 4:
                        value = GetDifferenceInMeassurments(measurment, prev, "Torschuesse");
                        name = "Torschuesse";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 5:
                        value = GetDifferenceInMeassurments(measurment, prev, "Vorlagen");
                        name = "Vorlagen";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 6:
                        value = GetDifferenceInMeassurments(measurment, prev, "Paraden");
                        name = "Paraden";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 7:
                        value = GetDifferenceInMeassurments(measurment, prev, "Hereingaben");
                        name = "Hereingaben";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 8:
                        value = GetDifferenceInMeassurments(measurment, prev, "Befreiungsschlaege");
                        name = "Befreiungsschlaege";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 9:
                        value = GetDifferenceInMeassurments(measurment, prev, "Retter");
                        name = "Retter";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 10:
                        value = GetDifferenceInMeassurments(measurment, prev, "Zerstoerungen");
                        name = "Zerstoerungen";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 11:
                        if (Int32.Parse(measurment.GetMeasurementByName("3v3").Value) != 0 && Int32.Parse(prev.GetMeasurementByName("3v3").Value) == 0) value = 0;
                        else value = GetDifferenceInMeassurments(measurment, prev, "3v3");
                        name = "3v3";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 12:
                        if (Int32.Parse(measurment.GetMeasurementByName("2v2").Value) != 0 && Int32.Parse(prev.GetMeasurementByName("2v2").Value) == 0) value = 0;
                        else value = GetDifferenceInMeassurments(measurment, prev, "2v2");
                        name = "2v2";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 13:
                        if (Int32.Parse(measurment.GetMeasurementByName("1v1").Value) != 0 && Int32.Parse(prev.GetMeasurementByName("1v1").Value) == 0) value = 0;
                        else value = GetDifferenceInMeassurments(measurment, prev, "1v1");
                        name = "1v1";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 14:
                        if (Int32.Parse(measurment.GetMeasurementByName("1v1").Value) != 0 && Int32.Parse(prev.GetMeasurementByName("1v1").Value) == 0) value = 0;
                        else value = (Int32.Parse(measurment.GetMeasurementByName("3v3").Value) + Int32.Parse(measurment.GetMeasurementByName("2v2").Value) + Int32.Parse(measurment.GetMeasurementByName("1v1").Value)) 
                                - (Int32.Parse(prev.GetMeasurementByName("3v3").Value) + Int32.Parse(prev.GetMeasurementByName("2v2").Value) + Int32.Parse(prev.GetMeasurementByName("1v1").Value));
                        name = "MMR-Differenz";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 15:
                        value = GetAnalyticsByName("Siege").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Siegesquote";
                        type = AnalticsDataType.PERCANTAGE;
                        break;
                    case 16:
                        value = GetAnalyticsByName("Tore").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Tore/Spiel";
                        type = AnalticsDataType.VALUE;
                        break;
                    case 17:
                        value = GetAnalyticsByName("Torschuesse").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Torschuesse/Spiel";
                        type = AnalticsDataType.VALUE;
                        break;
                    case 18:
                        value = GetAnalyticsByName("Tore").Value / GetAnalyticsByName("Torschuesse").Value;
                        name = "Torpraezission";
                        type = AnalticsDataType.PERCANTAGE;
                        break;
                    case 19:
                        value = GetAnalyticsByName("Vorlagen").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Vorlagen/Spiel";
                        type = AnalticsDataType.VALUE;
                        break;
                    case 20:
                        value = GetAnalyticsByName("Paraden").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Paraden/Spiel";
                        type = AnalticsDataType.VALUE;
                        break;
                    case 21:
                        value = GetAnalyticsByName("Retter").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Retterquote";
                        type = AnalticsDataType.PERCANTAGE;
                        break;
                    case 22:
                        if (GetAnalyticsByName("Paraden").Value == 0) value = value = GetAnalyticsByName("Tore").Value;
                        else value = GetAnalyticsByName("Tore").Value / GetAnalyticsByName("Paraden").Value;
                        name = "Tore/Paraden";
                        type = AnalticsDataType.VALUE;
                        break;
                    case 23:
                        value = GetAnalyticsByName("Zerstoerungen").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Zerstoerungen/Spiele";
                        type = AnalticsDataType.VALUE;
                        break;
                    case 24:
                        value = GetAnalyticsByName("Hereingaben").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Hereingaben/Spiele";
                        type = AnalticsDataType.VALUE;
                        break;
                    case 25:
                        value = GetAnalyticsByName("Befreiungsschlaege").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Befreiungsschlaege/Spiele";
                        type = AnalticsDataType.VALUE;
                        break;
                    case 26:
                        value = GetAnalyticsByName("Befreiungsschlaege").Value + GetAnalyticsByName("Hereingaben").Value 
                            + GetAnalyticsByName("Torschuesse").Value + GetAnalyticsByName("Tore").Value
                            + GetAnalyticsByName("Paraden").Value + GetAnalyticsByName("Vorlagen").Value;
                        name = "Big-Time-Shots";
                        type = AnalticsDataType.DIFFERENCE;
                        break;
                    case 27:
                        value = GetAnalyticsByName("Big-Time-Shots").Value / GetAnalyticsByName("Spiele").Value;
                        name = "Big-Time-Shots/Spiele";
                        type = AnalticsDataType.VALUE;
                        break;

                }

                _analytics.Add(new Analytics(value, name, type));
                count++;
            }
        }

        public Analytics GetAnalyticsByName(string name)
        {
            foreach(Analytics a in _analytics)
            {
                if (a.Name.Equals(name)) return a;
            }

            return null;
        }

        public void Print()
        {
            foreach(Analytics a in _analytics)
            {
                a.Print();
            }
        }

        private int GetDifferenceInMeassurments(Measurement measurment, Measurement prev, string name)
        {
            if (measurment.HasMeasurementWithName(name)) return Int32.Parse(measurment.GetMeasurementByName(name).Value) - Int32.Parse(prev.GetMeasurementByName(name).Value);
            else return 0;
        }
    }
}
