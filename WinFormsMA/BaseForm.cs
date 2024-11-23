namespace WinFormsMA
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.FormClosing += new FormClosingEventHandler(BaseForm_FormClosing);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configura la finestra perquè no sigui redimensionable
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Evita redimensionament
            this.MaximizeBox = false; // Deshabilita el botó de maximitzar
            this.MinimizeBox = true; // Permet minimitzar si ho desitges

            rmFocus();
        }

        private void rmFocus()
        {
            Panel dummyPanel = new Panel();
            dummyPanel.Size = new Size(1, 1);
            dummyPanel.Visible = false;
            this.Controls.Add(dummyPanel);

            this.Load += (s, e) => this.ActiveControl = dummyPanel;
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}