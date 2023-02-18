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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }

        //search employee
        private bool empNameExist(String emp_name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Employee where employee_name=@name";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@name", emp_name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private DataTable getEmployeeByName(String emp_name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Employee where employee_name=@name";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@name", emp_name);
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

        private void btnSEByName_Click(object sender, EventArgs e)
        {
            String name = txtbxSEByName.Text.ToString().Trim();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            name = textInfo.ToTitleCase(name.ToLower());
            if (txtbxSEByName.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Empty Employee Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (empNameExist(name) == true)
            {
                String temp = "Data of " + name;
                frmSearchEx1 f = new frmSearchEx1(getEmployeeByName(name), temp);
                f.Show();
            }
            else
            {
                MessageBox.Show("Employee ID: " + name + " does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtbxSEByName.Clear();
        }

        private DataTable getEmployeeByID(String emp_id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Employee where employee_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", emp_id);
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

        private bool empIDExist(String emp_id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Employee where employee_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", emp_id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnSEByID_Click(object sender, EventArgs e)
        {
            if(txtbxSEByID.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Empty Employee ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(empIDExist(txtbxSEByID.Text.ToString().Trim()) == true)
            {
                String temp = "Data of " + txtbxSEByID.Text.ToString().Trim();
                frmSearchEx1 f = new frmSearchEx1(getEmployeeByID(txtbxSEByID.Text.ToString().Trim()), temp);
                f.Show();
            }
            else
            {
                MessageBox.Show("Employee ID: " + txtbxSEByID.Text.ToString().Trim() +" does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtbxSEByID.Clear();
        }

        private DataTable getEmployeeByTime(String time1, String time2)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Employee where hired_date <= @time1 and hired_date >= @time2";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@time1", time1);
                cmd.Parameters.AddWithValue("@time2", time2);
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

        private void btnSERangeTime_Click(object sender, EventArgs e)
        {
            String time1 = dateTimePickerSE1.Value.ToString("yyyy-MM-dd").Trim();
            String time2 = dateTimePickerSE2.Value.ToString("yyyy-MM-dd").Trim();

            DialogResult dr = MessageBox.Show("Are you sure: " + time1 + " and " + time2, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                String temp = "Data between " + time1 + " and " + time2;
                frmSearchEx1 f = new frmSearchEx1(getEmployeeByTime(time1, time2), temp);
                f.Show();

                dateTimePickerSE1.Value = DateTime.Now;
                dateTimePickerSE2.Value = DateTime.Now;
                txtbxSEByID.Clear();
                txtbxSEByName.Clear();
            }
        }

        //client
        private bool clientNameExist(String client_name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client where client_name=@name";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@name", client_name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private DataTable getClientByName(String client_name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client where client_name=@name";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@name", client_name);
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

        private void btnSCName_Click(object sender, EventArgs e)
        {
            String name = txtbxSCName.Text.ToString().Trim();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            name = textInfo.ToTitleCase(name.ToLower());
            if (name.Length == 0)
            {
                MessageBox.Show("Empty Client Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clientNameExist(name) == true)
            {
                String temp = "Data of " + name;
                frmSearchEx1 f = new frmSearchEx1(getClientByName(name), temp);
                f.Show();
            }
            else
            {
                MessageBox.Show("Client ID: " + name + " does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtbxSCName.Clear();
        }

        private DataTable getClientByID(String client_id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client where client_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", client_id);
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

        private bool clientIDExist(String client_id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client where client_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", client_id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnSCID_Click(object sender, EventArgs e)
        {
            String id = txtbxSCID.Text.ToString().Trim();
            if (id.Length == 0)
            {
                MessageBox.Show("Empty Client ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clientIDExist(id) == true)
            {
                String temp = "Data of " + txtbxSEByID.Text.ToString().Trim();
                frmSearchEx1 f = new frmSearchEx1(getClientByID(id), temp);
                f.Show();
            }
            else
            {
                MessageBox.Show("Client ID: " + id + " does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtbxSCID.Clear();
        }

        //product
        private bool productNameExist(String name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Product where product_name=@name";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@name", name);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private DataTable getProductByName(String name)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Product where product_name=@name";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@name", name);
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

        private void btnSPName_Click(object sender, EventArgs e)
        {
            String name = txtbxSPName.Text.ToString().Trim();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            name = textInfo.ToTitleCase(name.ToLower());
            if (name.Length == 0)
            {
                MessageBox.Show("Empty Product Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (productNameExist(name) == true)
            {
                String temp = "Data of " + name;
                frmSearchEx1 f = new frmSearchEx1(getProductByName(name), temp);
                f.Show();
            }
            else
            {
                MessageBox.Show("Product ID: " + name + " does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtbxSPName.Clear();
        }

        private bool productIDExist(String id)
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
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private DataTable getProductByID(String id)
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

        private void btnSPID_Click(object sender, EventArgs e)
        {
            String id = txtbxSPID.Text.ToString().Trim();
            if (id.Length == 0)
            {
                MessageBox.Show("Empty Product ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (productIDExist(id) == true)
            {
                String temp = "Data of " + id;
                frmSearchEx1 f = new frmSearchEx1(getProductByID(id), temp);
                f.Show();
            }
            else
            {
                MessageBox.Show("Product ID: " + id + " does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtbxSPID.Clear();
        }

        //Order
        private bool orderIDExist(String id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Order where order_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private DataTable getOrderByID(String id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Order where order_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
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

        private void btnSOID_Click(object sender, EventArgs e)
        {
            String id = txtbxSOID.Text.ToString().Trim();
            if (id.Length == 0)
            {
                MessageBox.Show("Empty Order ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (orderIDExist(id) == true)
            {
                String temp = "Data of " + id;
                frmSearchEx1 f = new frmSearchEx1(getOrderByID(id), temp, 1);
                f.Show();
            }
            else
            {
                MessageBox.Show("Order ID: " + id + " does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtbxSPID.Clear();
        }

        private DataTable getOrderByTime(String time1, String time2)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Order where order_data <= @time1 and order_data >= @time2";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@time1", time1);
                cmd.Parameters.AddWithValue("@time2", time2);
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

        private void btnSORange_Click(object sender, EventArgs e)
        {
            String time1 = dateTimePickerSO1.Value.ToString("yyyy-MM-dd").Trim();
            String time2 = dateTimePickerSO2.Value.ToString("yyyy-MM-dd").Trim();

            DialogResult dr = MessageBox.Show("Are you sure: " + time1 + " and " + time2, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                String temp = "Data between " + time1 + " and " + time2;
                frmSearchEx1 f = new frmSearchEx1(getOrderByTime(time1, time2), temp, 1);
                f.Show();

                dateTimePickerSO1.Value = DateTime.Now;
                dateTimePickerSO2.Value = DateTime.Now;
                txtbxSOID.Clear();
            }
        }

        //Bill
        private bool billIDExist(String id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Bill where bill_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private DataTable getBillByID(String id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Bill where bill_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
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

        private void btnSBID_Click(object sender, EventArgs e)
        {
            String id = txtbxSBID.Text.ToString().Trim();
            if (id.Length == 0)
            {
                MessageBox.Show("Empty Bill ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (billIDExist(id) == true)
            {
                String temp = "Data of " + id;
                frmSearchEx1 f = new frmSearchEx1(getBillByID(id), temp, 1);
                f.Show();
            }
            else
            {
                MessageBox.Show("Bill ID: " + id + " does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtbxSBID.Clear();
        }

        private DataTable getBillByTime(String time1, String time2)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Bill where bill_date <= @time1 and bill_date >= @time2";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@time1", time1);
                cmd.Parameters.AddWithValue("@time2", time2);
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

        private void btnSBRange_Click(object sender, EventArgs e)
        {
            String time1 = dateTimePickerSB1.Value.ToString("yyyy-MM-dd").Trim();
            String time2 = dateTimePickerSB2.Value.ToString("yyyy-MM-dd").Trim();

            DialogResult dr = MessageBox.Show("Are you sure: " + time1 + " and " + time2, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                String temp = "Data between " + time1 + " and " + time2;
                frmSearchEx1 f = new frmSearchEx1(getBillByTime(time1, time2), temp);
                f.Show();

                dateTimePickerSB1.Value = DateTime.Now;
                dateTimePickerSB2.Value = DateTime.Now;
                txtbxSBID.Clear();
            }
        }
    }
}
