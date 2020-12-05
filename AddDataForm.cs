using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RL_DBMU
{
    public partial class AddDataForm : Form
    {

        private Player _player;
        private Measurement _measurement;
        private bool _hasMeasurement = false;

        public AddDataForm(Player player)
        {
            _player = player;
            if (Program.MeasurementList.HasMeasurementsWithPlayerID(player.PlayerID))
            {
                _hasMeasurement = true;
            }
            if (_hasMeasurement)
            {
                _measurement = Program.MeasurementList.GetLatestMeasurementFromPlayerByPlayerID(player.PlayerID);
            }
            InitializeComponent();

            FillPlayerdata();

            if (_hasMeasurement)
            {
                FillStatData();
            }
        }

        private void FillPlayerdata()
        {
            playernameValue.Text = _player.PlayerName;
            nameValue.Text = _player.Name;
            idValue.Text = _player.PlayerID + "";
        }

        private void FillStatData()
        {
            games.Minimum = int.Parse(_measurement.GetMeasurementByName("Spiele").Value);
            wins.Minimum = int.Parse(_measurement.GetMeasurementByName("Siege").Value);
            goals.Minimum = int.Parse(_measurement.GetMeasurementByName("Tore").Value);
            shots.Minimum = int.Parse(_measurement.GetMeasurementByName("Torschuesse").Value);
            assist.Minimum = int.Parse(_measurement.GetMeasurementByName("Vorlagen").Value);
            save.Minimum = int.Parse(_measurement.GetMeasurementByName("Paraden").Value);
            center.Minimum = int.Parse(_measurement.GetMeasurementByName("Hereingaben").Value);
            clear.Minimum = int.Parse(_measurement.GetMeasurementByName("Befreiungsschlaege").Value);
            savior.Minimum = int.Parse(_measurement.GetMeasurementByName("Retter").Value);
            demo.Minimum = int.Parse(_measurement.GetMeasurementByName("Zerstoerungen").Value);

            v3.Value = int.Parse(_measurement.GetMeasurementByName("3v3").Value);
            v2.Value = int.Parse(_measurement.GetMeasurementByName("2v2").Value);
            v1.Value = int.Parse(_measurement.GetMeasurementByName("1v1").Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void games_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = games;
            Label label = gamesDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = center;
            Label label = centerDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = savior;
            Label label = saviorDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void wins_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = wins;
            Label label = winsDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void goals_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = goals;
            Label label = goalsDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void shots_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = shots;
            Label label = shotsDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void assist_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = assist;
            Label label = assitDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void save_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = save;
            Label label = savesDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void clear_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = clear;
            Label label = clearDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void demo_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = demo;
            Label label = demoDiff;
            if (numericUpDown.Value > numericUpDown.Minimum)
            {
                label.Visible = true;
                label.Text = (numericUpDown.Value - numericUpDown.Minimum).ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            
            string query = "INSERT INTO" +
                " messung " +
                "(MessungsID," +
                " Datum," +
                " SpielerID," +
                " Spiele," +
                " Siege," +
                " Tore," +
                " Torschuesse," +
                " Vorlagen," +
                " Paraden," +
                " Hereingaben," +
                " Befreiungsschlaege," +
                " Retter," +
                " Zerstoerungen," +
                " 3v3, 2v2, 1v1)" +
                " VALUES(NULL, " +
                "'" + date.Year + "-" + date.Month + "-" + date.Day + "', " +
                "'" + _player.PlayerID + "', " +
                "" + games.Value + ", " +
                "" + wins.Value + ", " +
                "" + goals.Value + ", " +
                "" + shots.Value + ", " +
                "" + assist.Value + ", " +
                "" + save.Value + ", " +
                "" + center.Value + ", " +
                "" + clear.Value + ", " +
                "" + savior.Value + ", " +
                "" + demo.Value + ", " +
                "" + v3.Value + ", " +
                "" + v2.Value + ", " +
                "" + v1.Value + ")";

            Utils.ExecuteQuery(query);

            Utils.FetchMeasurements(Program.MeasurementList);

            Close();
        }
    }
}
