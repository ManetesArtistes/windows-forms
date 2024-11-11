namespace WinFormsMA
{
    partial class EditClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditClass));
            buttonSave = new Button();
            textBoxEditClass = new TextBox();
            labelEditClass = new Label();
            buttonLeft = new Button();
            labelTitleEditClass = new Label();
            textBoxStudent1 = new TextBox();
            pictureBox1 = new PictureBox();
            groupBoxEditClass = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxEditClass.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Comic Sans MS", 12F);
            buttonSave.Location = new Point(775, 109);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(126, 42);
            buttonSave.TabIndex = 17;
            buttonSave.Text = "GUARDAR";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // textBoxEditClass
            // 
            textBoxEditClass.Font = new Font("Comic Sans MS", 12F);
            textBoxEditClass.Location = new Point(467, 115);
            textBoxEditClass.Name = "textBoxEditClass";
            textBoxEditClass.PlaceholderText = "Editar classe";
            textBoxEditClass.Size = new Size(282, 30);
            textBoxEditClass.TabIndex = 16;
            textBoxEditClass.TextAlign = HorizontalAlignment.Center;
            // 
            // labelEditClass
            // 
            labelEditClass.AutoSize = true;
            labelEditClass.BackColor = Color.Transparent;
            labelEditClass.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            labelEditClass.ForeColor = SystemColors.Window;
            labelEditClass.Location = new Point(296, 109);
            labelEditClass.Name = "labelEditClass";
            labelEditClass.Size = new Size(169, 35);
            labelEditClass.TabIndex = 15;
            labelEditClass.Text = "Editar Classe";
            // 
            // buttonLeft
            // 
            buttonLeft.Location = new Point(17, 23);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(35, 35);
            buttonLeft.TabIndex = 14;
            buttonLeft.Text = "←";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // labelTitleEditClass
            // 
            labelTitleEditClass.AutoSize = true;
            labelTitleEditClass.BackColor = Color.Transparent;
            labelTitleEditClass.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitleEditClass.ForeColor = SystemColors.ControlLightLight;
            labelTitleEditClass.Location = new Point(61, 27);
            labelTitleEditClass.Name = "labelTitleEditClass";
            labelTitleEditClass.Size = new Size(122, 25);
            labelTitleEditClass.TabIndex = 13;
            labelTitleEditClass.Text = "Editar Classe";
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
            // groupBoxEditClass
            // 
            groupBoxEditClass.BackgroundImage = Properties.Resources.wood_background;
            groupBoxEditClass.BackgroundImageLayout = ImageLayout.Stretch;
            groupBoxEditClass.Controls.Add(textBoxStudent1);
            groupBoxEditClass.Controls.Add(pictureBox1);
            groupBoxEditClass.Location = new Point(274, 207);
            groupBoxEditClass.Name = "groupBoxEditClass";
            groupBoxEditClass.Size = new Size(745, 424);
            groupBoxEditClass.TabIndex = 18;
            groupBoxEditClass.TabStop = false;
            // 
            // EditClass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_dark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(buttonSave);
            Controls.Add(textBoxEditClass);
            Controls.Add(labelEditClass);
            Controls.Add(buttonLeft);
            Controls.Add(labelTitleEditClass);
            Controls.Add(groupBoxEditClass);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditClass";
            Text = "Editar Classe";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxEditClass.ResumeLayout(false);
            groupBoxEditClass.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private TextBox textBoxEditClass;
        private Label labelEditClass;
        private Button buttonLeft;
        private Label labelTitleEditClass;
        private TextBox textBoxStudent1;
        private PictureBox pictureBox1;
        private GroupBox groupBoxEditClass;
    }
}