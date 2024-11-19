using System;
using System.IO;
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
    public partial class NewCenter : Form
    {
        private List<JsonBase.Center> centers;
        public NewCenter(List<JsonBase.Center> centers)
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
            string centerName = textBoxNewCenter.Text.Trim();

            if (string.IsNullOrEmpty(centerName))
            {
                MessageBox.Show("Afegeix el nom d'un centre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (centers.Any(c => c.CenterName.Equals(centerName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix un centre amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int centerId = centers.Any() ? centers.Max(c => c.CenterId) + 1 : 1;

                    JsonBase.Center center = new JsonBase.Center
                    {
                        CenterId = centerId,
                        CenterName = centerName,
                        Groups = null
                    };

                    centers.Add(center);


                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
