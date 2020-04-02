using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSale.Controllers.HelperClasses
{
    public class Dialogs
    {
        public static void OkDialog(string title, string message)
        {
            MessageBox.Show(title, message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult YesOrNoDialog(string title, string message) 
        {
            return MessageBox.Show(title, message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
