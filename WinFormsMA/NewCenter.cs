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
    public partial class NewCenter : Form
    {
        public NewCenter()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxNewCenter.Text.Length == 0)
            {
                MessageBox.Show("Afegeix el nom d'un centre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();

                Stats statsForm = new Stats();
                statsForm.Show();
            }
        }

       
    }
}
