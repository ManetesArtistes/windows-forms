namespace WinFormsMA
{
    partial class Stats
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
            buttonLeft = new Button();
            labelStats = new Label();
            labelCenter = new Label();
            labelClass = new Label();
            comboBoxCenter = new ComboBox();
            comboBoxClass = new ComboBox();
            buttonCentre = new Button();
            buttonClass = new Button();
            comboBoxGame = new ComboBox();
            comboBoxStudent = new ComboBox();
            labelGame = new Label();
            labelStudent = new Label();
            groupBoxStats = new GroupBox();
            buttonEditCenter = new Button();
            buttonEditClass = new Button();
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
            comboBoxCenter.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCenter.FormattingEnabled = true;
            comboBoxCenter.Items.AddRange(new object[] { "", "Centre1" });
            comboBoxCenter.Location = new Point(217, 115);
            comboBoxCenter.Name = "comboBoxCenter";
            comboBoxCenter.Size = new Size(309, 31);
            comboBoxCenter.TabIndex = 7;
            // 
            // comboBoxClass
            // 
            comboBoxClass.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxClass.FormattingEnabled = true;
            comboBoxClass.Items.AddRange(new object[] { "", "Classe1" });
            comboBoxClass.Location = new Point(217, 173);
            comboBoxClass.Name = "comboBoxClass";
            comboBoxClass.Size = new Size(309, 31);
            comboBoxClass.TabIndex = 8;
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
            // comboBoxGame
            // 
            comboBoxGame.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxGame.FormattingEnabled = true;
            comboBoxGame.Location = new Point(823, 175);
            comboBoxGame.Name = "comboBoxGame";
            comboBoxGame.Size = new Size(309, 31);
            comboBoxGame.TabIndex = 14;
            // 
            // comboBoxStudent
            // 
            comboBoxStudent.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxStudent.FormattingEnabled = true;
            comboBoxStudent.Location = new Point(823, 117);
            comboBoxStudent.Name = "comboBoxStudent";
            comboBoxStudent.Size = new Size(309, 31);
            comboBoxStudent.TabIndex = 13;
            // 
            // labelGame
            // 
            labelGame.AutoSize = true;
            labelGame.BackColor = Color.Transparent;
            labelGame.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            labelGame.ForeColor = SystemColors.Window;
            labelGame.Location = new Point(711, 171);
            labelGame.Name = "labelGame";
            labelGame.Size = new Size(56, 35);
            labelGame.TabIndex = 12;
            labelGame.Text = "Joc";
            // 
            // labelStudent
            // 
            labelStudent.AutoSize = true;
            labelStudent.BackColor = Color.Transparent;
            labelStudent.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            labelStudent.ForeColor = SystemColors.Window;
            labelStudent.Location = new Point(711, 111);
            labelStudent.Name = "labelStudent";
            labelStudent.Size = new Size(97, 35);
            labelStudent.TabIndex = 11;
            labelStudent.Text = "Alumne";
            // 
            // groupBoxStats
            // 
            groupBoxStats.BackgroundImage = Properties.Resources.wood_background;
            groupBoxStats.BackgroundImageLayout = ImageLayout.Stretch;
            groupBoxStats.Location = new Point(16, 255);
            groupBoxStats.Name = "groupBoxStats";
            groupBoxStats.Size = new Size(1228, 415);
            groupBoxStats.TabIndex = 15;
            groupBoxStats.TabStop = false;
            groupBoxStats.Text = "Estadístiques";
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
            // Stats
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_dark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(buttonEditClass);
            Controls.Add(buttonEditCenter);
            Controls.Add(groupBoxStats);
            Controls.Add(comboBoxGame);
            Controls.Add(comboBoxStudent);
            Controls.Add(labelGame);
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
            Name = "Stats";
            Text = "Estadístiques";
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
        private ComboBox comboBoxGame;
        private ComboBox comboBoxStudent;
        private Label labelGame;
        private Label labelStudent;
        private GroupBox groupBoxStats;
        private Button buttonEditCenter;
        private Button buttonEditClass;
    }
}