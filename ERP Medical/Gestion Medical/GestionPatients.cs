using Gestion_Medical.Models;
using Gestion_Medical.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Gestion_Medical
{
    public partial class GestionPatients : Form
    {
        private readonly IPatientService _patientService;

        public GestionPatients(IPatientService patientService)
        {
            InitializeComponent();
            _patientService = patientService;
            InitializeComboBoxes();
            ConfigureDataGridViewColumns();
        }

        private void InitializeComboBoxes()
        {
            cbTypeCNAM.Items.AddRange(new string[] { "CNSS", "CNRPS", "Autre" });
            cbSexe.Items.AddRange(new string[] { "Homme", "Femme" });
        }

        private void ConfigureDataGridViewColumns()
        {
            dgvPatients.Columns.Clear();

            dgvPatients.Columns.Add("colCIN", "CIN");
            dgvPatients.Columns.Add("colNumCNAM", "Num CNAM");
            dgvPatients.Columns.Add("colTypeCNAM", "Type CNAM");
            dgvPatients.Columns.Add("colNom", "Nom");
            dgvPatients.Columns.Add("colPrenom", "Prénom");
            dgvPatients.Columns.Add("colSexe", "Sexe");
            dgvPatients.Columns.Add("colAge", "Age");
        }

        private void GestionPatients_Load(object sender, EventArgs e)
        {
            try
            {
                ActualiserDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des patients: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualiserDataGridView()
        {
            dgvPatients.Rows.Clear();
            var patients = _patientService.GetAllPatients();

            if (patients == null || !patients.Any())
            {
                dgvPatients.Rows.Add("Aucun patient trouvé");
                return;
            }

            foreach (Patient p in patients)
            {
                dgvPatients.Rows.Add(p.CIN, p.NumCNAM, p.TypeCNAM, p.Nom, p.Prenom, p.Sexe, p.Age);
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            if (!ValiderChamps())
            {
                MessageBox.Show("Tous les champs obligatoires doivent être remplis!", "Champs obligatoires",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValiderFormatCIN(txtCIN.Text))
            {
                MessageBox.Show("Le format du CIN est invalide (8 chiffres requis)", "Erreur de format",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Patient patient = new Patient
                {
                    CIN = txtCIN.Text.Trim(),
                    NumCNAM = txtNumCNAM.Text.Trim(),
                    TypeCNAM = cbTypeCNAM.SelectedItem.ToString(),
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    Sexe = cbSexe.SelectedItem.ToString(),
                    Age = Convert.ToInt32(numAge.Value)
                };

                _patientService.AddPatient(patient);
                ActualiserDataGridView();
                ViderChamps();
                MessageBox.Show("Patient ajouté avec succès!", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du patient: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderChamps()
        {
            return !string.IsNullOrWhiteSpace(txtCIN.Text) &&
                   !string.IsNullOrWhiteSpace(txtNumCNAM.Text) &&
                   !string.IsNullOrWhiteSpace(txtNom.Text) &&
                   !string.IsNullOrWhiteSpace(txtPrenom.Text) &&
                   cbTypeCNAM.SelectedItem != null &&
                   cbSexe.SelectedItem != null;
        }

        private bool ValiderFormatCIN(string cin)
        {
            // Validation simple - pourrait être améliorée selon les besoins
            return !string.IsNullOrWhiteSpace(cin) && cin.Length == 8 && cin.All(char.IsDigit);
        }

        private void ViderChamps()
        {
            txtCIN.Text = "";
            txtNumCNAM.Text = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            cbTypeCNAM.SelectedIndex = -1;
            cbSexe.SelectedIndex = -1;
            numAge.Value = 0;
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                string typeCNAM = cbTypeCNAM.SelectedItem?.ToString();
                string sexe = cbSexe.SelectedItem?.ToString();
                string nom = txtNom.Text.Trim();
                string prenom = txtPrenom.Text.Trim();

                if (string.IsNullOrEmpty(typeCNAM) && string.IsNullOrEmpty(sexe) &&
                    string.IsNullOrEmpty(nom) && string.IsNullOrEmpty(prenom))
                {
                    MessageBox.Show("Veuillez saisir au moins un critère de recherche!", "Recherche",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ActualiserDataGridView();
                    return;
                }

                dgvPatients.Rows.Clear();
                var patients = _patientService.GetAllPatients();
                var patientsFiltres = patients.Where(p =>
                    (string.IsNullOrEmpty(typeCNAM) || p.TypeCNAM.Equals(typeCNAM, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(sexe) || p.Sexe.Equals(sexe, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(nom) || p.Nom.Contains(nom, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(prenom) || p.Prenom.Contains(prenom, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                if (!patientsFiltres.Any())
                {
                    dgvPatients.Rows.Add("Aucun patient trouvé avec les critères spécifiés");
                    return;
                }

                foreach (Patient p in patientsFiltres)
                {
                    dgvPatients.Rows.Add(p.CIN, p.NumCNAM, p.TypeCNAM, p.Nom, p.Prenom, p.Sexe, p.Age);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ViderChamps();
            ActualiserDataGridView();
        }
    }
}
