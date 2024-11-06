using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMA
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.FormClosing += new FormClosingEventHandler(BaseForm_FormClosing);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}