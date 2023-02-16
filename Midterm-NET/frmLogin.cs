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
using System.Data.SqlClient;

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
            DialogResult dr = MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
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
                String sSQL = "select username from __Empoyee where account"

            }
            catch (Exception)
            {

                throw;
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
            if(informationIsFilled(username, password) != 0)
            {
                if(informationIsFilled(username, password) == 2)
                {
                    MessageBox.Show("Please fill in your username!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (informationIsFilled(username, password) == 3)
                {
                    MessageBox.Show("Please fill in your password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (informationIsFilled(username, password) == 1)
                {
                    MessageBox.Show("Please fill in your username and password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                clearAllTextBox();
            } 
            else
            {
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
