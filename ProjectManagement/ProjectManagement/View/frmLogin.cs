using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagement.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidData())
            {
                try
                {
                    tbl_AccountDAO dao = new tbl_AccountDAO();
                    bool result = dao.CheckLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    if (result)
                    {
                        this.Close();
                    }
                    else
                        MessageBox.Show("Wrong username or password!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public bool ValidData()
        {
            bool valid = true;
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorLogin.SetError(txtUsername, "Username must not be blank or empty!");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorLogin.SetError(txtPassword, "Password must not be blank or empty!");
                valid = false;
            }
            return valid;
        }

    }
}
