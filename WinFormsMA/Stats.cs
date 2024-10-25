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
    public partial class Stats : BaseForm
    {
        public Stats()
        {
            InitializeComponent();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login loginForm = new Login();
            loginForm.Show();
        }

        private void buttonCentre_Click(object sender, EventArgs e)
        {
            NewCenter newCenterForm = new NewCenter();

            newCenterForm.ShowDialog();
        }

        private void buttonClass_Click(object sender, EventArgs e)
        {
            this.Hide();

            NewClass newClassForm = new NewClass();
            newClassForm.Show();
        }
    }
}
