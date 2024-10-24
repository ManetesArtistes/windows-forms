namespace WinFormsMA
{
    partial class Logs
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
            labelLogs = new Label();
            dataGridViewLogs = new DataGridView();
            buttonLeft = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLogs).BeginInit();
            SuspendLayout();
            // 
            // labelLogs
            // 
            labelLogs.AutoSize = true;
            labelLogs.BackColor = Color.Transparent;
            labelLogs.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogs.ForeColor = SystemColors.ControlLightLight;
            labelLogs.Location = new Point(66, 29);
            labelLogs.Name = "labelLogs";
            labelLogs.Size = new Size(54, 25);
            labelLogs.TabIndex = 0;
            labelLogs.Text = "Logs";
            // 
            // dataGridViewLogs
            // 
            dataGridViewLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLogs.Location = new Point(22, 81);
            dataGridViewLogs.Name = "dataGridViewLogs";
            dataGridViewLogs.Size = new Size(1222, 574);
            dataGridViewLogs.TabIndex = 1;
            // 
            // buttonLeft
            // 
            buttonLeft.Location = new Point(22, 25);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(35, 35);
            buttonLeft.TabIndex = 2;
            buttonLeft.Text = "←";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // Logs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(buttonLeft);
            Controls.Add(dataGridViewLogs);
            Controls.Add(labelLogs);
            Name = "Logs";
            Text = "Logs";
            ((System.ComponentModel.ISupportInitialize)dataGridViewLogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogs;
        private DataGridView dataGridViewLogs;
        private Button buttonLeft;
    }
}