using WinFormsMA.Logic;

namespace WinFormsMA
{
    public partial class Stats : BaseForm
    {
        private List<JsonBase.Center> centers;

        public Stats()
        {
            InitializeComponent();
            LoadCenters();
        }

        public Stats(List<JsonBase.Center> centers)
        {
            InitializeComponent();
            this.centers = centers;  // En aquest cas, només inicialitzem amb centres passats
            LoadCenters();
        }

        // Càrrega dels centres des del servidor FTP
        private void LoadCenters()
        {
            try
            {
                var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();
                Ftp ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);
                centers = ftpClient.GetCenters();

                if (centers == null || centers.Count == 0)
                {
                    MessageBox.Show("No s'han trobat centres al servidor FTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ClearComboBox(comboBoxCenter);

                foreach (var center in centers)
                {
                    comboBoxCenter.Items.Add(center.CenterName);
                }

                if (comboBoxCenter.Items.Count > 0)
                {
                    comboBoxCenter.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No s'han trobat centres disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error carregant els centres des del servidor FTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                centers = new List<JsonBase.Center>(); // Llista buida per evitar errors
            }
        }

        // Càrrega de classes associades al centre seleccionat
        private void LoadClasses(JsonBase.Center selectedCenter)
        {
            ClearComboBox(comboBoxClass);

            if (selectedCenter?.Groups != null)
            {
                comboBoxClass.Enabled = true;

                foreach (var group in selectedCenter.Groups)
                {
                    comboBoxClass.Items.Add(group.GroupName);
                }

                if (comboBoxClass.Items.Count > 0)
                {
                    comboBoxClass.SelectedIndex = 0;
                }
            }
            else
            {
                comboBoxClass.Enabled = false;
            }
        }

        // Càrrega d'estudiants per classe seleccionada
        private void LoadStudents(JsonBase.Center selectedCenter, string selectedClassName)
        {
            ClearComboBox(comboBoxStudent);

            var selectedGroup = selectedCenter?.Groups?.FirstOrDefault(group => group.GroupName == selectedClassName);

            if (selectedGroup?.Students != null)
            {
                foreach (var student in selectedGroup.Students)
                {
                    if (!string.IsNullOrEmpty(student?.StudentName))
                    {
                        comboBoxStudent.Items.Add(student.StudentName);
                    }
                }

                if (comboBoxStudent.Items.Count > 0)
                {
                    comboBoxStudent.SelectedIndex = 0;
                }
            }
        }

        // Netejar un ComboBox
        private void ClearComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(""); // Element buit inicial
            comboBox.SelectedIndex = 0;
        }

        // Gestió de la selecció del centre
        private void comboBoxCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCenter.SelectedIndex == 0)
            {
                ClearComboBox(comboBoxClass);
                comboBoxClass.Enabled = false;
                buttonClass.Enabled = false;
                buttonEditClass.Enabled = false;
            }
            else
            {
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                var selectedCenter = centers.FirstOrDefault(center => center.CenterName == selectedCenterName);

                if (selectedCenter != null)
                {
                    LoadClasses(selectedCenter);
                    comboBoxClass.Enabled = true;
                    buttonClass.Enabled = true;
                    buttonEditClass.Enabled = true;
                }
            }
        }

        // Gestió de la selecció de la classe
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClass.SelectedIndex == 0)
            {
                ClearComboBox(comboBoxStudent);
                comboBoxStudent.Enabled = false;
            }
            else
            {
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                var selectedCenter = centers.FirstOrDefault(center => center.CenterName == selectedCenterName);
                string selectedClassName = comboBoxClass.SelectedItem.ToString();

                if (selectedCenter != null)
                {
                    LoadStudents(selectedCenter, selectedClassName);
                    comboBoxStudent.Enabled = true;
                }
            }
        }

        // Botó per anar a la pàgina de login
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        // Crear un nou centre
        private void buttonCentre_Click(object sender, EventArgs e)
        {
            var newCenterForm = new NewCenter(centers);

            if (newCenterForm.ShowDialog() == DialogResult.OK)
            {
                LoadCenters();
            }
        }

        // Crear una nova classe
        private void buttonClass_Click(object sender, EventArgs e)
        {
            var selectedCenter = centers.FirstOrDefault(center => center.CenterName == comboBoxCenter.SelectedItem.ToString());

            if (selectedCenter != null)
            {
                this.Hide();
                var newClassForm = new NewClass(centers, selectedCenter);
                newClassForm.Show();
            }
        }

        // Editar un centre existent
        private void buttonEditCenter_Click(object sender, EventArgs e)
        {
            string selectedCenterName = comboBoxCenter.Text;
            var selectedCenter = centers.FirstOrDefault(center => center.CenterName == selectedCenterName);

            if (selectedCenter != null)
            {
                var editCenterForm = new EditCenter(centers, selectedCenter);

                if (editCenterForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCenters();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un centre per modificar.");
            }
        }

        // Editar una classe existent
        private void buttonEditClass_Click(object sender, EventArgs e)
        {
            var selectedCenter = centers.FirstOrDefault(center => center.CenterName == comboBoxCenter.SelectedItem.ToString());
            var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.GroupName == comboBoxClass.SelectedItem.ToString());

            if (selectedGroup != null)
            {
                this.Hide();
                var editClassForm = new EditClass(centers, selectedGroup, selectedCenter);
                editClassForm.Show();
            }
            else
            {
                MessageBox.Show("Selecciona una classe per modificar.");
            }
        }
    }
}