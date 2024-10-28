namespace WinFormsMA
{
    partial class NewCenter
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
            labelNewCenter = new Label();
            textBoxNewCenter = new TextBox();
            buttonAccept = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelNewCenter
            // 
            labelNewCenter.AutoSize = true;
            labelNewCenter.BackColor = Color.Transparent;
            labelNewCenter.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNewCenter.ForeColor = SystemColors.Window;
            labelNewCenter.Location = new Point(147, 22);
            labelNewCenter.Name = "labelNewCenter";
            labelNewCenter.Size = new Size(294, 67);
            labelNewCenter.TabIndex = 6;
            labelNewCenter.Text = "Nou Centre";
            // 
            // textBoxNewCenter
            // 
            textBoxNewCenter.Font = new Font("Comic Sans MS", 18F);
            textBoxNewCenter.Location = new Point(52, 135);
            textBoxNewCenter.Name = "textBoxNewCenter";
            textBoxNewCenter.PlaceholderText = "Nou centre";
            textBoxNewCenter.Size = new Size(492, 41);
            textBoxNewCenter.TabIndex = 7;
            textBoxNewCenter.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonAccept
            // 
            buttonAccept.Font = new Font("Comic Sans MS", 15F);
            buttonAccept.Location = new Point(83, 240);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(183, 56);
            buttonAccept.TabIndex = 8;
            buttonAccept.Text = "ACEPTAR";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Comic Sans MS", 15F);
            buttonCancel.Location = new Point(333, 240);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(183, 56);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // NewCenter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.wood_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(582, 340);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            Controls.Add(textBoxNewCenter);
            Controls.Add(labelNewCenter);
            Name = "NewCenter";
            Text = "Nou Centre";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNewCenter;
        private TextBox textBoxNewCenter;
        private Button buttonAccept;
        private Button buttonCancel;
    }
}