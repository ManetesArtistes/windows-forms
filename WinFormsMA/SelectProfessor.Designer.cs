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
            labelSimonTotal = new Label();
            comboBoxDraws = new ComboBox();
            labelUsedColorsNum = new Label();
            labelUsedColors = new Label();
            labelDurationNum = new Label();
            labelDuration = new Label();
            labelTimestampNum = new Label();
            labelTimestamp = new Label();
            labelDraws = new Label();
            pictureBoxDraw = new PictureBox();
            labelSimon = new Label();
            pictureBoxSimon = new PictureBox();
            labelDrawsDone = new Label();
            buttonEditCenter = new Button();
            buttonEditClass = new Button();
            labelImages = new Label();
            buttonDownload = new Button();
            groupBoxStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDraw).BeginInit();
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
            comboBoxStudent.SelectedIndexChanged += comboBoxStudent_SelectedIndexChanged;
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
            groupBoxStats.Controls.Add(labelSimonTotal);
            groupBoxStats.Controls.Add(comboBoxDraws);
            groupBoxStats.Controls.Add(labelUsedColorsNum);
            groupBoxStats.Controls.Add(labelUsedColors);
            groupBoxStats.Controls.Add(labelDurationNum);
            groupBoxStats.Controls.Add(labelDuration);
            groupBoxStats.Controls.Add(labelTimestampNum);
            groupBoxStats.Controls.Add(labelTimestamp);
            groupBoxStats.Controls.Add(labelDraws);
            groupBoxStats.Controls.Add(pictureBoxDraw);
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
            // labelSimonTotal
            // 
            labelSimonTotal.Anchor = AnchorStyles.None;
            labelSimonTotal.BackColor = Color.Transparent;
            labelSimonTotal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSimonTotal.ForeColor = Color.White;
            labelSimonTotal.Location = new Point(31, 347);
            labelSimonTotal.Name = "labelSimonTotal";
            labelSimonTotal.Size = new Size(299, 45);
            labelSimonTotal.TabIndex = 31;
            labelSimonTotal.Text = "---";
            labelSimonTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxDraws
            // 
            comboBoxDraws.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDraws.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxDraws.FormattingEnabled = true;
            comboBoxDraws.Location = new Point(907, 49);
            comboBoxDraws.Name = "comboBoxDraws";
            comboBoxDraws.Size = new Size(252, 31);
            comboBoxDraws.TabIndex = 20;
            comboBoxDraws.SelectedIndexChanged += comboBoxDraws_SelectedIndexChanged;
            // 
            // labelUsedColorsNum
            // 
            labelUsedColorsNum.AutoSize = true;
            labelUsedColorsNum.BackColor = Color.Transparent;
            labelUsedColorsNum.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUsedColorsNum.ForeColor = Color.White;
            labelUsedColorsNum.Location = new Point(615, 295);
            labelUsedColorsNum.Name = "labelUsedColorsNum";
            labelUsedColorsNum.Size = new Size(50, 37);
            labelUsedColorsNum.TabIndex = 28;
            labelUsedColorsNum.Text = "---";
            // 
            // labelUsedColors
            // 
            labelUsedColors.AutoSize = true;
            labelUsedColors.BackColor = Color.Transparent;
            labelUsedColors.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            labelUsedColors.ForeColor = SystemColors.Window;
            labelUsedColors.Location = new Point(477, 294);
            labelUsedColors.Name = "labelUsedColors";
            labelUsedColors.Size = new Size(106, 37);
            labelUsedColors.TabIndex = 27;
            labelUsedColors.Text = "Colors:";
            // 
            // labelDurationNum
            // 
            labelDurationNum.AutoSize = true;
            labelDurationNum.BackColor = Color.Transparent;
            labelDurationNum.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDurationNum.ForeColor = Color.White;
            labelDurationNum.Location = new Point(615, 220);
            labelDurationNum.Name = "labelDurationNum";
            labelDurationNum.Size = new Size(116, 37);
            labelDurationNum.TabIndex = 26;
            labelDurationNum.Text = "---------";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.BackColor = Color.Transparent;
            labelDuration.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            labelDuration.ForeColor = SystemColors.Window;
            labelDuration.Location = new Point(474, 220);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(107, 37);
            labelDuration.TabIndex = 25;
            labelDuration.Text = "Temps:";
            // 
            // labelTimestampNum
            // 
            labelTimestampNum.AutoSize = true;
            labelTimestampNum.BackColor = Color.Transparent;
            labelTimestampNum.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTimestampNum.ForeColor = Color.White;
            labelTimestampNum.Location = new Point(615, 151);
            labelTimestampNum.Name = "labelTimestampNum";
            labelTimestampNum.Size = new Size(107, 37);
            labelTimestampNum.TabIndex = 24;
            labelTimestampNum.Text = "--/--/--";
            // 
            // labelTimestamp
            // 
            labelTimestamp.AutoSize = true;
            labelTimestamp.BackColor = Color.Transparent;
            labelTimestamp.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            labelTimestamp.ForeColor = SystemColors.Window;
            labelTimestamp.Location = new Point(474, 151);
            labelTimestamp.Name = "labelTimestamp";
            labelTimestamp.Size = new Size(85, 37);
            labelTimestamp.TabIndex = 20;
            labelTimestamp.Text = "Data:";
            // 
            // labelDraws
            // 
            labelDraws.AutoSize = true;
            labelDraws.BackColor = Color.Transparent;
            labelDraws.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDraws.ForeColor = Color.White;
            labelDraws.Location = new Point(724, 35);
            labelDraws.Name = "labelDraws";
            labelDraws.Size = new Size(40, 47);
            labelDraws.TabIndex = 23;
            labelDraws.Text = "0";
            // 
            // pictureBoxDraw
            // 
            pictureBoxDraw.BackgroundImage = Properties.Resources.background_square_landscape;
            pictureBoxDraw.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxDraw.Location = new Point(908, 130);
            pictureBoxDraw.Name = "pictureBoxDraw";
            pictureBoxDraw.Padding = new Padding(13, 11, 13, 11);
            pictureBoxDraw.Size = new Size(250, 250);
            pictureBoxDraw.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxDraw.TabIndex = 21;
            pictureBoxDraw.TabStop = false;
            // 
            // labelSimon
            // 
            labelSimon.Anchor = AnchorStyles.None;
            labelSimon.BackColor = Color.FromArgb(15, 13, 19);
            labelSimon.Font = new Font("Segoe UI", 33.25F, FontStyle.Bold);
            labelSimon.ForeColor = Color.White;
            labelSimon.Location = new Point(139, 153);
            labelSimon.Name = "labelSimon";
            labelSimon.Size = new Size(81, 62);
            labelSimon.TabIndex = 18;
            labelSimon.Text = "99";
            labelSimon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxSimon
            // 
            pictureBoxSimon.BackgroundImage = (Image)resources.GetObject("pictureBoxSimon.BackgroundImage");
            pictureBoxSimon.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxSimon.Location = new Point(53, 60);
            pictureBoxSimon.Name = "pictureBoxSimon";
            pictureBoxSimon.Size = new Size(250, 250);
            pictureBoxSimon.TabIndex = 20;
            pictureBoxSimon.TabStop = false;
            // 
            // labelDrawsDone
            // 
            labelDrawsDone.AutoSize = true;
            labelDrawsDone.BackColor = Color.Transparent;
            labelDrawsDone.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDrawsDone.ForeColor = Color.White;
            labelDrawsDone.Location = new Point(462, 32);
            labelDrawsDone.Name = "labelDrawsDone";
            labelDrawsDone.Size = new Size(248, 47);
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
            ((System.ComponentModel.ISupportInitialize)pictureBoxDraw).EndInit();
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
        private PictureBox pictureBoxDraw;
        private Label labelDraws;
        private Label labelTimestamp;
        private Label labelTimestampNum;
        private Label labelDurationNum;
        private Label labelDuration;
        private Label labelUsedColorsNum;
        private Label labelUsedColors;
        private ComboBox comboBoxDraws;
        private Label labelSimonTotal;
    }
}