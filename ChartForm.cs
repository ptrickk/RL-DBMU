﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RL_DBMU
{
    public partial class ChartForm : Form
    {
        private Chart _chart;
        private MeasurementList _measurementList;
        private CheckedListBox fields;
        private CheckBox diff;
        private DateTimePicker Von;
        private DateTimePicker dateTimePicker2;
        private System.ComponentModel.IContainer components;
        private Button button1;
        private CheckBox showValues;
        private int _count = 0;

        public ChartForm(MeasurementList measurementList)
        {
            _measurementList = measurementList;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this._chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fields = new System.Windows.Forms.CheckedListBox();
            this.diff = new System.Windows.Forms.CheckBox();
            this.Von = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.showValues = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).BeginInit();
            this.SuspendLayout();
            // 
            // _chart
            // 
            chartArea2.Name = "ChartArea1";
            this._chart.ChartAreas.Add(chartArea2);
            this._chart.Cursor = System.Windows.Forms.Cursors.Default;
            this._chart.DataSource = this._chart.Images;
            this._chart.ImeMode = System.Windows.Forms.ImeMode.Off;
            legend2.Name = "Legend1";
            this._chart.Legends.Add(legend2);
            this._chart.Location = new System.Drawing.Point(148, 57);
            this._chart.Name = "_chart";
            this._chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this._chart.Size = new System.Drawing.Size(696, 300);
            this._chart.SuppressExceptions = true;
            this._chart.TabIndex = 0;
            this._chart.TabStop = false;
            this._chart.Text = "chart1";
            this._chart.Click += new System.EventHandler(this.chart1_Click);
            this._chart.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseWheel);
            // 
            // fields
            // 
            this.fields.FormattingEnabled = true;
            this.fields.Items.AddRange(new object[] {
            "Spiele",
            "Siege",
            "Tore",
            "Torschuesse",
            "Vorlagen",
            "Paraden",
            "Hereingaben",
            "Befreiungsschlaege",
            "Retter",
            "Zerstoerungen",
            "3v3",
            "2v2",
            "1v1"});
            this.fields.Location = new System.Drawing.Point(12, 57);
            this.fields.Name = "fields";
            this.fields.Size = new System.Drawing.Size(120, 199);
            this.fields.TabIndex = 1;
            // 
            // diff
            // 
            this.diff.AutoSize = true;
            this.diff.Location = new System.Drawing.Point(12, 263);
            this.diff.Name = "diff";
            this.diff.Size = new System.Drawing.Size(68, 17);
            this.diff.TabIndex = 2;
            this.diff.Text = "Differenz";
            this.diff.UseVisualStyleBackColor = true;
            this.diff.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Von
            // 
            this.Von.AccessibleDescription = "Von";
            this.Von.AccessibleName = "Von";
            this.Von.Location = new System.Drawing.Point(12, 12);
            this.Von.Name = "Von";
            this.Von.Size = new System.Drawing.Size(200, 20);
            this.Von.TabIndex = 3;
            this.Von.Tag = "Von";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(218, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Generiere Graphen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // showValues
            // 
            this.showValues.AutoSize = true;
            this.showValues.Location = new System.Drawing.Point(12, 286);
            this.showValues.Name = "showValues";
            this.showValues.Size = new System.Drawing.Size(85, 17);
            this.showValues.TabIndex = 6;
            this.showValues.Text = "Zeige Werte";
            this.showValues.UseVisualStyleBackColor = true;
            // 
            // ChartForm
            // 
            this.ClientSize = new System.Drawing.Size(928, 384);
            this.Controls.Add(this.showValues);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.Von);
            this.Controls.Add(this.diff);
            this.Controls.Add(this.fields);
            this.Controls.Add(this._chart);
            this.Name = "ChartForm";
            ((System.ComponentModel.ISupportInitialize)(this._chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (diff.Checked)
            {
                _count = 0;
                _chart.Series.Clear();
                foreach (string field in fields.CheckedItems)
                {
                    Series series = new Series(field);
                    series.ChartType = SeriesChartType.Line;
                    series.BorderWidth = 5;
                    series.IsValueShownAsLabel = showValues.Checked;

                    _chart.Series.Add(series);

                    for (int i = 1; i < _measurementList.Count; i++)
                    {
                        Measurement prevMeasurement = _measurementList[i - 1];
                        Measurement currentMeasurement = _measurementList[i];
                        foreach (MeasurementData prevData in prevMeasurement)
                        {
                            foreach (MeasurementData currentData in currentMeasurement)
                            {
                                if (currentData.Name == field && prevData.Name == field)
                                {
                                    string date = currentMeasurement.Date.Day + "." + currentMeasurement.Date.Month + "." + currentMeasurement.Date.Year;
                                    int prevValue = int.Parse(prevData.Value);
                                    int currentValue = int.Parse(currentData.Value);
                                    _chart.Series[field].Points.AddXY(date, currentValue - prevValue);
                                }
                            }
                        }
                    }
                    foreach (DataPoint point in series.Points)
                    {
                        point.ToolTip = point.YValues[0] + "";
                    }
                    _count++;
                }
            }
            else
            {
                _count = 0;
                _chart.Series.Clear();
                foreach (string field in fields.CheckedItems)
                {
                    Series series = new Series(field);
                    series.ChartType = SeriesChartType.Line;
                    series.BorderWidth = 5;
                    series.IsValueShownAsLabel = showValues.Checked;

                    _chart.Series.Add(series);
                    foreach (Measurement measurement in _measurementList)
                    {
                        foreach (MeasurementData data in measurement)
                        {
                            if (data.Name == field)
                            {
                                string date = measurement.Date.Day + "." + measurement.Date.Month + "." + measurement.Date.Year;
                                _chart.Series[field].Points.AddXY(date, data.Value);
                            }
                        }
                    }
                    foreach(DataPoint point in series.Points)
                    {
                        point.ToolTip = point.YValues[0] + "";
                    }
                    _count++;
                }
            }
        }
    }
}
