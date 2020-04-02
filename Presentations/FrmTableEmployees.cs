using ProjectSale.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProjectSale.Controllers;
namespace ProjectSale.Presentations
{
    public partial class FrmTableEmployees : Form
    {
        EmployeeController controller;
        public FrmTableEmployees()
        {
            InitializeComponent();
            controller = new EmployeeController(ref dgvEmployees);

        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            controller.CreateEmployee();
        }

        private void FrmTableEmployees_Load(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
   
            controller.UpdateEmployee();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            controller.DeleteEmployee();
        
        }
    }
}
