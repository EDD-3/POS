using ProjectSale.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectSale
{
    
    public partial class FrmLogin : Form
    {
        LoginController controller;
        public FrmLogin()
        {
            InitializeComponent();
            controller = new LoginController();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
                String username = txtUsername.Text;
                String password = txtPassword.Text;
            controller.RouteUser(username, password);
        }
    }
}
