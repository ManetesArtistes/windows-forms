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
            labelColoringPages = new Label();
            labelSimon = new Label();
            buttonEditCenter = new Button();
            buttonEditClass = new Button();
            labelImages = new Label();
            buttonDownload = new Button();
            groupBoxStats.SuspendLayout();
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
            groupBoxStats.Controls.Add(labelColoringPages);
            groupBoxStats.Controls.Add(labelSimon);
            groupBoxStats.FlatStyle = FlatStyle.Flat;
            groupBoxStats.ForeColor = Color.Transparent;
            groupBoxStats.Location = new Point(16, 255);
            groupBoxStats.Name = "groupBoxStats";
            groupBoxStats.Size = new Size(1228, 415);
            groupBoxStats.TabIndex = 15;
            groupBoxStats.TabStop = false;
            // 
            // labelColoringPages
            // 
            labelColoringPages.AutoSize = true;
            labelColoringPages.BackColor = Color.Transparent;
            labelColoringPages.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelColoringPages.ForeColor = Color.White;
            labelColoringPages.Location = new Point(564, 28);
            labelColoringPages.Name = "labelColoringPages";
            labelColoringPages.Size = new Size(210, 37);
            labelColoringPages.TabIndex = 19;
            labelColoringPages.Text = "Coloring Pages";
            // 
            // labelSimon
            // 
            labelSimon.AutoSize = true;
            labelSimon.BackColor = Color.Transparent;
            labelSimon.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSimon.ForeColor = Color.White;
            labelSimon.Location = new Point(30, 28);
            labelSimon.Name = "labelSimon";
            labelSimon.Size = new Size(162, 37);
            labelSimon.TabIndex = 18;
            labelSimon.Text = "Simon Says";
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
        private Label labelColoringPages;
        private Label labelSimon;
        private Label labelImages;
        private Button buttonDownload;
    }
}