﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMA
{
    public partial class EditJson : Form
    {
        public string JsonMod { get; set; }
        public EditJson(string jsonStudent)
        {
            InitializeComponent();
            textBoxJson.Text = jsonStudent;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            JsonMod = textBoxJson.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
