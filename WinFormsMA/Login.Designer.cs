namespace WinFormsMA
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            labelTitle = new Label();
            labelText = new Label();
            labelPassword = new Label();
            textBoxText = new TextBox();
            textBoxPassword = new TextBox();
            buttonLogIn = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Comic Sans MS", 35F, FontStyle.Bold);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(146, 67);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(537, 65);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "MANETES ARTISTES";
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.BackColor = Color.Transparent;
            labelText.Font = new Font("Segoe UI", 18F);
            labelText.Location = new Point(168, 207);
            labelText.Name = "labelText";
            labelText.Size = new Size(57, 32);
            labelText.TabIndex = 1;
            labelText.Text = "Text";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Segoe UI", 18F);
            labelPassword.Location = new Point(146, 257);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(111, 32);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password";
            // 
            // textBoxText
            // 
            textBoxText.Font = new Font("Segoe UI", 12F);
            textBoxText.Location = new Point(281, 213);
            textBoxText.Name = "textBoxText";
            textBoxText.Size = new Size(299, 29);
            textBoxText.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 12F);
            textBoxPassword.Location = new Point(281, 266);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(299, 29);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogIn
            // 
            buttonLogIn.FlatAppearance.BorderColor = Color.Black;
            buttonLogIn.Font = new Font("Segoe UI", 20F);
            buttonLogIn.Location = new Point(331, 350);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(140, 62);
            buttonLogIn.TabIndex = 5;
            buttonLogIn.Text = "Log In";
            buttonLogIn.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.login_background_v1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonLogIn);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxText);
            Controls.Add(labelPassword);
            Controls.Add(labelText);
            Controls.Add(labelTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "ManetesArtistes";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelText;
        private Label labelPassword;
        private TextBox textBoxText;
        private TextBox textBoxPassword;
        private Button buttonLogIn;
    }
}
