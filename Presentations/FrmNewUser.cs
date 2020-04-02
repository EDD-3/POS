using ProjectSale.Controllers;
using ProjectSale.Models;
using System;
using System.Linq;
using System.Windows.Forms;


namespace ProjectSale.Presentations
{
    public partial class FrmNewUser : Form
    {
        private readonly UserController controller;
        private User usr;
        public FrmNewUser(UserController controller = null, User usr = null)
        {
            this.controller = controller;
            this.usr = usr;
            InitializeComponent();
        }

        private void FrmNewUser_Load(object sender, EventArgs e)
        {
            if (usr != null)
            {
                FillFields();
            }

            FillComboBoxes();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            int employee_id = int.Parse(cbxEmployees.SelectedValue.ToString());
            int user_type_id = int.Parse(cbxUserTypes.SelectedValue.ToString());

            if (AreAllFieldsSet())
            {
                UpdateOrInsertNewUser(employee_id, user_type_id);
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

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private bool AreAllFieldsSet()
        {
            return !string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void FillFields()
        {
            txtUsername.Text = usr.username;
            using (posEntities db = new posEntities())
            {
                cbxEmployees.SelectedValue = db.Employees.Find(usr.employee_id);
                cbxUserTypes.SelectedValue = db.User_type.Find(usr.user_type_id);
            }
        }

        private void FillComboBoxes()
        {
            using (posEntities db = new posEntities())
            {
                cbxEmployees.DataSource = db.Employees.ToList();
                cbxEmployees.ValueMember = "id";
                cbxEmployees.DisplayMember = "first_name";
                cbxUserTypes.DataSource = db.User_type.ToList();
                cbxUserTypes.DisplayMember = "usr_type";
                cbxUserTypes.ValueMember = "id";
            }
        }

        private void UpdateOrInsertNewUser(int employee_id, int user_type_id)
        {
            if (usr != null)
            {
                User newUsr = new User
                {
                    username = txtUsername.Text,
                    password = txtPassword.Text,
                    user_type_id = user_type_id,
                    employee_id = employee_id
                };

                controller.PutUser(newUsr);


            }
            else
            {

                usr = new User
                {
                    username = txtUsername.Text,
                    password = txtPassword.Text,
                    user_type_id = user_type_id,
                    employee_id = employee_id

                };
                controller.InsertUser(usr);

            }
        }
    }
}
