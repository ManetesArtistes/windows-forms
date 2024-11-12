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
            string centerName = textBoxNewCenter.Text.Trim();

            if (centerName.Length == 0)
            {
                MessageBox.Show("Afegeix el nom d'un centre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string centerId = Guid.NewGuid().ToString();
                

                string ftpUrl = Utils.GetEnvVariable("FTP_URL");
                string ftpUsername = Utils.GetEnvVariable("FTP_USERNAME");
                string ftpPassword = Utils.GetEnvVariable("FTP_PASSWORD");

                Ftp ftpConnection = new Ftp(ftpUrl, ftpUsername, ftpPassword);

                string ftpCenterPath = $"{centerName}_{centerId}";
                ftpConnection.CreateDirectory(ftpCenterPath);

                MessageBox.Show("Centre creat", "Correcte", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                Stats statsForm = new Stats();
                statsForm.Show();
            }
        }
    }
}
