namespace WinFormsMA
{
    public partial class EditJson : Form
    {
        public string JsonMod { get; set; }

        /// <summary>
        /// This method starts the form and shows the json of the student selected
        /// 
        /// </summary>
        /// <param name="jsonStudent"></param>
        public EditJson(string jsonStudent)
        {
            InitializeComponent();
            textBoxJson.Text = jsonStudent;
        }


        /// <summary>
        /// This method saves the changes made to the student json
        /// and closes the form
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            JsonMod = textBoxJson.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// This method closes the form withous save the changes
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}