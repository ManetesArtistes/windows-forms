namespace WinFormsMA
{
    partial class EditCenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCenter));
            buttonCancel = new Button();
            buttonAccept = new Button();
            textBoxEditCenter = new TextBox();
            labelEditCenter = new Label();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Comic Sans MS", 15F);
            buttonCancel.Location = new Point(326, 251);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(183, 56);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonAccept
            // 
            buttonAccept.Font = new Font("Comic Sans MS", 15F);
            buttonAccept.Location = new Point(76, 251);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(183, 56);
            buttonAccept.TabIndex = 12;
            buttonAccept.Text = "ACEPTAR";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // textBoxEditCenter
            // 
            textBoxEditCenter.Font = new Font("Comic Sans MS", 18F);
            textBoxEditCenter.Location = new Point(45, 146);
            textBoxEditCenter.Name = "textBoxEditCenter";
            textBoxEditCenter.PlaceholderText = "Editar centre";
            textBoxEditCenter.Size = new Size(492, 41);
            textBoxEditCenter.TabIndex = 11;
            textBoxEditCenter.TextAlign = HorizontalAlignment.Center;
            // 
            // labelEditCenter
            // 
            labelEditCenter.AutoSize = true;
            labelEditCenter.BackColor = Color.Transparent;
            labelEditCenter.Font = new Font("Comic Sans MS", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEditCenter.ForeColor = SystemColors.Window;
            labelEditCenter.Location = new Point(140, 33);
            labelEditCenter.Name = "labelEditCenter";
            labelEditCenter.Size = new Size(349, 67);
            labelEditCenter.TabIndex = 10;
            labelEditCenter.Text = "Editar Centre";
            // 
            // EditCenter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.wood_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(582, 340);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAccept);
            Controls.Add(textBoxEditCenter);
            Controls.Add(labelEditCenter);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditCenter";
            Text = "Editar Centre";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonAccept;
        private TextBox textBoxEditCenter;
        private Label labelEditCenter;
    }
}