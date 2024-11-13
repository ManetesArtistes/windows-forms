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
    public partial class EditCenter : Form
    {
        private List<JsonBase.Center> centers;
        public EditCenter(List<JsonBase.Center> centers)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.centers = centers;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxEditCenter.Text.Length == 0)
            {
                MessageBox.Show("Afegeix el nom d'un centre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();

                Stats statsForm = new Stats(centers);
                statsForm.Show();
            }
        }
    }
}
