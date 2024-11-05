namespace WinFormsMA
{
    partial class SelectAdminMode
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
            buttonLogs = new Button();
            buttonJson = new Button();
            buttonLeft = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonLogs
            // 
            buttonLogs.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLogs.Location = new Point(300, 298);
            buttonLogs.Name = "buttonLogs";
            buttonLogs.Size = new Size(254, 107);
            buttonLogs.TabIndex = 0;
            buttonLogs.Text = "Logs";
            buttonLogs.UseVisualStyleBackColor = true;
            buttonLogs.Click += buttonLogs_Click;
            // 
            // buttonJson
            // 
            buttonJson.Font = new Font("Segoe UI", 24F);
            buttonJson.Location = new Point(701, 298);
            buttonJson.Name = "buttonJson";
            buttonJson.Size = new Size(254, 107);
            buttonJson.TabIndex = 1;
            buttonJson.Text = "JSON";
            buttonJson.UseVisualStyleBackColor = true;
            buttonJson.Click += buttonJson_Click;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(66, 29);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 3;
            label1.Text = "Admin";
            // 
            // SelectAdminMode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_dark;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(label1);
            Controls.Add(buttonLeft);
            Controls.Add(buttonJson);
            Controls.Add(buttonLogs);
            DoubleBuffered = true;
            Name = "SelectAdminMode";
            Text = "SelectAdminMode";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLogs;
        private Button buttonJson;
        private Button buttonLeft;
        private Label label1;
    }
}