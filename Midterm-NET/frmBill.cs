using Microsoft.Reporting.WinForms;
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
    public partial class frmBill : Form
    {
        private DataTable currentDataTable = new DataTable();

        public frmBill()
        {
            InitializeComponent();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            currentDataTable = Load_Order();
            dataGridViewOrder.DataSource = currentDataTable;
            dataGridViewOrder.ClearSelection();

            Load_Bill();
            lstbxBill.ClearSelected();

            //this.Text = "Manage Order - " + Program.sessionEmployeeID;
        }

        private void Load_Bill()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select bill_ID from __Bill order by bill_ID asc";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        String temp = row[0].ToString().Trim();
                        listBoxList.Add(temp);
                    }
                    lstbxBill.DataSource = listBoxList;

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    String temp = dt.Rows[i][0].ToString().Trim();
                    //    listBoxList.Add(temp);
                    //}
                    //lstbxBill.DataSource = listBoxList;
                    //lstbxBill.DataSource = dt;
                }
                else
                {
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewOrder.SelectedRows[0];
            if (row != null)
            {
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

        private String getBillID(String id)
        {
            return "B" + id;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(btnLock.Enabled == true)
            {
                MessageBox.Show("Please lock the order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnUnlock_Click(sender, e);
                return;
            }
            if(dataGridViewOrderItem.Rows.Count == 0)
            {
                MessageBox.Show("Please select an order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnUnlock_Click(sender, e);
                return;
            }

            String order_id = dataGridViewOrder.SelectedRows[0].Cells[0].Value.ToString().Trim();
            String bill_id = getBillID(order_id);
            String client_id = dataGridViewOrder.SelectedRows[0].Cells[1].Value.ToString().Trim();
            String employee_id = dataGridViewOrder.SelectedRows[0].Cells[2].Value.ToString().Trim();
            String bill_date = DateTime.Now.ToString("yyyy-MM-dd").Trim();
            double total_price = double.Parse(dataGridViewOrder.SelectedRows[0].Cells[4].Value.ToString().Trim());

            if(billExisted(bill_id) == true)
            {
                MessageBox.Show("Bill has Existed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to create bill " + bill_id + " for order " + order_id + " ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    addBill(bill_id, order_id, client_id, employee_id, bill_date, total_price);
                    btnRefresh_Click(sender, e);
                    btnUnlock_Click(sender, e);
                }
            }
            //MessageBox.Show(bill_id);
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            //String temp = dataGridViewOrder.SelectedRows[0].Cells[0].Value.ToString().Trim();
            if (dataGridViewOrder.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Order is not Selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            dataGridViewOrder.Enabled = false;
            dataGridViewOrderItem.Enabled = false;

            btnLock.Enabled = false;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            dataGridViewOrder.Enabled = true;
            dataGridViewOrderItem.Enabled = true;

            btnLock.Enabled = true;
        }

        private bool billExisted(String bill_id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Bill where bill_ID=@bill_id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@bill_id", bill_id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Order data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void addBill(String bill_id, String order_id, String client_id, String employee_id, String bill_date, double total)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "insert into __Bill values (@bill_id, @order_id, @client_id, @employee_id, @bill_date, @total)";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@bill_id", bill_id);
                cmd.Parameters.AddWithValue("@order_id", order_id);
                cmd.Parameters.AddWithValue("@client_id", client_id);
                cmd.Parameters.AddWithValue("@employee_id", employee_id);
                cmd.Parameters.AddWithValue("@bill_date", bill_date);
                cmd.Parameters.AddWithValue("@total", total);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Created Bill!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btnRefresh_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error! Please reload the Application. Code 229", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmBill_Load(sender, e);
            dataGridViewOrder.ClearSelection();

            dataGridViewOrderItem.DataSource = null;

            Load_Bill();
            lstbxBill.ClearSelected();

            btnLock.Enabled = true;
            btnUnlock_Click(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(lstbxBill.Items.Count <= 0)
            {
                MessageBox.Show("There aren't any Bills to print", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if(lstbxBill.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Please select a Bill to print", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult dr = MessageBox.Show("Do you want to Print: " + lstbxBill.SelectedItem.ToString(), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    MessageBox.Show("OK");
                }
            }
        }
    }
}
