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
    public partial class EditClass : BaseForm
    {
        private List<JsonBase.Center> centers;
        public EditClass(List<JsonBase.Center> centers)
        {
            InitializeComponent();
            this.centers = centers;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            Stats statsForm = new Stats(centers);
            statsForm.Show();
        }
    }
}
