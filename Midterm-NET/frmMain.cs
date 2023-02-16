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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Midterm_NET
{
    public partial class frmMain : Form
    {
        // authentication
        // turn database into list of object
        private Employee currentEmployee = new Employee();
        public frmMain()
        {
            InitializeComponent();
        }

        private void Load_frmLogin()
        {
            frmLogin f = new frmLogin();
            f.ShowDialog();
        }

        private void textBoxReadOnlySetUp()
        {
            txtbxUsername.ReadOnly = true;
            txtbxFullname.ReadOnly = true;
            txtbxEmail.ReadOnly = true;
            txtbxPhone.ReadOnly = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Load_frmLogin();
            textBoxReadOnlySetUp();
            currentEmployee = getEmployeeInformation(Program.sessionEmployeeID);

            txtbxUsername.Text = currentEmployee.Id;
            txtbxFullname.Text = currentEmployee.Name;
            txtbxEmail.Text = currentEmployee.email;
            txtbxPhone.Text = currentEmployee.phone;

            this.Text = "Home page of - " + currentEmployee.Id;
        }

        private Employee getEmployeeInformation(String username)
        {
            //MessageBox.Show(username);
            Employee employee = new Employee();
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Employee where employee_ID=@username";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    String id = (String)dr[0];
                    String name = (String)dr[1];
                    String email = (String)dr[2];
                    String phone = (String)dr[3];
                    String address = (String)dr[4];
                    int salary = Int32.Parse((string)dr[5].ToString());
                    String date = (String)dr[6].ToString();
                    employee = new Employee(id, name, email, phone, address, salary, date);
                }
                else
                {
                    MessageBox.Show("Cannot find employee! Error code 67", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Error code 87", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return employee;
        }

        private bool authenticationEmployee(String username)
        {
            if(username.Equals("admin") == true || username.Contains("EM") == true)
            {
                return true;
            }
            return false;
        }

        private void manageEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //either message warning or disable completely
            if(authenticationEmployee(currentEmployee.Id) == true)
            {
                frmEmployee f = new frmEmployee();
                f.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void manageClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authenticationEmployee(currentEmployee.Id) == true)
            {
                frmClient f = new frmClient();
                f.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
