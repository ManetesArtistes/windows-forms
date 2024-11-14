using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsMA.Logic;

namespace WinFormsMA
{
    public partial class SelectAdminMode : BaseForm
    {
        private List<JsonBase.Center> centers;
        public SelectAdminMode(List<JsonBase.Center> centers)
        {
            InitializeComponent();
            this.centers = centers;
        }

        private void buttonLogs_Click(object sender, EventArgs e)
        {
            this.Hide();

            Logs logsForm = new Logs(centers);
            logsForm.Show();
        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            this.Hide();

            JsonManagement JsonForm = new JsonManagement(centers);
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