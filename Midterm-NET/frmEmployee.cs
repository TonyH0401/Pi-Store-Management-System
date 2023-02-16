using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Midterm_NET
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            Load_DataGridViewEmployee();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void Load_DataGridViewEmployee()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Employee order by employee_ID asc, hired_date desc";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridViewEmployee.DataSource = dt;
                }
                else
                { 
                    MessageBox.Show("No employees", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error! Please reload the Application. Code 50", "Error");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_DataGridViewEmployee();
            clearAllTextBox();
            MessageBox.Show("Refreshed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearAllTextBox()
        {
            txtbxUsername.Clear();
            txtbxSalary.Clear();
            txtbxPhone.Clear();
            txtbxFullname.Clear();
            txtbxEmail.Clear();
            txtbxAddress.Clear();
            dateTimePickerJoinDate.Text = DateTime.Now.ToString().Trim();
        }

        private void dataGridViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;

            txtbxUsername.Enabled = false;

            try
            {
                DataGridViewRow row = dataGridViewEmployee.SelectedRows[0];
                txtbxUsername.Text = row.Cells[0].Value.ToString().Trim();
                txtbxFullname.Text = row.Cells[1].Value.ToString().Trim();
                txtbxEmail.Text = row.Cells[2].Value.ToString().Trim();
                txtbxPhone.Text = row.Cells[3].Value.ToString().Trim();
                txtbxAddress.Text = row.Cells[4].Value.ToString().Trim();
                txtbxSalary.Text = row.Cells[5].Value.ToString().Trim();
                dateTimePickerJoinDate.Text = row.Cells[6].Value.ToString().Trim();
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
            if(id.Length == 0)
            {
                MessageBox.Show("No employee id to delete", "Error");
                return;
            }
            if (userIdExist(id) == false) {
                MessageBox.Show("Employee does not exist!!!", "Error");
                return;
            }
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "delete from __Employee where employee_ID=@id";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Deleted Employee", "Notification");
                    btnRefresh_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error code 143", "Error");
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error! Please reload the Application. Code 229", "Error");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String id = txtbxUsername.Text.ToString().Trim();
            String name = txtbxFullname.Text.ToString().Trim();
            String email = txtbxEmail.Text.ToString().Trim();
            String phone = txtbxPhone.Text.ToString().Trim();
            String address = txtbxAddress.Text.ToString().Trim();
            int salary = 0;
            bool salaryCheck = Int32.TryParse(txtbxSalary.Text.ToString().Trim(), out salary);
            String date = dateTimePickerJoinDate.Value.ToString("yyyy-MM-dd").Trim();

            if((id.Length * name.Length * email.Length * phone.Length * address.Length * salary.ToString().Length * date.Length) != 0)
            {
                if(salaryCheck == false)
                {
                    MessageBox.Show("Salary must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(salaryCheck == true )
                {
                    if(salary < 0)
                    {
                        MessageBox.Show("Salary must be a positive number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if(email.Contains("@") == false)
                {
                    MessageBox.Show("Email is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (userIdExist(id.ToUpper()) == true)
                {
                    MessageBox.Show("User ID existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(id.Length < 10 || id.Length > 10)
                {
                    MessageBox.Show("Invalid UserID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(phone.Length > 10 || phone.Length < 10)
                {
                    MessageBox.Show("Invalid phone number! 10 characters only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                name = textInfo.ToTitleCase(name.ToLower());
                addEmployee(id.ToUpper(), name, email, phone, address, salary, date);
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
                String sSQL = "select * from __Employee where employee_ID=@id";
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
            catch (Exception)
            {

                MessageBox.Show("Error! Please reload the Application. Code 50", "Error");
            }
            return false;
        }

        private void addEmployee(String id, String name, String email, String phone, String address, int salary, String date)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "insert into __Employee values (@id, @name, @email, @phone, @address, @salary, @date)";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@salary", salary);
                cmd.Parameters.AddWithValue("@date", date);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Saved new Employee", "Notification");
                }
                else
                {
                    MessageBox.Show("Error code 211", "Error");
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Error! Please reload the Application. Code 229", "Error");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String id = txtbxUsername.Text.ToString().Trim();
            //MessageBox.Show(id);
            if (id.Length == 0)
            {
                MessageBox.Show("No employee id to update", "Error");
                return;
            }

            //String id = txtbxUsername.Text.ToString().Trim();
            String name = txtbxFullname.Text.ToString().Trim();
            String email = txtbxEmail.Text.ToString().Trim();
            String phone = txtbxPhone.Text.ToString().Trim();
            String address = txtbxAddress.Text.ToString().Trim();
            int salary = 0;
            bool salaryCheck = Int32.TryParse(txtbxSalary.Text.ToString().Trim(), out salary);
            String date = dateTimePickerJoinDate.Value.ToString("yyyy-MM-dd").Trim();
            if ((id.Length * name.Length * email.Length * phone.Length * address.Length * salary.ToString().Length * date.Length) != 0)
            {
                if (salaryCheck == false)
                {
                    MessageBox.Show("Salary must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (salaryCheck == true)
                {
                    if (salary < 0)
                    {
                        MessageBox.Show("Salary must be a positive number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
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
                    String sSQL = "update __Employee set employee_name=@name, employee_email=@email, employee_phone=@phone, employee_address=@address, employee_salary=@salary, hired_date=@date where employee_ID=@id";
                    SqlCommand cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@date", date);
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        MessageBox.Show("Updated Employee: " + id, "Notification");
                        btnRefresh_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error code 358", "Error");
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
