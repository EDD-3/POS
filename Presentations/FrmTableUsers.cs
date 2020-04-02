using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectSale.Controllers;

namespace ProjectSale.Presentations
{   
    
    public partial class FrmTableUsers : Form
    {
        UserController controller;
        public FrmTableUsers()
        {
            InitializeComponent();
            controller = new UserController(ref dgvUsers);
        }

        private void FrmTableUsers_Load(object sender, EventArgs e)
        {

        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            controller.CreateUser();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            controller.UpdateUser();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            controller.DeleteUser();
        }
    }
}
