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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonManagement));
            buttonLeft = new Button();
            labelJson = new Label();
            labelCentre = new Label();
            comboBoxCenter = new ComboBox();
            comboBoxClass = new ComboBox();
            labelClass = new Label();
            dataGridViewJson = new DataGridView();
            StudentName = new DataGridViewTextBoxColumn();
            Importacio = new DataGridViewTextBoxColumn();
            buttonModify = new Button();
            buttonDelete = new Button();
            buttonImport = new Button();
            buttonExport = new Button();
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
            comboBoxCenter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCenter.Font = new Font("Comic Sans MS", 9F);
            comboBoxCenter.FormattingEnabled = true;
            comboBoxCenter.Location = new Point(197, 102);
            comboBoxCenter.Name = "comboBoxCenter";
            comboBoxCenter.Size = new Size(210, 25);
            comboBoxCenter.TabIndex = 3;
            comboBoxCenter.SelectedIndexChanged += comboBoxCenter_SelectedIndexChanged;
            // 
            // comboBoxClass
            // 
            comboBoxClass.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClass.Font = new Font("Comic Sans MS", 9F);
            comboBoxClass.FormattingEnabled = true;
            comboBoxClass.Location = new Point(570, 100);
            comboBoxClass.Name = "comboBoxClass";
            comboBoxClass.Size = new Size(210, 25);
            comboBoxClass.TabIndex = 5;
            comboBoxClass.SelectedIndexChanged += comboBoxClass_SelectedIndexChanged;
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
            // dataGridViewJson
            // 
            dataGridViewJson.AllowUserToAddRows = false;
            dataGridViewJson.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewJson.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewJson.Columns.AddRange(new DataGridViewColumn[] { StudentName, Importacio });
            dataGridViewJson.Location = new Point(102, 220);
            dataGridViewJson.Name = "dataGridViewJson";
            dataGridViewJson.ReadOnly = true;
            dataGridViewJson.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewJson.Size = new Size(1065, 424);
            dataGridViewJson.TabIndex = 8;
            // 
            // StudentName
            // 
            StudentName.HeaderText = "Estudiant";
            StudentName.Name = "StudentName";
            StudentName.ReadOnly = true;
            // 
            // Importacio
            // 
            Importacio.HeaderText = "Data importació";
            Importacio.Name = "Importacio";
            Importacio.ReadOnly = true;
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
            // buttonImport
            // 
            buttonImport.Location = new Point(958, 184);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(95, 30);
            buttonImport.TabIndex = 11;
            buttonImport.Text = "Importar JSON";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(1077, 184);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(90, 30);
            buttonExport.TabIndex = 12;
            buttonExport.Text = "Exportar JSON";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += button1_Click_1;
            // 
            // JsonManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_dark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(buttonExport);
            Controls.Add(buttonImport);
            Controls.Add(buttonDelete);
            Controls.Add(buttonModify);
            Controls.Add(dataGridViewJson);
            Controls.Add(comboBoxClass);
            Controls.Add(labelClass);
            Controls.Add(comboBoxCenter);
            Controls.Add(labelCentre);
            Controls.Add(labelJson);
            Controls.Add(buttonLeft);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private ComboBox comboBoxClass;
        private Label labelClass;
        private DataGridView dataGridViewJson;
        private Button buttonModify;
        private Button buttonDelete;
        private Button buttonImport;
        private Button buttonExport;
        private DataGridViewTextBoxColumn StudentName;
        private DataGridViewTextBoxColumn Importacio;
    }
}