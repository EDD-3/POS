using ProjectSale.Controllers;
using ProjectSale.Models;
using System;
using System.Windows.Forms;

namespace ProjectSale.Presentations
{
    public partial class FrmNewEmployee : Form
    {
        private readonly EmployeeController controller;
        private Employee emp;
        public FrmNewEmployee(EmployeeController controller = null, Employee emp = null)
        {
            this.emp = emp;
            this.controller = controller;
            InitializeComponent();

        }

        private void FrmNewEmployee_Load(object sender, EventArgs e)
        {
            FillFields();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (AreAllFieldsSet())
            {
                UpdateOrInsertNewEmployee();
                ClearFields();
                Close();
            }
            else
            {
                controller.MissingFieldsDialog();
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private bool AreAllFieldsSet()
        {
            return !string.IsNullOrWhiteSpace(txtAddress.Text) && !string.IsNullOrWhiteSpace(txtFirstName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text);
        }

        public void ClearFields()
        {
            txtAddress.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTelephone.Clear();
            dpBirthdate.ResetText();
        }

        private void FillFields()
        {
            if (emp != null)
            {
                txtAddress.Text = emp.address;
                txtFirstName.Text = emp.first_name;
                txtLastName.Text = emp.last_name;
                txtTelephone.Text = emp.telephone;
                dpBirthdate.Value = emp.birthdate;
            }
        }
        private void UpdateOrInsertNewEmployee()
        {
            if (emp != null)
            {
                Employee emp = new Employee
                {
                    first_name = txtFirstName.Text,
                    last_name = txtLastName.Text,
                    birthdate = dpBirthdate.Value,
                    address = txtAddress.Text,
                    telephone = txtTelephone.Text
                };

                controller.PutEmployee(emp);
            }

            else
            {
                emp = new Employee
                {
                    first_name = txtFirstName.Text,
                    last_name = txtLastName.Text,
                    birthdate = dpBirthdate.Value,
                    address = txtAddress.Text,
                    telephone = txtTelephone.Text,
                    hired_date = DateTime.Now,
                };

                controller.InsertEmployee(emp);
            }
        }

    }
}
