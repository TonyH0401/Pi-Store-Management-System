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
            String seriesName = "Hello";
            Series ser1 = chart1.Series.Add(seriesName);
            ser1.Name = seriesName;

            //set max value
            this.chart1.ChartAreas[0].AxisY.Maximum = 300;

            //load the product
            DataTable dt = Load_Product();
            foreach (DataRow item in dt.Rows)
            {
                String id = item[0].ToString();
                String quantity = item[1].ToString();
                this.chart1.Series[seriesName].Points.AddXY(id, quantity);
            }

            //sort the bar chart
            this.chart1.DataBind();
            this.chart1.Series[seriesName].Sort(
               System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Ascending);

        }

        private DataTable Load_Product()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select product_name, product_quantity from __Product";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return new DataTable();
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new DataTable();
        }

    }
}
