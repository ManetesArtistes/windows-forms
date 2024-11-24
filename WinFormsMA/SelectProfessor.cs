using Serilog;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

namespace WinFormsMA
{
    public partial class SelectProfessor : BaseForm
    {
        private List<Center> centers;
        private JsonManager jsonManager;

        public SelectProfessor(JsonManager jsonManager)
        {
            InitializeComponent();
            this.jsonManager = jsonManager;

            try
            {
                centers = jsonManager.LoadCentersFromFtp("json/manetes_artistes.json");

                if (centers == null || centers.Count == 0) // Comprova si s'han carregat centres abans de continuar
                {
                    MessageBox.Show("No s'han trobat centres al fitxer JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadCenters(); // Carrega els centres al ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error carregant els centres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCenters()
        {
            try
            {
                if (centers == null || centers.Count == 0)
                {
                    MessageBox.Show("No s'han trobat centres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ClearComboBox(comboBoxCenter);

                foreach (var center in centers)
                {
                    comboBoxCenter.Items.Add(center.Name); // Afegeix el nom del centre al ComboBox
                }

                if (comboBoxCenter.Items.Count > 0)
                {
                    comboBoxCenter.SelectedIndex = 0;
                }
                else
                {
                    Log.Warning("No hi ha centres disponibles per carregar.");
                    MessageBox.Show("No s'han trobat centres disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error carregant els centres.");
                MessageBox.Show($"Error carregant els centres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                centers = new List<Center>(); // Llista buida per evitar errors
            }
        }

        private void LoadClasses(Center selectedCenter)
        {
            ClearComboBox(comboBoxClass);

            if (selectedCenter?.Groups != null)
            {
                comboBoxClass.Enabled = true;

                foreach (var group in selectedCenter.Groups)
                {
                    comboBoxClass.Items.Add(group.Name); // Afegeix el nom del grup al ComboBox
                }

                if (comboBoxClass.Items.Count > 0)
                {
                    comboBoxClass.SelectedIndex = 0;
                }

                Log.Information("S'han carregat {Count} classes per al centre {CenterName}.",
                    selectedCenter.Groups.Count, selectedCenter.Name);
            }
            else
            {
                Log.Warning("El centre {CenterName} no té classes.", selectedCenter.Name);
                comboBoxClass.Enabled = false;
            }
        }

        private void LoadStudents(Center selectedCenter, string selectedClassName)
        {
            ClearComboBox(comboBoxStudent);

            var selectedGroup = selectedCenter?.Groups?.FirstOrDefault(group => group.Name == selectedClassName); // `Name` en lloc de `GroupName`

            if (selectedGroup?.Students != null)
            {
                foreach (var student in selectedGroup.Students)
                {
                    if (!string.IsNullOrEmpty(student?.Name)) // `Name` en lloc de `StudentName`
                    {
                        comboBoxStudent.Items.Add(student.Name);
                    }
                }

                if (comboBoxStudent.Items.Count > 0)
                {
                    comboBoxStudent.SelectedIndex = 0;
                }
            }
        }

        private void ClearComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(""); // Element buit inicial
            comboBox.SelectedIndex = 0;
        }

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
                var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);

                if (selectedCenter != null)
                {
                    LoadClasses(selectedCenter);
                    comboBoxClass.Enabled = true;
                    buttonClass.Enabled = true;
                    buttonEditClass.Enabled = true;
                }
            }
        }

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
                var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);
                string selectedClassName = comboBoxClass.SelectedItem.ToString();

                if (selectedCenter != null)
                {
                    LoadStudents(selectedCenter, selectedClassName);
                    comboBoxStudent.Enabled = true;
                }
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void buttonCentre_Click(object sender, EventArgs e)
        {
            var newCenterForm = new NewCenter(jsonManager, centers);

            if (newCenterForm.ShowDialog() == DialogResult.OK)
            {
                Log.Information("S'ha creat un nou centre.");
                LoadCenters(); // Només refresquem els centres al ComboBox
            }
        }

        private void buttonEditCenter_Click(object sender, EventArgs e)
        {
            string selectedCenterName = comboBoxCenter.Text;
            var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);

            if (selectedCenter != null)
            {
                var editCenterForm = new EditCenter(jsonManager, centers, selectedCenter);

                if (editCenterForm.ShowDialog() == DialogResult.OK)
                {
                    Log.Information("S'ha editat el centre {CenterName}.", selectedCenter.Name);
                    LoadCenters(); // Només refresquem els centres al ComboBox
                }
            }
            else
            {
                Log.Warning("No s'ha seleccionat cap centre per editar.");
                MessageBox.Show("Selecciona un centre per modificar.", "Advertència", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClass_Click(object sender, EventArgs e)
        {
            var selectedCenter = centers.FirstOrDefault(center => center.Name == comboBoxCenter.SelectedItem.ToString());

            if (selectedCenter != null)
            {
                var newClassForm = new NewClass(centers, selectedCenter);

                if (newClassForm.ShowDialog() == DialogResult.OK)
                {
                    Log.Information("S'ha creat una nova classe per al centre {CenterName}.", selectedCenter.Name);
                    LoadClasses(selectedCenter); // Només refresquem els centres al ComboBox
                }
            }
            else
            {
                Log.Warning("No s'ha seleccionat cap centre per afegir una classe.");
            }
        }

        private void buttonEditClass_Click(object sender, EventArgs e)
        {
            var selectedCenter = centers.FirstOrDefault(center => center.Name == comboBoxCenter.SelectedItem.ToString());
            var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.Name == comboBoxClass.SelectedItem.ToString());

            if (selectedGroup != null)
            {
                var editClassForm = new EditClass(centers, selectedGroup, selectedCenter);

                if (editClassForm.ShowDialog() == DialogResult.OK)
                {
                    Log.Information("S'ha editat la classe {ClassName} del centre {CenterName}.", selectedGroup.Name, selectedCenter.Name);
                    LoadClasses(selectedCenter); // Només refresquem els centres al ComboBox
                }
            }
            else
            {
                Log.Warning("No s'ha seleccionat cap classe per editar.");
                MessageBox.Show("Selecciona una classe per modificar.", "Advertència", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {

        }
    }
}