namespace WinFormsMA.Forms
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            FormClosing += new FormClosingEventHandler(BaseForm_FormClosing);
            StartPosition = FormStartPosition.CenterScreen;

            // Configura la finestra perquè no sigui redimensionable
            FormBorderStyle = FormBorderStyle.FixedSingle; // Evita redimensionament
            MaximizeBox = false; // Deshabilita el botó de maximitzar
            MinimizeBox = true; // Permet minimitzar si ho desitges

            rmFocus();
        }

        private void rmFocus()
        {
            Panel dummyPanel = new Panel();
            dummyPanel.Size = new Size(1, 1);
            dummyPanel.Visible = false;
            Controls.Add(dummyPanel);

            Load += (s, e) => ActiveControl = dummyPanel;
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}