namespace WinFormsMA
{
    partial class NewClass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewClass));
            buttonLeft = new Button();
            labelTitleNewClass = new Label();
            buttonCreate = new Button();
            textBoxNewClass = new TextBox();
            labelNewClass = new Label();
            groupBoxNewClass = new GroupBox();
            textBoxStudent1 = new TextBox();
            pictureBox1 = new PictureBox();
            groupBoxNewClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonLeft
            // 
            buttonLeft.Location = new Point(22, 25);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(35, 35);
            buttonLeft.TabIndex = 6;
            buttonLeft.Text = "←";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // labelTitleNewClass
            // 
            labelTitleNewClass.AutoSize = true;
            labelTitleNewClass.BackColor = Color.Transparent;
            labelTitleNewClass.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitleNewClass.ForeColor = SystemColors.ControlLightLight;
            labelTitleNewClass.Location = new Point(66, 29);
            labelTitleNewClass.Name = "labelTitleNewClass";
            labelTitleNewClass.Size = new Size(117, 25);
            labelTitleNewClass.TabIndex = 5;
            labelTitleNewClass.Text = "Nova Classe";
            // 
            // buttonCreate
            // 
            buttonCreate.Font = new Font("Comic Sans MS", 12F);
            buttonCreate.Location = new Point(780, 111);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(126, 42);
            buttonCreate.TabIndex = 11;
            buttonCreate.Text = "CREAR";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // textBoxNewClass
            // 
            textBoxNewClass.Font = new Font("Comic Sans MS", 12F);
            textBoxNewClass.Location = new Point(472, 117);
            textBoxNewClass.Name = "textBoxNewClass";
            textBoxNewClass.PlaceholderText = "Nova classe";
            textBoxNewClass.Size = new Size(282, 30);
            textBoxNewClass.TabIndex = 10;
            textBoxNewClass.TextAlign = HorizontalAlignment.Center;
            // 
            // labelNewClass
            // 
            labelNewClass.AutoSize = true;
            labelNewClass.BackColor = Color.Transparent;
            labelNewClass.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            labelNewClass.ForeColor = SystemColors.Window;
            labelNewClass.Location = new Point(301, 111);
            labelNewClass.Name = "labelNewClass";
            labelNewClass.Size = new Size(155, 35);
            labelNewClass.TabIndex = 9;
            labelNewClass.Text = "Nova Classe";
            // 
            // groupBoxNewClass
            // 
            groupBoxNewClass.BackgroundImage = Properties.Resources.wood_background;
            groupBoxNewClass.BackgroundImageLayout = ImageLayout.Stretch;
            groupBoxNewClass.Controls.Add(textBoxStudent1);
            groupBoxNewClass.Controls.Add(pictureBox1);
            groupBoxNewClass.Location = new Point(279, 209);
            groupBoxNewClass.Name = "groupBoxNewClass";
            groupBoxNewClass.Size = new Size(745, 424);
            groupBoxNewClass.TabIndex = 12;
            groupBoxNewClass.TabStop = false;
            groupBoxNewClass.Text = "Nova Classe";
            // 
            // textBoxStudent1
            // 
            textBoxStudent1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxStudent1.Location = new Point(137, 60);
            textBoxStudent1.Name = "textBoxStudent1";
            textBoxStudent1.PlaceholderText = "Alumne 1";
            textBoxStudent1.Size = new Size(509, 37);
            textBoxStudent1.TabIndex = 1;
            textBoxStudent1.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(35, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // NewClass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = Properties.Resources.background_dark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(groupBoxNewClass);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxNewClass);
            Controls.Add(labelNewClass);
            Controls.Add(buttonLeft);
            Controls.Add(labelTitleNewClass);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NewClass";
            Text = "NewClass";
            groupBoxNewClass.ResumeLayout(false);
            groupBoxNewClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLeft;
        private Label labelTitleNewClass;
        private Button buttonCreate;
        private TextBox textBoxNewClass;
        private Label labelNewClass;
        private GroupBox groupBoxNewClass;
        private TextBox textBoxStudent1;
        private PictureBox pictureBox1;
    }
}