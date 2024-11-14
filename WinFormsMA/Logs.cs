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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsMA
{
    public partial class Logs : BaseForm
    {
        private List<JsonBase.Center> centers;
        public Logs(List<JsonBase.Center> centers)
        {
            InitializeComponent();
            this.centers = centers;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectAdminMode SelectForm = new SelectAdminMode(centers);
            SelectForm.Show();
        }
    }
}