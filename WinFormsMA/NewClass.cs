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
    public partial class NewClass : BaseForm
    {
        public NewClass()
        {
            InitializeComponent();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            Stats statsForm = new Stats();
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
