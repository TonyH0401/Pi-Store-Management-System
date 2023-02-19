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

namespace Midterm_NET
{
    public partial class frmChart : Form
    {
        public frmChart()
        {
            InitializeComponent();
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            DataTable dt = Load_Product();
            this.chart1.Series["Stock"].Points.Add(300);
            foreach (DataRow item in dt.Rows)
            {
                String id = item[0].ToString();
                String quantity = item[1].ToString();
                this.chart1.Series["Stock"].Points.AddXY(id, quantity);
                //this.chart1.Series["Stock"].Points.AddXY("Max2", 1000);
            }
            this.chart1.DataBind();
            this.chart1.Series["Stock"].Sort(
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
