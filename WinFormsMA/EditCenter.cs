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
        private JsonBase.Center centerToEdit;

        public EditCenter(List<JsonBase.Center> centers, JsonBase.Center centerToEdit)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.centers = centers;
            this.centerToEdit = centerToEdit;
            textBoxEditCenter.Text = centerToEdit.CenterName;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string newCenterName = textBoxEditCenter.Text.Trim();

            if (string.IsNullOrEmpty(newCenterName))
            {
                MessageBox.Show("El nom del centre no pot estar vuit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                centerToEdit.CenterName = newCenterName;

               this.DialogResult= DialogResult.OK;
               this.Close();
            }
        }
    }
}
