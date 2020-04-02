using ProjectSale.Controllers.HelperClasses;
using ProjectSale.Models;
using ProjectSale.Presentations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ProjectSale.Controllers
{
    public class UserController
    {
        DataGridView dgv;
        User usr;
        public UserController(ref DataGridView dgv)
        {
            this.dgv = dgv;
            RefreshGridView();
        }

        public void UpdateUser()
        {
            int? id = GetId();
            if (id != null)
            {
                using (posEntities db = new posEntities())
                {
                    usr = db.Users.Find(id);
                }
                FrmNewUser frm = new FrmNewUser(this, usr);
                frm.ShowDialog();
                RefreshGridView();
            }

        }

        public void PutUser(User newUsr)
        {
            if (usr.employee_id == newUsr.employee_id)
            {

                using (posEntities db = new posEntities())
                {
                    string textPassword = newUsr.password;
                    usr.password = HashUserPassword(textPassword);
                    usr.username = newUsr.username;
                    usr.user_type_id = newUsr.user_type_id;
                    db.Entry(usr).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }
            else if (!HasRelationships(newUsr))
            {
                using (posEntities db = new posEntities())
                {
                    string textPassword = newUsr.password;
                    usr.password = HashUserPassword(textPassword);
                    usr.username = newUsr.username;
                    usr.user_type_id = newUsr.user_type_id;
                    usr.employee_id = newUsr.employee_id;
                    db.Entry(usr).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }
            else
            {
                string title = "Ya hay un usuario relacionado al empleado seleccionado";
                string message = "Advertencia";
                Dialogs.OkDialog(title, message);

            }

            RefreshGridView();
        }
        public void InsertUser(User usr)
        {
            string textPassword = usr.password;
            usr.password = HashUserPassword(textPassword);

            if (!HasRelationships(usr))
            {
                using (posEntities db = new posEntities())
                {
 
                    db.Users.Add(usr);
                    db.SaveChanges();
                    RefreshGridView();
                }
            }
            else
            {
                string title = "Ya hay un usuario relacionado al empleado seleccionado";
                string message = "Advertencia";
                Dialogs.OkDialog(title, message);
            }

        }
        private List<FilteredUser> GetUsers()
        {
            using (posEntities db = new posEntities())
            {
                var users = (from user in db.Users
                             join type in db.User_type on user.user_type_id equals type.id
                             join emp in db.Employees on user.employee_id equals emp.id
                             select new FilteredUser { id = user.id, employee_first_name = emp.first_name, employee_last_name = emp.last_name, username = user.username, user_type = type.usr_type }).ToList();

                return users;

            }
        }

        public void RefreshGridView()
        {
            dgv.DataSource = GetUsers();
        }

        public void MissingFieldsDialog()
        {

            string title = "Faltan campos por llenar";
            string message = "Verifique los campos restantes";
            Dialogs.OkDialog(title, message);

        }

        private string HashUserPassword(string password)
        {
            return Hashing.HashPassword(password);
        }

        private bool HasRelationships(User usr)
        {
            using (posEntities db = new posEntities())
            {
                User user = db.Users.FirstOrDefault(u => u.employee_id == usr.employee_id);
                if (user != null)
                {
                    return true;
                }
            }

            return false;
        }

        public void CreateUser()
        {
            FrmNewUser frm = new FrmNewUser(this);
            frm.ShowDialog();
            RefreshGridView();

        }

        private int? GetId()
        {
            try
            {
                int id = int.Parse(dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value.ToString());
                return id;
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show($"An exception has ocurred {e}");
                return null;
            }
        }

        public void DeleteUser()
        {
            int? id = GetId();
            if (id != null)
            {
                string title = "¿Estás seguro?";
                string message = "Confirmar";
                DialogResult dialogResult = Dialogs.YesOrNoDialog(title, message);

                if (dialogResult == DialogResult.Yes)
                {
                    using (posEntities db = new posEntities())
                    {
                        User usr = db.Users.Find(id);
                        db.Users.Remove(usr);
                        db.SaveChanges();
                    }
                    RefreshGridView();
                }
            }
        }

    }
}
