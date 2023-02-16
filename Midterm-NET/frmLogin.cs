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
using System.Configuration;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Midterm_NET
{
    public partial class frmLogin : Form
    {
        private int loginAttemps = 0;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtbxUsername;
        }
        private int informationIsFilled(String username, String password)
        {
            if (username.Length == 0 && password.Length == 0) 
            {
                //MessageBox.Show("Please fill in your username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 1;
            }
            else if (username.Length == 0)
            {
                //MessageBox.Show("Please fill in your password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 2;
            }
            else if (password.Length == 0)
            {
                //MessageBox.Show("Please fill in your username and password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 3;
            }
            else
            {
                return 0;
            }
        }
        private void clearAllTextBox()
        {
            txtbxUsername.Clear();
            txtbxPassword.Clear();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Do you want to Exit!?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private bool userExist(String username)
        {
            bool result = false;
            try
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String sSQL = "select employee_ID from __Employee where employee_ID=@username";
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Error Code: 90", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result;
        }
        private void chkbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxShowPassword.Checked == true)
            {
                txtbxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtbxPassword.UseSystemPasswordChar = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtbxUsername.Text.Trim();
            String password = txtbxPassword.Text.Trim();
            int informationIsFilled_tempValue = informationIsFilled(username, password);
            if (informationIsFilled_tempValue != 0)
            {
                if(informationIsFilled_tempValue == 1)
                {
                    MessageBox.Show("Please fill in your username and password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else if(informationIsFilled_tempValue == 2)
                {
                    MessageBox.Show("Please fill in your username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(informationIsFilled_tempValue == 3)
                {
                    MessageBox.Show("Please fill in your password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                clearAllTextBox();
            }
            else
            {
                bool userExist_tempValue = userExist(username);
                if(userExist_tempValue == true)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(Program.strConn);
                        conn.Open();
                        String sSQL = "select employee_ID from __Employee where employee_ID=@username and employee_phone=@password";
                        SqlCommand cmd = new SqlCommand(sSQL, conn);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            String temp = (String)dt.Rows[0][0];
                            //MessageBox.Show(temp);
                            Program.sessionEmployeeID = temp;
                            MessageBox.Show("Login Sucessfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            loginAttemps++;
                            MessageBox.Show("Invalid Login. Please check Username or Password!\nYou have: " + (5 - loginAttemps).ToString().Trim() + " tries left", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (loginAttemps == 5)
                            {
                                Application.Exit();
                            }
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error! Please reload the Application. Code 162", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("User does not exist! Please contact admin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
