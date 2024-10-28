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
            labelUser = new Label();
            labelPassword = new Label();
            textBoxUser = new TextBox();
            textBoxPassword = new TextBox();
            buttonLogIn = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Comic Sans MS", 35F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(367, 175);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(537, 65);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "MANETES ARTISTES";
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.BackColor = Color.Transparent;
            labelUser.Font = new Font("Segoe UI", 18F);
            labelUser.ForeColor = SystemColors.Window;
            labelUser.Location = new Point(396, 307);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(80, 32);
            labelUser.TabIndex = 1;
            labelUser.Text = "Usuari";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.Transparent;
            labelPassword.Font = new Font("Segoe UI", 18F);
            labelPassword.ForeColor = SystemColors.Window;
            labelPassword.Location = new Point(394, 361);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(146, 32);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Contrasenya";
            // 
            // textBoxUser
            // 
            textBoxUser.Font = new Font("Segoe UI", 12F);
            textBoxUser.Location = new Point(552, 312);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(299, 29);
            textBoxUser.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 12F);
            textBoxPassword.Location = new Point(552, 365);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(299, 29);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogIn
            // 
            buttonLogIn.FlatAppearance.BorderColor = Color.Black;
            buttonLogIn.Font = new Font("Segoe UI", 20F);
            buttonLogIn.Location = new Point(627, 426);
            buttonLogIn.Name = "buttonLogIn";
            buttonLogIn.Size = new Size(140, 62);
            buttonLogIn.TabIndex = 5;
            buttonLogIn.Text = "Log In";
            buttonLogIn.UseVisualStyleBackColor = true;
            buttonLogIn.Click += buttonLogIn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_dark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(buttonLogIn);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUser);
            Controls.Add(labelPassword);
            Controls.Add(labelUser);
            Controls.Add(labelTitle);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "ManetesArtistes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelUser;
        private Label labelPassword;
        private TextBox textBoxUser;
        private TextBox textBoxPassword;
        private Button buttonLogIn;
    }
}
