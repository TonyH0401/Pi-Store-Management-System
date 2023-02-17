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
    public partial class frmPlaceOrder : Form
    {
        private DataTable dtCurrent = new DataTable();

        public frmPlaceOrder()
        {
            InitializeComponent();
        }

        private void frmPlaceOrder_Load(object sender, EventArgs e)
        {
            txtbxReadOnlySetUp();

            dtCurrent = Load_DataGridViewProduct();
            dataGridViewProduct.DataSource = dtCurrent;
            dataGridViewProduct.Columns["product_desp"].Visible = false;

        }

        private void txtbxReadOnlySetUp()
        {
            richtxtbxDescription.ReadOnly = true;

            txtbxUsername.ReadOnly = true;
            txtbxFullname.ReadOnly = true;
            txtbxEmail.ReadOnly = true;
            txtbxPhone.ReadOnly = true;
            txtbxAddress.ReadOnly = true;
        }

        private DataTable Load_DataGridViewProduct()
        {
            DataTable result = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select product_ID, product_name, product_price, product_quantity, product_desp from __Product order by product_ID asc";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //dataGridViewProduct.DataSource = dt;
                    result = dt;
                }
                else
                {
                    MessageBox.Show("No Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Error! Please reload the Application. Code Error 56", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewProduct.SelectedRows[0];
            if (row != null)
            {
                richtxtbxDescription.Text = row.Cells[4].Value.ToString().Trim();
            }
            else
            {
                MessageBox.Show("Selected row is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_ComboBox()
        {

        }
    }
}
