using ProjectSale.Controllers.HelperClasses;
using ProjectSale.Models;
using ProjectSale.Presentations;
using System.Linq;
using System.Windows.Forms;

namespace ProjectSale.Controllers
{
    class LoginController
    {
        public LoginController()
        {

        }

        public User SearchForUser(string username)
        {
            User user;
            using (posEntities db = new posEntities())
            {
                user = db.Users.FirstOrDefault(u => u.username == username);
            }
            return user;
        }

        public void RouteUser(string username, string password)
        {
            Form frm;
            User usr = SearchForUser(username);
            if (usr != null && Hashing.ValidatePassword(password, usr.password))
            {
                switch (usr.user_type_id)
                {
                    case 1:
                        frm = new FrmUser(usr);
                        frm.ShowDialog();
                        break;
                    case 2:
                        frm = new FrmSupervisor(usr);
                        frm.ShowDialog();
                        break;
                    case 3:
                        frm = new FrmAdmin(usr);
                        frm.ShowDialog();

                        break;
                }

            }
            else
            {
                string title = "Advertencia";
                string message = "Contraseña incorrecta o nombre de usuario incorrecto";
                Dialogs.OkDialog(title, message);
            }
        }
    }

}
