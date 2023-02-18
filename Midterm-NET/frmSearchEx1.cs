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
    public partial class frmSearchEx1 : Form
    {
        private DataTable dataSource = new DataTable();
        private String text = "";
        private int key = -1;

        public frmSearchEx1(DataTable dataSource, String text)
        {
            InitializeComponent();
            this.dataSource = dataSource;
            this.text = text;
        }

        public frmSearchEx1(DataTable dataSource, String text, int key)
        {
            InitializeComponent();
            this.dataSource = dataSource;
            this.text = text;
            this.key =key;
        }

        private void frmSearchEx1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataSource;
            dataGridView1.ClearSelection();

            this.Text = text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(key == 1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                String id = row.Cells[0].Value.ToString().Trim();
                //MessageBox.Show(id);

                try
                {
                    SqlConnection conn = new SqlConnection(Program.strConn);
                    conn.Open();
                    String sSQL = "select * from __OrderItem where order_ID=@id order by order_item_ID asc";
                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<String> listBoxList = new List<String>();
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No Order Item data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataGridView2.ClearSelection();
            }
            else
            {
                dataGridView2.DataSource = null;
            }
        }
    }
}
