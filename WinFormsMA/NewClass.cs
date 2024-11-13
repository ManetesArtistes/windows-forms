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
    public partial class NewClass : BaseForm
    {
        private List<JsonBase.Center> centers;
        public NewClass(List<JsonBase.Center> centers)
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

        private void buttonCreate_Click(object sender, EventArgs e)
        {

            if (textBoxNewClass.Text.Length == 0) 
            {
                MessageBox.Show("Afegeix una classe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
            }
        }
    }
}
