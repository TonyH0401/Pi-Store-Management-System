using CsvHelper;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
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

            if (authenticationEmployee(currentEmployee.Id) == false)
            {
                exportCSVToolStripMenuItem.Enabled = false;
            }

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

        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authenticationEmployee(currentEmployee.Id) == true)
            {
                frmProduct f = new frmProduct();
                f.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void placeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authenticationEmployee(currentEmployee.Id) == true)
            {
                frmPlaceOrder f = new frmPlaceOrder();
                f.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void manageOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authenticationEmployee(currentEmployee.Id) == true)
            {
                frmOrder f = new frmOrder();
                f.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void generateBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authenticationEmployee(currentEmployee.Id) == true)
            {
                frmBill f = new frmBill();
                f.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //csv
        private DataTable getProduct()
        {
            DataTable dtRes = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Product";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    dtRes = dt;
                }
                else
                {
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtRes;
        }

        public List<Product> convertDataTableToListProduct(DataTable datatable)
        {
            List<Product> res = new List<Product>();
            foreach (DataRow row in datatable.Rows)
            {
                Product product = new Product();
                product.id = row[0].ToString();
                product.Name = row[1].ToString();
                product.quantity = int.Parse(row[4].ToString());
                product.total = double.Parse(row[3].ToString());
                res.Add(product);
            }
            return res;
        }

        private DataTable getEmployee()
        {
            DataTable dtRes = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Employee";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    dtRes = dt;
                }
                else
                {
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtRes;
        }

        public List<Employee> convertDataTableToListEmployee(DataTable datatable)
        {
            List<Employee> res = new List<Employee>();
            foreach (DataRow row in datatable.Rows)
            {
                Employee employee = new Employee();
                employee.Id = row[0].ToString();
                employee.Name = row[1].ToString();
                employee.email = row[2].ToString();
                employee.phone = row[3].ToString();
                employee.address = row[4].ToString();
                employee.salary = int.Parse(row[5].ToString());
                employee.hire_date = row[6].ToString();
                res.Add(employee);
            }
            return res;
        }

        private DataTable getClient()
        {
            DataTable dtRes = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select * from __Client";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> listBoxList = new List<String>();
                if (dt.Rows.Count > 0)
                {
                    dtRes = dt;
                }
                else
                {
                    //MessageBox.Show("No Bill data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Customer Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtRes;
        }

        public List<Client> convertDataTableToListClient(DataTable datatable)
        {
            List<Client> res = new List<Client>();
            foreach (DataRow row in datatable.Rows)
            {
                Client client = new Client();
                client.id = row[0].ToString();
                client.name = row[1].ToString();
                client.email = row[2].ToString();
                client.phone = row[3].ToString();
                client.address = row[4].ToString();
                res.Add(client);
            }
            return res;
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (authenticationEmployee(currentEmployee.Id) == false)
            //{
            //    MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            var records = convertDataTableToListEmployee(getEmployee());
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "CSV|*.csv",
                ValidateNames = true,
            })
            {
                sfd.FileName = "Employee List";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(records);
                        }
                    }
                    MessageBox.Show("Employee List was Saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (authenticationEmployee(currentEmployee.Id) == false)
            //{
            //    MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            var records = convertDataTableToListProduct(getProduct());
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "CSV|*.csv",
                ValidateNames = true,
            })
            {
                sfd.FileName = "Product List";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(records);
                        }
                    }
                    MessageBox.Show("Product List was Saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (authenticationEmployee(currentEmployee.Id) == false)
            //{
            //    MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            var records = convertDataTableToListClient(getClient());
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "CSV|*.csv",
                ValidateNames = true,
            })
            {
                sfd.FileName = "Client List";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(records);
                        }
                    }
                    MessageBox.Show("Employee List was Saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (authenticationEmployee(currentEmployee.Id) == true)
            {
                frmSearch f = new frmSearch();
                f.Show();
            }
            else
            {
                MessageBox.Show("You are not allowed to view this page!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable dt = Load_Product_ID_Quantity();
            String seriesName = "Product Quantity";
            int maxValue = 250;

            frmChart f = new frmChart(dt, seriesName, maxValue);
            f.Show();
        }

        private DataTable Load_Product_ID_Quantity()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select product_name, product_quantity from __Product";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
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


    }
}
