using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsMA
{
    public partial class Logs : BaseForm
    {
        public Logs()
        {
            InitializeComponent();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectAdminMode SelectForm = new SelectAdminMode();
            SelectForm.Show();
        }
    }
}