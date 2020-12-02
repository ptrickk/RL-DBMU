using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_VS2019_SQL
{
    class Messung
    {

        int ID;
        DateTime Date;
        int SID;
        int Spiele;
        int Siege;
        int Tore;
        int Torschüsse;
        int Vorlagen;
        int Paraden;
        int Hereingaben;
        int Befreiungsschläge;
        int Retter;
        int Zerstörungen;
        int v3;
        int v2;
        int v1;

        public Messung(int id, DateTime date, int sid, int spiele, int siege, int tore, int torschüsse, int vorlagen, int paraden, int hereingaben, int befreiungsschläge, int retter, int zerstörungen, int v3, int v2, int v1)
        {
            ID = id;
            Date = date;
            SID = sid;
            Spiele = spiele;
            Siege = siege;
            Tore = tore;
            Torschüsse = torschüsse;
            Vorlagen = vorlagen;
            Paraden = paraden;
            Hereingaben = hereingaben;
            Befreiungsschläge = befreiungsschläge;
            Retter = retter;
            Zerstörungen = zerstörungen;
            this.v3 = v3;
            this.v2 = v2;
            this.v1 = v1;
        }

        public static List<Messung> getMessungenBySID(int SID, List<Messung> messungen)
        {
            List<Messung> temp = new List<Messung>();
            foreach (Messung m in messungen)
            {
                if (m.SID == SID)
                {
                    temp.Add(m);
                }
            }
            return temp;
        }
        public static List<int> getIntValue(List<Messung> messungen, string name)
        {
            List<int> values = new List<int>();
            if (name == "Spiele")
            {
                foreach (Messung m in messungen)
                {
                    values.Add(m.Spiele);
                }
            }
            return values;
        }

        public static Dictionary<DateTime, int> getIntValueWithDate(List<Messung> messungen, string name)
        {
            Dictionary<DateTime, int> values = new Dictionary<DateTime, int>();
            if (name == "Spiele")
            {
                foreach (Messung m in messungen)
                {
                    values.Add(m.Date, m.Spiele);
                }
            }
            return values;
        }

    }
}
