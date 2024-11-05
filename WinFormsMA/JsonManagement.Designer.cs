namespace WinFormsMA
{
    partial class JsonManagement
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
            labelJson = new Label();
            labelCentre = new Label();
            comboBoxCenter = new ComboBox();
            comboBox1 = new ComboBox();
            labelClass = new Label();
            comboBox2 = new ComboBox();
            labelJoc = new Label();
            dataGridViewJson = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            buttonModify = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewJson).BeginInit();
            SuspendLayout();
            // 
            // buttonLeft
            // 
            buttonLeft.Location = new Point(22, 25);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(35, 35);
            buttonLeft.TabIndex = 0;
            buttonLeft.Text = "←";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += button1_Click;
            // 
            // labelJson
            // 
            labelJson.AutoSize = true;
            labelJson.BackColor = Color.Transparent;
            labelJson.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            labelJson.ForeColor = SystemColors.ControlLightLight;
            labelJson.Location = new Point(66, 29);
            labelJson.Name = "labelJson";
            labelJson.Size = new Size(60, 25);
            labelJson.TabIndex = 1;
            labelJson.Text = "JSON";
            // 
            // labelCentre
            // 
            labelCentre.AutoSize = true;
            labelCentre.BackColor = Color.Transparent;
            labelCentre.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelCentre.ForeColor = SystemColors.ControlLightLight;
            labelCentre.Location = new Point(102, 95);
            labelCentre.Name = "labelCentre";
            labelCentre.Size = new Size(89, 32);
            labelCentre.TabIndex = 2;
            labelCentre.Text = "Centre";
            // 
            // comboBoxCenter
            // 
            comboBoxCenter.FormattingEnabled = true;
            comboBoxCenter.Location = new Point(197, 102);
            comboBoxCenter.Name = "comboBoxCenter";
            comboBoxCenter.Size = new Size(210, 23);
            comboBoxCenter.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(570, 100);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(210, 23);
            comboBox1.TabIndex = 5;
            // 
            // labelClass
            // 
            labelClass.AutoSize = true;
            labelClass.BackColor = Color.Transparent;
            labelClass.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelClass.ForeColor = SystemColors.ControlLightLight;
            labelClass.Location = new Point(475, 93);
            labelClass.Name = "labelClass";
            labelClass.RightToLeft = RightToLeft.No;
            labelClass.Size = new Size(84, 32);
            labelClass.TabIndex = 4;
            labelClass.Text = "Classe";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(920, 98);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(210, 23);
            comboBox2.TabIndex = 7;
            // 
            // labelJoc
            // 
            labelJoc.AutoSize = true;
            labelJoc.BackColor = Color.Transparent;
            labelJoc.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelJoc.ForeColor = SystemColors.ControlLightLight;
            labelJoc.Location = new Point(862, 92);
            labelJoc.Name = "labelJoc";
            labelJoc.RightToLeft = RightToLeft.No;
            labelJoc.Size = new Size(52, 32);
            labelJoc.TabIndex = 6;
            labelJoc.Text = "Joc";
            // 
            // dataGridViewJson
            // 
            dataGridViewJson.AllowUserToAddRows = false;
            dataGridViewJson.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewJson.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewJson.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridViewJson.Location = new Point(102, 220);
            dataGridViewJson.Name = "dataGridViewJson";
            dataGridViewJson.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewJson.Size = new Size(1065, 424);
            dataGridViewJson.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.HeaderText = "Fitxer";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Data d'importació";
            Column2.Name = "Column2";
            // 
            // buttonModify
            // 
            buttonModify.Location = new Point(101, 176);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(90, 30);
            buttonModify.TabIndex = 9;
            buttonModify.Text = "Modificar";
            buttonModify.UseVisualStyleBackColor = true;
            buttonModify.Click += buttonModify_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(216, 176);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(90, 30);
            buttonDelete.TabIndex = 10;
            buttonDelete.Text = "Eliminar";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // JsonManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_dark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(buttonDelete);
            Controls.Add(buttonModify);
            Controls.Add(dataGridViewJson);
            Controls.Add(comboBox2);
            Controls.Add(labelJoc);
            Controls.Add(comboBox1);
            Controls.Add(labelClass);
            Controls.Add(comboBoxCenter);
            Controls.Add(labelCentre);
            Controls.Add(labelJson);
            Controls.Add(buttonLeft);
            DoubleBuffered = true;
            Name = "JsonManagement";
            Text = "JsonManagement";
            ((System.ComponentModel.ISupportInitialize)dataGridViewJson).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLeft;
        private Label labelJson;
        private Label labelCentre;
        private ComboBox comboBoxCenter;
        private ComboBox comboBox1;
        private Label labelClass;
        private ComboBox comboBox2;
        private Label labelJoc;
        private DataGridView dataGridViewJson;
        private Button buttonModify;
        private Button buttonDelete;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}