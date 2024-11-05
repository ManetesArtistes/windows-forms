using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMA
{
    public partial class SelectAdminMode : BaseForm
    {
        public SelectAdminMode()
        {
            InitializeComponent();
        }

        private void buttonLogs_Click(object sender, EventArgs e)
        {
            this.Hide();

            Logs logsForm = new Logs();
            logsForm.Show();
        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            this.Hide();

            JsonManagement JsonForm = new JsonManagement();
            JsonForm.Show();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login LoginForm = new Login();
            LoginForm.Show();
        }
    }
}