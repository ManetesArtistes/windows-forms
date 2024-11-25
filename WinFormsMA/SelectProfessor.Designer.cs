namespace WinFormsMA
{
    partial class SelectProfessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectProfessor));
            buttonLeft = new Button();
            labelStats = new Label();
            labelCenter = new Label();
            labelClass = new Label();
            comboBoxCenter = new ComboBox();
            comboBoxClass = new ComboBox();
            buttonCentre = new Button();
            buttonClass = new Button();
            comboBoxStudent = new ComboBox();
            labelStudent = new Label();
            groupBoxStats = new GroupBox();
            labelTime = new Label();
            labelTimestamp = new Label();
            labelDraws = new Label();
            buttonRightDraw = new Button();
            buttonLeftDraw = new Button();
            pictureBox1 = new PictureBox();
            labelSimon = new Label();
            pictureBoxSimon = new PictureBox();
            labelDrawsDone = new Label();
            buttonEditCenter = new Button();
            buttonEditClass = new Button();
            labelImages = new Label();
            buttonDownload = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelUsedColors = new Label();
            groupBoxStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSimon).BeginInit();
            SuspendLayout();
            // 
            // buttonLeft
            // 
            buttonLeft.Location = new Point(22, 25);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(35, 35);
            buttonLeft.TabIndex = 4;
            buttonLeft.Text = "←";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // labelStats
            // 
            labelStats.AutoSize = true;
            labelStats.BackColor = Color.Transparent;
            labelStats.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStats.ForeColor = SystemColors.ControlLightLight;
            labelStats.Location = new Point(66, 29);
            labelStats.Name = "labelStats";
            labelStats.Size = new Size(126, 25);
            labelStats.TabIndex = 3;
            labelStats.Text = "Estadístiques";
            // 
            // labelCenter
            // 
            labelCenter.AutoSize = true;
            labelCenter.BackColor = Color.Transparent;
            labelCenter.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            labelCenter.ForeColor = SystemColors.Window;
            labelCenter.Location = new Point(105, 109);
            labelCenter.Name = "labelCenter";
            labelCenter.Size = new Size(92, 35);
            labelCenter.TabIndex = 5;
            labelCenter.Text = "Centre";
            // 
            // labelClass
            // 
            labelClass.AutoSize = true;
            labelClass.BackColor = Color.Transparent;
            labelClass.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            labelClass.ForeColor = SystemColors.Window;
            labelClass.Location = new Point(105, 169);
            labelClass.Name = "labelClass";
            labelClass.Size = new Size(87, 35);
            labelClass.TabIndex = 6;
            labelClass.Text = "Classe";
            // 
            // comboBoxCenter
            // 
            comboBoxCenter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCenter.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCenter.FormattingEnabled = true;
            comboBoxCenter.Location = new Point(217, 115);
            comboBoxCenter.Name = "comboBoxCenter";
            comboBoxCenter.Size = new Size(309, 31);
            comboBoxCenter.TabIndex = 7;
            comboBoxCenter.SelectedIndexChanged += comboBoxCenter_SelectedIndexChanged;
            // 
            // comboBoxClass
            // 
            comboBoxClass.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClass.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxClass.FormattingEnabled = true;
            comboBoxClass.Location = new Point(217, 173);
            comboBoxClass.Name = "comboBoxClass";
            comboBoxClass.Size = new Size(309, 31);
            comboBoxClass.TabIndex = 8;
            comboBoxClass.SelectedIndexChanged += comboBoxClass_SelectedIndexChanged;
            // 
            // buttonCentre
            // 
            buttonCentre.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCentre.Location = new Point(546, 115);
            buttonCentre.Name = "buttonCentre";
            buttonCentre.Size = new Size(32, 32);
            buttonCentre.TabIndex = 9;
            buttonCentre.Text = "+";
            buttonCentre.UseVisualStyleBackColor = true;
            buttonCentre.Click += buttonCentre_Click;
            // 
            // buttonClass
            // 
            buttonClass.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonClass.Location = new Point(546, 173);
            buttonClass.Name = "buttonClass";
            buttonClass.Size = new Size(32, 32);
            buttonClass.TabIndex = 10;
            buttonClass.Text = "+";
            buttonClass.UseVisualStyleBackColor = true;
            buttonClass.Click += buttonClass_Click;
            // 
            // comboBoxStudent
            // 
            comboBoxStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStudent.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxStudent.FormattingEnabled = true;
            comboBoxStudent.Location = new Point(823, 113);
            comboBoxStudent.Name = "comboBoxStudent";
            comboBoxStudent.Size = new Size(309, 31);
            comboBoxStudent.TabIndex = 13;
            // 
            // labelStudent
            // 
            labelStudent.AutoSize = true;
            labelStudent.BackColor = Color.Transparent;
            labelStudent.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            labelStudent.ForeColor = SystemColors.Window;
            labelStudent.Location = new Point(711, 107);
            labelStudent.Name = "labelStudent";
            labelStudent.Size = new Size(97, 35);
            labelStudent.TabIndex = 11;
            labelStudent.Text = "Alumne";
            // 
            // groupBoxStats
            // 
            groupBoxStats.BackColor = Color.Transparent;
            groupBoxStats.BackgroundImage = Properties.Resources.wood_background;
            groupBoxStats.BackgroundImageLayout = ImageLayout.Stretch;
            groupBoxStats.Controls.Add(label3);
            groupBoxStats.Controls.Add(labelUsedColors);
            groupBoxStats.Controls.Add(label1);
            groupBoxStats.Controls.Add(label2);
            groupBoxStats.Controls.Add(labelTime);
            groupBoxStats.Controls.Add(labelTimestamp);
            groupBoxStats.Controls.Add(labelDraws);
            groupBoxStats.Controls.Add(buttonRightDraw);
            groupBoxStats.Controls.Add(buttonLeftDraw);
            groupBoxStats.Controls.Add(pictureBox1);
            groupBoxStats.Controls.Add(labelSimon);
            groupBoxStats.Controls.Add(pictureBoxSimon);
            groupBoxStats.Controls.Add(labelDrawsDone);
            groupBoxStats.FlatStyle = FlatStyle.Flat;
            groupBoxStats.ForeColor = Color.Transparent;
            groupBoxStats.Location = new Point(16, 255);
            groupBoxStats.Name = "groupBoxStats";
            groupBoxStats.Size = new Size(1228, 415);
            groupBoxStats.TabIndex = 15;
            groupBoxStats.TabStop = false;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.BackColor = Color.Transparent;
            labelTime.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTime.ForeColor = Color.White;
            labelTime.Location = new Point(529, 93);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(169, 37);
            labelTime.TabIndex = 24;
            labelTime.Text = "10/12/2024";
            // 
            // labelTimestamp
            // 
            labelTimestamp.AutoSize = true;
            labelTimestamp.BackColor = Color.Transparent;
            labelTimestamp.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            labelTimestamp.ForeColor = SystemColors.Window;
            labelTimestamp.Location = new Point(412, 92);
            labelTimestamp.Name = "labelTimestamp";
            labelTimestamp.Size = new Size(85, 37);
            labelTimestamp.TabIndex = 20;
            labelTimestamp.Text = "Data:";
            // 
            // labelDraws
            // 
            labelDraws.AutoSize = true;
            labelDraws.BackColor = Color.Transparent;
            labelDraws.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDraws.ForeColor = Color.White;
            labelDraws.Location = new Point(858, 28);
            labelDraws.Name = "labelDraws";
            labelDraws.Size = new Size(33, 37);
            labelDraws.TabIndex = 23;
            labelDraws.Text = "4";
            // 
            // buttonRightDraw
            // 
            buttonRightDraw.BackColor = Color.Transparent;
            buttonRightDraw.Font = new Font("Segoe UI", 15F);
            buttonRightDraw.ForeColor = Color.Black;
            buttonRightDraw.Location = new Point(1171, 71);
            buttonRightDraw.Name = "buttonRightDraw";
            buttonRightDraw.Size = new Size(35, 59);
            buttonRightDraw.TabIndex = 22;
            buttonRightDraw.Text = "→";
            buttonRightDraw.UseVisualStyleBackColor = false;
            // 
            // buttonLeftDraw
            // 
            buttonLeftDraw.BackColor = Color.Transparent;
            buttonLeftDraw.Font = new Font("Segoe UI", 15F);
            buttonLeftDraw.ForeColor = Color.Black;
            buttonLeftDraw.Location = new Point(941, 71);
            buttonLeftDraw.Name = "buttonLeftDraw";
            buttonLeftDraw.Size = new Size(35, 59);
            buttonLeftDraw.TabIndex = 20;
            buttonLeftDraw.Text = "←";
            buttonLeftDraw.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(996, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // labelSimon
            // 
            labelSimon.AutoSize = true;
            labelSimon.BackColor = Color.FromArgb(15, 13, 19);
            labelSimon.Font = new Font("Segoe UI", 35.25F, FontStyle.Bold);
            labelSimon.ForeColor = Color.White;
            labelSimon.Location = new Point(107, 175);
            labelSimon.Name = "labelSimon";
            labelSimon.Size = new Size(81, 62);
            labelSimon.TabIndex = 18;
            labelSimon.Text = "10";
            labelSimon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxSimon
            // 
            pictureBoxSimon.BackgroundImage = (Image)resources.GetObject("pictureBoxSimon.BackgroundImage");
            pictureBoxSimon.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxSimon.Location = new Point(23, 82);
            pictureBoxSimon.Name = "pictureBoxSimon";
            pictureBoxSimon.Size = new Size(250, 250);
            pictureBoxSimon.TabIndex = 20;
            pictureBoxSimon.TabStop = false;
            // 
            // labelDrawsDone
            // 
            labelDrawsDone.AutoSize = true;
            labelDrawsDone.BackColor = Color.Transparent;
            labelDrawsDone.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDrawsDone.ForeColor = Color.White;
            labelDrawsDone.Location = new Point(662, 28);
            labelDrawsDone.Name = "labelDrawsDone";
            labelDrawsDone.Size = new Size(196, 37);
            labelDrawsDone.TabIndex = 19;
            labelDrawsDone.Text = "Dibuixos Fets:";
            // 
            // buttonEditCenter
            // 
            buttonEditCenter.BackgroundImageLayout = ImageLayout.None;
            buttonEditCenter.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonEditCenter.Location = new Point(593, 115);
            buttonEditCenter.Name = "buttonEditCenter";
            buttonEditCenter.Size = new Size(32, 32);
            buttonEditCenter.TabIndex = 16;
            buttonEditCenter.Text = "☼";
            buttonEditCenter.UseVisualStyleBackColor = true;
            buttonEditCenter.Click += buttonEditCenter_Click;
            // 
            // buttonEditClass
            // 
            buttonEditClass.BackgroundImageLayout = ImageLayout.None;
            buttonEditClass.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonEditClass.Location = new Point(593, 174);
            buttonEditClass.Name = "buttonEditClass";
            buttonEditClass.Size = new Size(32, 32);
            buttonEditClass.TabIndex = 17;
            buttonEditClass.Text = "☼";
            buttonEditClass.UseVisualStyleBackColor = true;
            buttonEditClass.Click += buttonEditClass_Click;
            // 
            // labelImages
            // 
            labelImages.AutoSize = true;
            labelImages.BackColor = Color.Transparent;
            labelImages.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            labelImages.ForeColor = SystemColors.Window;
            labelImages.Location = new Point(711, 169);
            labelImages.Name = "labelImages";
            labelImages.Size = new Size(109, 35);
            labelImages.TabIndex = 18;
            labelImages.Text = "Imatges";
            // 
            // buttonDownload
            // 
            buttonDownload.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDownload.Location = new Point(823, 172);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(75, 32);
            buttonDownload.TabIndex = 19;
            buttonDownload.Text = "Descarrega";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(529, 142);
            label1.Name = "label1";
            label1.Size = new Size(145, 37);
            label1.TabIndex = 26;
            label1.Text = "12123232";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(412, 141);
            label2.Name = "label2";
            label2.Size = new Size(107, 37);
            label2.TabIndex = 25;
            label2.Text = "Temps:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(531, 195);
            label3.Name = "label3";
            label3.Size = new Size(33, 37);
            label3.TabIndex = 28;
            label3.Text = "7";
            // 
            // labelUsedColors
            // 
            labelUsedColors.AutoSize = true;
            labelUsedColors.BackColor = Color.Transparent;
            labelUsedColors.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            labelUsedColors.ForeColor = SystemColors.Window;
            labelUsedColors.Location = new Point(414, 194);
            labelUsedColors.Name = "labelUsedColors";
            labelUsedColors.Size = new Size(106, 37);
            labelUsedColors.TabIndex = 27;
            labelUsedColors.Text = "Colors:";
            // 
            // SelectProfessor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_dark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(buttonDownload);
            Controls.Add(labelImages);
            Controls.Add(buttonEditClass);
            Controls.Add(buttonEditCenter);
            Controls.Add(groupBoxStats);
            Controls.Add(comboBoxStudent);
            Controls.Add(labelStudent);
            Controls.Add(buttonClass);
            Controls.Add(buttonCentre);
            Controls.Add(comboBoxClass);
            Controls.Add(comboBoxCenter);
            Controls.Add(labelClass);
            Controls.Add(labelCenter);
            Controls.Add(buttonLeft);
            Controls.Add(labelStats);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectProfessor";
            Text = "Estadístiques";
            groupBoxStats.ResumeLayout(false);
            groupBoxStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSimon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLeft;
        private Label labelStats;
        private Label labelCenter;
        private Label labelClass;
        private ComboBox comboBoxCenter;
        private ComboBox comboBoxClass;
        private Button buttonCentre;
        private Button buttonClass;
        private ComboBox comboBoxStudent;
        private Label labelStudent;
        private GroupBox groupBoxStats;
        private Button buttonEditCenter;
        private Button buttonEditClass;
        private Label labelDrawsDone;
        private Label labelImages;
        private Button buttonDownload;
        private PictureBox pictureBoxSimon;
        private Label labelSimon;
        private Button buttonRightDraw;
        private Button buttonLeftDraw;
        private PictureBox pictureBox1;
        private Label labelDraws;
        private Label labelTimestamp;
        private Label labelTime;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelUsedColors;
    }
}