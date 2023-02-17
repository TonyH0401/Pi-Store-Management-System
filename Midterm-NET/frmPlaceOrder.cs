using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

            cbbxClient.DropDownStyle = ComboBoxStyle.DropDownList;
            Load_ComboBox();

            initiateDataGridViewOrder();

            this.Text = "Place Order - " + Program.sessionEmployeeID;
        }

        private void initiateDataGridViewOrder()
        {
            dataGridViewOrder.ColumnCount = 4;
            dataGridViewOrder.Columns[0].Name = "product_ID";
            dataGridViewOrder.Columns[1].Name = "product_name";
            dataGridViewOrder.Columns[2].Name = "product_quantity";
            dataGridViewOrder.Columns[3].Name = "product_price";
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
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cbbxClient.DataSource = dt;
                    cbbxClient.DisplayMember = "client_ID";
                    cbbxClient.ValueMember = "client_ID";
                    Load_Data_From_Combobox();
                }
                else
                {
                    MessageBox.Show("No Data to load to combobox", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error! Please reload the Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_Data_From_Combobox()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client where client_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", cbbxClient.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtbxUsername.Text = (String)dt.Rows[0][0].ToString().Trim();
                    txtbxFullname.Text = (String)dt.Rows[0][1].ToString().Trim();
                    txtbxEmail.Text = (String)dt.Rows[0][2].ToString().Trim();
                    txtbxPhone.Text = (String)dt.Rows[0][3].ToString().Trim();
                    txtbxAddress.Text = (String)dt.Rows[0][4].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("No Data to Load to textbox", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("Error! Please reload the Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Data_From_Combobox();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            cbbxClient.Enabled = false;

            txtbxUsername.Enabled = false;
            txtbxFullname.Enabled = false;
            txtbxEmail.Enabled = false;
            txtbxPhone.Enabled = false;
            txtbxAddress.Enabled = false;

            btnLock.Enabled = false;
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            cbbxClient.Enabled = true;

            txtbxUsername.Enabled = true;
            txtbxFullname.Enabled = true;
            txtbxEmail.Enabled = true;
            txtbxPhone.Enabled = true;
            txtbxAddress.Enabled = true;

            btnLock.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnLock.Enabled == true)
            {
                MessageBox.Show("Please lock on selection of a Client", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(richtxtbxDescription.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Please select a Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtbxQuantity.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Please Enter the Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int value = 0;
                bool value_temp = int.TryParse(txtbxQuantity.Text.ToString().Trim(), out value);
                if (value_temp == false)
                {
                    MessageBox.Show("Invalid Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataGridViewRow row = dataGridViewProduct.SelectedRows[0];
                    int stock = int.Parse(row.Cells[3].Value.ToString().Trim());
                    if (value <= 0 || value > stock)
                    {
                        MessageBox.Show("Invalid range Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        DataGridViewRow row2 = dataGridViewProduct.SelectedRows[0];
                        String id = row2.Cells[0].Value.ToString().Trim();
                        String name = row2.Cells[1].Value.ToString().Trim();
                        String price = row2.Cells[2].Value.ToString().Trim();
                        String quantity = value.ToString().Trim();
                        DialogResult dr = MessageBox.Show("Do you want to add:\n\t" + "> " + id + "\n\t> " + name + "\n\t> quantity = " + quantity, "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(dr == DialogResult.Yes)
                        {
                            //MessageBox.Show(dataGridViewOrder.Rows.Count.ToString().Trim());
                            if(productExistedDataGridViewOrder(id) == false)
                            {
                                addDataGridViewOrder(id, name, price, quantity);
                                MessageBox.Show("Product added: " + id, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                updateDataGridViewOrder(id, quantity);
                                MessageBox.Show("Product updated: " + id, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            updateQuantityDataGridViewProductById(id, quantity);
                            txtbxQuantity.Clear();
                        }
                    }
                }
            }
        }
        
        private bool productExistedDataGridViewOrder(String id)
        {
            if(dataGridViewOrder.Rows.Count == 0)
            {
                return false;
            }
            foreach (DataGridViewRow row3 in dataGridViewOrder.Rows)
            {
                if (row3.Cells[0].Value.ToString().Trim().Equals(id) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void addDataGridViewOrder(String id, String name, String price, String quantity)
        {
            String[] row = new string[]
            {
                id, 
                name, 
                quantity,
                price
            };
            dataGridViewOrder.Rows.Add(row);
        }

        private void updateDataGridViewOrder(String id, String quantity)
        {
            DataGridViewRow row = new DataGridViewRow();
            foreach (DataGridViewRow row2 in dataGridViewOrder.Rows)
            {
                if (row2.Cells[0].Value.ToString().Trim().Equals(id) == true)
                {
                    row = row2;
                    break;
                }
            }
            int old_quantity = int.Parse(row.Cells[2].Value.ToString().Trim());
            int current_quantity = int.Parse(quantity);
            int new_quantity = old_quantity + current_quantity;
            foreach (DataGridViewRow row2 in dataGridViewOrder.Rows)
            {
                if (row2.Cells[0].Value.ToString().Trim().Equals(id) == true)
                {
                    row2.Cells[2].Value = new_quantity;
                    break;
                }
            }
        }

        private void updateQuantityDataGridViewProductById(String id, String quantity)
        {
            String temp = "";
            foreach (DataRow row2 in dtCurrent.Rows)
            {
                if (row2[0].ToString().Trim().Equals(id) == true)
                {
                    temp = row2[3].ToString().Trim();
                    break;
                }
            }
            int old_quantity = int.Parse(temp);
            int current_quantity = int.Parse(quantity);
            int new_quantity = old_quantity - current_quantity;
            foreach (DataRow row2 in dtCurrent.Rows)
            {
                if(row2[0].ToString().Trim().Equals(id) == true)
                {
                    row2[3] = new_quantity.ToString().Trim();
                    break;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridViewOrder.Rows.Count == 0)
            {
                MessageBox.Show("There are no product to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                int index = dataGridViewOrder.SelectedRows[0].Index;
                if (index >= 0)
                {
                    dataGridViewOrder.Rows.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("The selected row is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private String getOrderID()
        {
            int counter = 0;
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select order_ID from __Order";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    counter = dt.Rows.Count;
                }
                else
                {
                    counter = 0;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Error! Please reload the Application. Code Error 56", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            counter = counter + 1;
            String result = "OR" + counter.ToString().Trim();
            if(result.Length > 10)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        private double getOrderTotal() 
        {
            double result = 0;
            foreach (DataGridViewRow row in dataGridViewOrder.Rows)
            {
                int quantity = int.Parse(row.Cells[2].Value.ToString().Trim());
                int price = int.Parse(row.Cells[3].Value.ToString().Trim());
                result = result + (quantity * price);
            }
            result = result + (result * 0.1);
            return result;
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            //need to check for lock and datagridview order
            if (btnLock.Enabled == true)
            {
                MessageBox.Show("Please select Client before POST the Order!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(dataGridViewOrder.Rows.Count == 0)
            {
                MessageBox.Show("Please complete the Order before POSTING!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            String order_id = getOrderID();
            String client_id = txtbxUsername.Text.ToString().Trim();
            String employee_id = (Program.sessionEmployeeID.Equals("") == true) ? "admin" : Program.sessionEmployeeID;
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            double total = getOrderTotal();
            if(order_id == null)
            {
                MessageBox.Show("Order Table is now at MAX capacity! Please contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to POST the Order", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dr == DialogResult.Yes)
                {
                    addToOrder(order_id, client_id, employee_id, date, total);
                    addToOrderItem(order_id, dataGridViewOrder);
                    updateProductAfterOrder(dataGridViewOrder);
                    //clear all data
                    clearDataAfterPOST(sender, e);
                }
            }
        }

        private void addToOrder(String id, String client_id, String employee_id, String date, double total)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "insert into __Order values (@id, @client_id, @employee_id, @date, @total)";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@client_id", client_id);
                cmd.Parameters.AddWithValue("@employee_id", employee_id);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@total", total);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Order Created!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error with Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error! Please reload the Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToOrderItem(String order_id, DataGridView data)
        {
            int orderItemId = 0;
            foreach (DataGridViewRow row in data.Rows)
            {
                orderItemId++;
                String product_id = row.Cells[0].Value.ToString().Trim();
                int product_quantity = int.Parse(row.Cells[2].Value.ToString().Trim());
                try
                {
                    SqlConnection conn = new SqlConnection(Program.strConn);
                    conn.Open();
                    String sSQL = "insert into __OrderItem values (@item_id, @order_id, @product_id, @quantity)";
                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@item_id", orderItemId);
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    cmd.Parameters.AddWithValue("@product_id", product_id);
                    cmd.Parameters.AddWithValue("@quantity", product_quantity);
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        //MessageBox.Show("Order Item Created!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error with Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Error! Please reload the Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }

        private void updateProductAfterOrder(DataGridView data)
        {
            foreach (DataGridViewRow row in data.Rows)
            {
                String product_id = row.Cells[0].Value.ToString().Trim();
                int product_quantity = int.Parse(row.Cells[2].Value.ToString().Trim());
                try
                {
                    SqlConnection conn = new SqlConnection(Program.strConn);
                    conn.Open();
                    String sSQL = "update __Product set product_quantity=product_quantity-@quantity where product_ID=@product_id";
                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@product_id", product_id);
                    cmd.Parameters.AddWithValue("@quantity", product_quantity);
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        //MessageBox.Show("Product Updated After Order!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error with Updating Product After Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Error! Please reload the Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearDataAfterPOST(object sender, EventArgs e)
        {
            //reload product datagridview
            frmPlaceOrder_Load(sender, e);
            //reload order datagidview
            dataGridViewOrder.Rows.Clear();
            initiateDataGridViewOrder();
            //unlock
            btnUnlock_Click(sender, e);
            //clear desp
            richtxtbxDescription.Clear();
            //clear quantity
            txtbxQuantity.Clear();
        }
    }
}
