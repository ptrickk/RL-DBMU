using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RL_DBMU
{
    public partial class ChartForm : Form
    {
        private Chart _chart;
        private List<int> _values = new List<int>();
        private List<DateTime> _dates = new List<DateTime>();
        private int _count = 0;

        public ChartForm(List<int> values, List<DateTime> dates)
        {
            _values = values;
            _dates = dates;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this._chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).BeginInit();
            this.SuspendLayout();
            // 
            // _chart
            // 
            chartArea1.Name = "ChartArea1";
            this._chart.ChartAreas.Add(chartArea1);
            this._chart.DataSource = this._chart.Images;
            legend1.Name = "Legend1";
            this._chart.Legends.Add(legend1);
            this._chart.Location = new System.Drawing.Point(12, 12);
            this._chart.Name = "_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Value";
            this._chart.Series.Add(series1);
            this._chart.Size = new System.Drawing.Size(904, 300);
            this._chart.SuppressExceptions = true;
            this._chart.TabIndex = 0;
            this._chart.Text = "chart1";
            this._chart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // ChartForm
            // 
            this.ClientSize = new System.Drawing.Size(928, 329);
            this.Controls.Add(this._chart);
            this.Name = "ChartForm";
            ((System.ComponentModel.ISupportInitialize)(this._chart)).EndInit();
            this.ResumeLayout(false);

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            if (_values.Count > _count)
            {
                string date = _dates[_count].Day + "." + _dates[_count].Month + "." + _dates[_count].Year;
                _chart.Series["Value"].Points.AddXY(date, _values[_count]);
                _count++;
            }
        }
    }
}
