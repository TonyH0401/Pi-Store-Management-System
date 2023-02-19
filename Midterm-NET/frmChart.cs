using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Midterm_NET
{
    public partial class frmChart : Form
    {
        private DataTable dt = new DataTable();
        private String seriesName = "";
        private int maxValue = 0;

        public frmChart()
        {
            InitializeComponent();
        }

        public frmChart(DataTable dt, string seriesName, int maxValue)
        {
            InitializeComponent();
            this.dt = dt;
            this.seriesName = seriesName;
            this.maxValue = maxValue;
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            //clear all of the name
            this.chart1.Series.Clear();

            //set up the name of the series
            Series ser1 = chart1.Series.Add(seriesName);
            ser1.Name = seriesName;

            //set max value
            this.chart1.ChartAreas[0].AxisY.Maximum = maxValue;

            //load the product
            foreach (DataRow item in dt.Rows)
            {
                String id = item[0].ToString();
                String quantity = item[1].ToString();
                //the AddXY is set to Auto
                this.chart1.Series[seriesName].Points.AddXY(id, quantity);
            }

            //sort the bar chart
            this.chart1.DataBind();
            this.chart1.Series[seriesName].Sort(
               System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Ascending);

            this.Text = seriesName + " bar chart";
        }

    }
}
