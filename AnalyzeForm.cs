using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RL_DBMU
{
    public partial class AnalyzeForm : Form
    {
        private List<AnalyticsSheet> _sheets = new List<AnalyticsSheet>();
        private MeasurementList _playerList;
        private Dictionary<string, string[]> options = new Dictionary<string, string[]>(); 

        public AnalyzeForm(MeasurementList playerList)
        {
            
            InitializeComponent();

            _playerList = playerList;
            this.Text = Program.PlayerList.GetPlayerByPlayerID(_playerList.GetByListIndex(0).PlayerID).PlayerName;
            analyze();
            Initiate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate();
        }

        private void Initiate()
        {
            options.Add("Differenz", new string[] { "Spiele",
                "Siege",
                "Tore",
                "Torschuesse",
                "Vorlagen",
                "Paraden",
                "Hereingaben",
                "Befreiungsschlaege",
                "Retter",
                "Zerstoerungen",
                "Big-Time-Shots"
                });
            options.Add("Quote", new string[] { "Tore/Spiel",
                "Torschuesse/Spiel",
                "Vorlagen/Spiel",
                "Paraden/Spiel",
                "Zerstoerungen/Spiele",
                "Hereingaben/Spiele",
                "Befreiungsschlaege/Spiele",
                "Big-Time-Shots/Spiele",
                "Tore/Paraden"
                });
            options.Add("Rate", new string[] { "Siegesquote",
                "Torpraezission",
                "Retterquote"
                });
            options.Add("MMR", new string[] {"3v3",
                "2v2",
                "1v1",
                "MMR-Differenz"
                });
            options.Add("Advanced", new string[] { "Spiele",
                "Siege",
                "Tore",
                "Torschuesse",
                "Vorlagen",
                "Paraden",
                "Hereingaben",
                "Befreiungsschlaege",
                "Retter",
                "Zerstoerungen",
                "Big-Time-Shots",
                "3v3",
                "2v2",
                "1v1",
                "MMR-Differenz",
                "Tore/Spiel",
                "Torschuesse/Spiel",
                "Vorlagen/Spiel",
                "Paraden/Spiel",
                "Zerstoerungen/Spiele",
                "Hereingaben/Spiele",
                "Befreiungsschlaege/Spiele",
                "Big-Time-Shots/Spiele",
                "Tore/Paraden",
                "Siegesquote",
                "Torpraezission",
                "Retterquote"
                });

            checkedListBox1.Items.AddRange(options["Differenz"]);
        }

        private void analyze()
        {
            while (_playerList.Count > 0)
            {
                int playerID = _playerList.GetByListIndex(0).PlayerID;
                Measurement m = _playerList.GetLatestMeasurementFromPlayerByPlayerID(playerID);
                _playerList.Remove(m);
                Measurement prev = _playerList.GetLatestMeasurementFromPlayerByPlayerID(playerID);

                if (prev != null)_sheets.Add(new AnalyticsSheet(m, prev));
            }

            //_sheets.RemoveAt(0);
            _sheets.RemoveAt(_sheets.Count - 1);
        }

        private void generate()
        {
            chart1.Series.Clear();
            SeriesChartType type = SeriesChartType.Line;


            foreach (string field in checkedListBox1.CheckedItems)
            {
                Series series = new Series(field);
                series.ChartType = type;
                chart1.Series.Add(series);

                bool dead = false;
                bool last_a = false;

                foreach(AnalyticsSheet sheet in _sheets)
                {
                    foreach(Analytics a in sheet.Analytics)
                    {
                        if (a.Name.Equals(field))
                        {
                            float value = a.Value;
                            if (value == 0.0f) dead = true;
                            else dead = false;

                            if (a.Type == AnalticsDataType.PERCANTAGE) value *= 100;
                            
                            if(!last_a || !dead)
                                chart1.Series[field].Points.AddXY(sheet.Date, value);
                        }
                    }
                    last_a = dead;
                }
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if (options.ContainsKey(comboBox1.SelectedItem.ToString()))
            {
                checkedListBox1.Items.AddRange(options[comboBox1.SelectedItem.ToString()]);
            }
        }
    }
}
