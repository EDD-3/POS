using System;
using System.Collections.Generic;
using System.Linq;
using ProjectSale.Models;
using ProjectSale.Presentations;
using System.Windows.Forms;
using System.Data.Entity;
using ProjectSale.Controllers.HelperClasses;

namespace ProjectSale.Controllers
{
    public class EmployeeController
    {
        DataGridView dgv;
        Employee emp;
        public EmployeeController(ref DataGridView dgv)
        {
            this.dgv = dgv;
            RefreshGridView();
        }

        protected List<FilteredEmployee> GetEmployees()
        {
            using (posEntities db = new posEntities())
            {

                List<FilteredEmployee> dataSourceList = (from d in db.Employees
                           select new FilteredEmployee ()
                           {
                              id = d.id,
                              first_name = d.first_name,
                              last_name = d.last_name,
                              telephone = d.telephone,
                              hired_date = d.hired_date,
                              birthdate = d.birthdate,
                              address = d.address
                           }).ToList();

                return dataSourceList;
            }
        }

        public void UpdateEmployee()
        {
            int? id = GetId();
            if (id != null)
            {
                using (posEntities db = new posEntities())
                {
                    emp = db.Employees.Find(id);
                }
                FrmNewEmployee frm = new FrmNewEmployee(this,emp);
                frm.ShowDialog();
                RefreshGridView();
            }

        }

        public void DeleteEmployee()
        {
            int? id = GetId();
            if (id != null)
            {
                string title = "¿Estás seguro?";
                string message = "Confirmar";
                DialogResult dialogResult = Dialogs.YesOrNoDialog(title,message);

                if (dialogResult == DialogResult.Yes)
                {
                    using (posEntities db = new posEntities())
                    {
                        Employee emp = db.Employees.Find(id);
                        db.Employees.Remove(emp);
                        db.SaveChanges();
                    }
                    RefreshGridView();
                }
            }
        }

        protected int? GetId()
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

        public void RefreshGridView()
        {
            dgv.DataSource = GetEmployees();
        }


        public void CreateEmployee()
        {
            FrmNewEmployee frm = new FrmNewEmployee(this);
            frm.ShowDialog();
            RefreshGridView();

        }

        public void PutEmployee(Employee newEmp) 
        {
            using (posEntities db = new posEntities())
            {
                emp.first_name = newEmp.first_name;
                emp.last_name = newEmp.last_name;
                emp.birthdate = newEmp.birthdate;
                emp.address = newEmp.address;
                emp.telephone = newEmp.telephone;
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
            RefreshGridView();
        }

        public void InsertEmployee(Employee emp)
        {
            using (posEntities db = new posEntities())
            {
                db.Employees.Add(emp);
                db.SaveChanges();
            }
            RefreshGridView();
        }

        public void MissingFieldsDialog()
        {
            string title = "Faltan campos por llenar";
            string message = "Verifique los campos restantes";
            Dialogs.OkDialog(title, message);
        }
    }
}
