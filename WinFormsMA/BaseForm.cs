using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsMA
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.FormClosing += new FormClosingEventHandler(BaseForm_FormClosing);
            this.StartPosition = FormStartPosition.CenterScreen;
            rmFocus();
        }

        private void rmFocus()
        {
            Panel dummyPanel = new Panel();
            dummyPanel.Size = new Size(1, 1);
            dummyPanel.Visible = false;
            this.Controls.Add(dummyPanel);

            this.Load += (s, e) => this.ActiveControl = dummyPanel;
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}