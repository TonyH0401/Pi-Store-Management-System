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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Midterm_NET
{
    public partial class frmOrder : Form
    {
        private DataTable currentDataTable = new DataTable();

        public frmOrder()
        {
            InitializeComponent();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            initiateReadOnlyTextBox();

            currentDataTable = Load_Order();
            dataGridViewOrder.DataSource = currentDataTable;
            dataGridViewOrder.Columns["client_ID"].Visible = false;
            dataGridViewOrder.Columns["employee_ID"].Visible = false;
            dataGridViewOrder.Columns["total_price"].Visible = false;


            this.Text = "Manage Order - " + Program.sessionEmployeeID;
        }

        private void initiateReadOnlyTextBox()
        {
            txtbxClientID.ReadOnly = true;
            txtbxEmployeeID.ReadOnly = true;
            txtbxOrderID.ReadOnly = true;
            txtbxTotalPrice.ReadOnly = true;
            dateTimePickerOrder.Enabled = false;
        }

        private DataTable Load_Order()
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Order order by order_ID asc";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataTable = dt;
                }
                else
                {
                    MessageBox.Show("No Order data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        private void appendOrderDataToTextbox(DataGridViewRow row)
        {
            String order_id = row.Cells[0].Value.ToString().Trim();
            String client_id = row.Cells[1].Value.ToString().Trim();
            String employee_id = row.Cells[2].Value.ToString().Trim();
            String order_date = row.Cells[3].Value.ToString().Trim();
            String total_price = row.Cells[4].Value.ToString().Trim();

            txtbxClientID.Text = client_id;
            txtbxEmployeeID.Text = employee_id;
            txtbxOrderID.Text = order_id;
            txtbxTotalPrice.Text = total_price;
            dateTimePickerOrder.Text = order_date;
        }

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewOrder.SelectedRows[0];
            if(row != null)
            {
                appendOrderDataToTextbox(row);
                lblOrderItem.Text = "Order Item: " + row.Cells[0].Value.ToString().Trim();
                Load_OrderItem(row.Cells[0].Value.ToString().Trim());
            }
            else
            {
                MessageBox.Show("Selected row is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_OrderItem(String id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select OI.order_ID as OrderID, OI.order_item_ID as Number, OI.product_ID as ProductID, P.product_name as ProductName, OI.product_quantity as OrderProductQuantity, P.product_price as PricePer from __OrderItem OI, __Product P where OI.product_ID=P.product_ID and order_ID=@id order by order_item_ID asc";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridViewOrderItem.DataSource = dt;
                    dataGridViewOrderItem.ClearSelection();
                }
                else
                {
                    MessageBox.Show("No data from Order Item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error Code: 90", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            String temp = dateTimePickerFind.Value.ToString("yyyy-MM-dd").Trim();
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select order_ID from __Order where order_data=@date";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@date", temp);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    String result = "";
                    foreach(DataRow dr in dt.Rows)
                    {
                        result = result + dr[0].ToString().Trim() + ", ";
                    }
                    MessageBox.Show("Total Order(s) for " + temp + ":\n> " + dt.Rows.Count + "\nList of Order(s) for " + temp + ":\n> " + result.Trim(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Order(s) was found for date: " + temp, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Error Code: 167", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmOrder_Load(sender, e);

            txtbxClientID.Clear();
            txtbxEmployeeID.Clear();
            txtbxOrderID.Clear();
            txtbxTotalPrice.Clear();
            dateTimePickerOrder.Text = DateTime.Now.ToString();

            dataGridViewOrderItem.DataSource = null;
        }
    }
}
