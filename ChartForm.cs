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
        private List<List<int>> _values = new List<List<int>>();
        private List<DateTime> _dates = new List<DateTime>();
        private int _count = 0;

        public ChartForm(List<List<int>> values, List<DateTime> dates)
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this._chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).BeginInit();
            this.SuspendLayout();
            // 
            // _chart
            // 
            chartArea1.Name = "ChartArea1";
            this._chart.ChartAreas.Add(chartArea1);
            this._chart.Cursor = System.Windows.Forms.Cursors.Default;
            this._chart.DataSource = this._chart.Images;
            this._chart.ImeMode = System.Windows.Forms.ImeMode.Off;
            legend1.Name = "Legend1";
            this._chart.Legends.Add(legend1);
            this._chart.Location = new System.Drawing.Point(12, 12);
            this._chart.Name = "_chart";
            this._chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Value0";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Value1";
            this._chart.Series.Add(series1);
            this._chart.Series.Add(series2);
            this._chart.Size = new System.Drawing.Size(904, 300);
            this._chart.SuppressExceptions = true;
            this._chart.TabIndex = 0;
            this._chart.Text = "chart1";
            this._chart.Click += new System.EventHandler(this.chart1_Click);
            this._chart.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseWheel);
            // 
            // ChartForm
            // 
            this.ClientSize = new System.Drawing.Size(928, 329);
            this.Controls.Add(this._chart);
            this.Name = "ChartForm";
            ((System.ComponentModel.ISupportInitialize)(this._chart)).EndInit();
            this.ResumeLayout(false);

        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            //var yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0) // Scrolled down.
                {
                    xAxis.ScaleView.ZoomReset();
                    //yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0) // Scrolled up.
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    //var yMin = yAxis.ScaleView.ViewMinimum;
                    //var yMax = yAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    //var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    //var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    //yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _values.Count; i++)
            {
                if (_values[i].Count > _count)
                {
                    string date = _dates[_count].Day + "." + _dates[_count].Month + "." + _dates[_count].Year;
                    _chart.Series["Value" + i].Points.AddXY(date, _values[i][_count]);
                    _count++;
                }
            }
        }
    }
}
