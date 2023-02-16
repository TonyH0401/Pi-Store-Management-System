using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterm_NET
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            Load_DataGridViewClient();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            this.Text = "Client Management - " + Program.sessionEmployeeID.ToString().Trim();
        }

        private void Load_DataGridViewClient()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client order by client_ID asc";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridViewClient.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Client", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Error! Please reload the Application. Code Error 55", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_DataGridViewClient();
            clearAllTextBox();
            MessageBox.Show("Refreshed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearAllTextBox()
        {
            txtbxUsername.Clear();
            txtbxPhone.Clear();
            txtbxFullname.Clear();
            txtbxEmail.Clear();
            txtbxAddress.Clear();
        }

        private void dataGridViewClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            txtbxUsername.Enabled = false;

            try
            {
                DataGridViewRow row = dataGridViewClient.SelectedRows[0];
                txtbxUsername.Text = row.Cells[0].Value.ToString().Trim();
                txtbxFullname.Text = row.Cells[1].Value.ToString().Trim();
                txtbxEmail.Text = row.Cells[2].Value.ToString().Trim();
                txtbxPhone.Text = row.Cells[3].Value.ToString().Trim();
                txtbxAddress.Text = row.Cells[4].Value.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAllTextBox();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtbxUsername.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String id = txtbxUsername.Text.ToString().Trim();
            if (id.Length == 0)
            {
                MessageBox.Show("No Client ID to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (userIdExist(id) == false)
            {
                MessageBox.Show("Client does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "delete from __Client where client_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Deleted Client!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefresh_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error code 143", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                //MessageBox.Show("Error! Please reload the Application. Code 229", "Error");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String id = txtbxUsername.Text.ToString().Trim();
            String name = txtbxFullname.Text.ToString().Trim();
            String email = txtbxEmail.Text.ToString().Trim();
            String phone = txtbxPhone.Text.ToString().Trim();
            String address = txtbxAddress.Text.ToString().Trim();

            if ((id.Length * name.Length * email.Length * phone.Length * address.Length != 0))
            {
                if (email.Contains("@") == false)
                {
                    MessageBox.Show("Email is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (userIdExist(id.ToUpper()) == true)
                {
                    MessageBox.Show("User ID existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (id.Length < 10 || id.Length > 10)
                {
                    MessageBox.Show("Invalid UserID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (phone.Length > 10 || phone.Length < 10)
                {
                    MessageBox.Show("Invalid phone number! 10 characters only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                name = textInfo.ToTitleCase(name.ToLower());
                addClient(id.ToUpper(), name, email, phone, address);
                btnRefresh_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Empty field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool userIdExist(String id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client where client_ID=@id";
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
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error! Please reload the Application. Code 214", "Error");
            }
            return false;
        }

        private void addClient(String id, String name, String email, String phone, String address)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "insert into __Client values (@id, @name, @email, @phone, @address)";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Saved new Client", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cannot insert new Client. Error code 239", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            String id = txtbxUsername.Text.ToString().Trim();
            //MessageBox.Show(id);
            if (id.Length == 0)
            {
                MessageBox.Show("No Client id to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //String id = txtbxUsername.Text.ToString().Trim();
            String name = txtbxFullname.Text.ToString().Trim();
            String email = txtbxEmail.Text.ToString().Trim();
            String phone = txtbxPhone.Text.ToString().Trim();
            String address = txtbxAddress.Text.ToString().Trim();
            if ((id.Length * name.Length * email.Length * phone.Length * address.Length) != 0)
            {
                if (email.Contains("@") == false)
                {
                    MessageBox.Show("Email is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (id.Length < 10 || id.Length > 10)
                {
                    MessageBox.Show("Invalid UserID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (phone.Length > 10 || phone.Length < 10)
                {
                    MessageBox.Show("Invalid phone number! 10 characters only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                name = textInfo.ToTitleCase(name.ToLower());
                try
                {
                    SqlConnection conn = new SqlConnection(Program.strConn);
                    conn.Open();
                    String sSQL = "update __Client set client_name=@name, client_email=@email, client_phone=@phone, client_address=@address where client_ID=@id";
                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        MessageBox.Show("Updated Employee: " + id, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
