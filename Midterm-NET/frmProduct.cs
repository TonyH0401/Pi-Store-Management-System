using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Midterm_NET
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            Load_DataGridViewProduct();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            this.Text = "Product Management - " + Program.sessionEmployeeID.ToString().Trim();
        }


        private void Load_DataGridViewProduct()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Product order by product_ID asc";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridViewProduct.DataSource = dt;
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_DataGridViewProduct();
            clearAllTextBox();
            MessageBox.Show("Refreshed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearAllTextBox()
        {
            txtbxProductID.Clear();
            txtbxName.Clear();
            richtxtbxDescription.Clear();
            txtbxPrice.Clear();
            txtbxQuantity.Clear();
        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            txtbxProductID.Enabled = false;

            try
            {
                DataGridViewRow row = dataGridViewProduct.SelectedRows[0];
                txtbxProductID.Text = row.Cells[0].Value.ToString().Trim();
                txtbxName.Text = row.Cells[1].Value.ToString().Trim();
                richtxtbxDescription.Text = row.Cells[2].Value.ToString().Trim();
                txtbxPrice.Text = row.Cells[3].Value.ToString().Trim();
                txtbxQuantity.Text = row.Cells[4].Value.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error has occured. Error code 96", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAllTextBox();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtbxProductID.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String id = txtbxProductID.Text.ToString().Trim();
            if (id.Length == 0)
            {
                MessageBox.Show("No Product ID to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (productIdExist(id) == false)
            {
                MessageBox.Show("Product does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "delete from __Product where product_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Deleted Product!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefresh_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error code 138", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error! Please reload the Application. Code 229", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String id = txtbxProductID.Text.ToString().Trim();
            String name = txtbxName.Text.ToString().Trim();
            String desp = richtxtbxDescription.ToString().Trim();
            String price = txtbxPrice.Text.ToString().Trim();
            String quantity= txtbxQuantity.Text.ToString().Trim();
            if ((id.Length * name.Length * desp.Length * price.Length * quantity.Length != 0))
            {
                if (productIdExist(id.ToUpper()) == true)
                {
                    MessageBox.Show("Product ID existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (id.Length < 10 || id.Length > 10)
                {
                    MessageBox.Show("Invalid ProductID - Length not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (desp.Length >= 254)
                {
                    MessageBox.Show("Desp capacity: " +desp.Length+ "has reached max capacity! Please write a description less than 255 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double priceValue = 0;
                bool priceTemp = Double.TryParse(price, out priceValue);
                if(priceTemp == false)
                {
                    MessageBox.Show("Please enter the correct data type of price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if(priceValue <= 0)
                    {
                        MessageBox.Show("Price can not be negative", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                int quantityValue = 0;
                bool quantityTemp = int.TryParse(quantity, out quantityValue);
                if(quantityTemp == false)
                {
                    MessageBox.Show("Please enter the correct data type of quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (quantityValue <= 0)
                    {
                        MessageBox.Show("Quantity can not be negative", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                name = textInfo.ToTitleCase(name.ToLower());
                addProduct(id.ToUpper(), name, desp, priceValue, quantityValue);
                btnRefresh_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Empty field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool productIdExist(String id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Product where product_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
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
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Error! Please reload the Application. Code 216", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void addProduct(String id, String name, String desp, double price, int quantity)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "insert into __Product values (@id, @name, @desp, @price, @quantity)";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@desp", desp);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Saved new Product", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cannot insert new Product. Error code 239", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error! Please reload the Application. Code 229", "Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String id = txtbxProductID.Text.ToString().Trim();
            if (id.Length == 0)
            {
                MessageBox.Show("No Client id to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //String id = txtbxUsername.Text.ToString().Trim();
            String name = txtbxName.Text.ToString().Trim();
            String desp = richtxtbxDescription.Text.ToString().Trim();
            String price = txtbxPrice.Text.ToString().Trim();
            String quantity = txtbxQuantity.Text.ToString().Trim();
            if ((id.Length * name.Length * desp.Length * price.Length * quantity.Length != 0))
            {
                if (productIdExist(id.ToUpper()) == true)
                {
                    MessageBox.Show("User ID existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (id.Length < 10 || id.Length > 10)
                {
                    MessageBox.Show("Invalid UserID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (desp.Length > 254)
                {
                    MessageBox.Show("Desp capacity: " +desp.Length+ "has reached max capacity! Please write a description less than 255 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double priceValue = 0;
                bool priceTemp = Double.TryParse(price, out priceValue);
                if (priceTemp == false)
                {
                    MessageBox.Show("Please enter the correct data type of price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (priceValue <= 0)
                    {
                        MessageBox.Show("Price can not be negative", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                int quantityValue = 0;
                bool quantityTemp = int.TryParse(quantity, out quantityValue);
                if (quantityTemp == false)
                {
                    MessageBox.Show("Please enter the correct data type of quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (quantityValue <= 0)
                    {
                        MessageBox.Show("Quantity can not be negative", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                name = textInfo.ToTitleCase(name.ToLower());

                try
                {
                    SqlConnection conn = new SqlConnection(Program.strConn);
                    conn.Open();
                    String sSQL = "update __Product set product_name=@name, product_desp=@desp, product_price=@price, product_quantity=@quantity where product_ID=@id";
                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@desp", desp);
                    cmd.Parameters.AddWithValue("@price", priceValue);
                    cmd.Parameters.AddWithValue("@quantity", quantityValue);
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        MessageBox.Show("Updated Product: " + id, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRefresh_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error code 305", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Empty field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
