using Gestion_de_cabinet_médical.Models;
using Gestion_de_cabinet_médical.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_cabinet_médical
{
    public partial class GestionPatients : Form
    {
        private readonly IPatientService _patientService;
        private object? resultats;
        public GestionPatients(IPatientService patientService)
        {
            InitializeComponent();
            _patientService = patientService;
        }

        private void GestionPatients_Load(object sender, EventArgs e)
        {
            ChargerListePatients();
        }

        private void btnAjouPatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValiderChamps())
                    return;

                Patient patient = new Patient
                {
                    Prenom = txtPrenom.Text.Trim(),
                    Nom = txtName.Text.Trim(),
                    DateNaissance = dtpDateNaissance.Value,
                    Telephone = txtTelephone.Text.Trim()
                };

                _patientService.AjouterPatient(patient);
                ChargerListePatients();
                ViderChamps();

                MessageBox.Show("Patient ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errorDetails = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Erreur lors de l'ajout : {errorDetails}",
                              "Erreur",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void btnSupprimerPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un patient à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int Id = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["ID"].Value);

            DialogResult result = MessageBox.Show($"Voulez-vous vraiment supprimer le patient {Id} ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _patientService.SupprimerPatient(Id);
                ChargerListePatients();
                MessageBox.Show("Médecin supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataGridView GetDgvPatients()
        {
            return dgvPatients;
        }

        private void btnAfficherTous_Click(object sender, EventArgs e)
        {
            ChargerListePatients();
        }

        private void btnModifierPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un patient à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ValiderChamps())
                    return;

                // Récupérer l'ID du patient sélectionné
                int id = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["ID"].Value);

                // Créer un patient avec les nouvelles valeurs
                Patient patientModifie = new Patient
                {
                    Id = id,
                    Prenom = txtPrenom.Text.Trim(),
                    Nom = txtName.Text.Trim(),
                    DateNaissance = dtpDateNaissance.Value,
                    Telephone = txtTelephone.Text.Trim()
                };

                // Appeler le service de modification
                _patientService.ModifierPatient(patientModifie);

                ChargerListePatients();
                ViderChamps();

                MessageBox.Show("Patient modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errorDetails = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Erreur lors de la modification : {errorDetails}",
                               "Erreur",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void dgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPatients.SelectedRows[0];
                txtPrenom.Text = row.Cells["Prenom"].Value.ToString();
                txtName.Text = row.Cells["Nom"].Value.ToString();
                dtpDateNaissance.Value = Convert.ToDateTime(row.Cells["DateNaissance"].Value);
                txtTelephone.Text = row.Cells["Telephone"].Value.ToString();
            }
        }

        private bool ValiderChamps()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Le nom est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Le prénom est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDateNaissance.Value > DateTime.Now)
            {
                MessageBox.Show("La date de naissance ne peut pas être dans le futur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ChargerListePatients()
        {
            dgvPatients.DataSource = _patientService.GetAllPatients();
            dgvPatients.ClearSelection();
        }

        private void ViderChamps()
        {
            txtPrenom.Clear();
            txtName.Clear();
            txtTelephone.Clear();
            dtpDateNaissance.Value = DateTime.Today;
        }

        private void btnRechercheNom_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtName.Text.Trim();

                if (string.IsNullOrWhiteSpace(nom))
                {
                    MessageBox.Show("Veuillez entrer un nom valide", "Erreur",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultats = _patientService.RechercherParNom(nom);

                dgvPatients.DataSource = resultats; // Mettre à jour la DataGridView dans tous les cas

                if (!resultats.Any()) // Meilleure pratique que .Count == 0
                {
                    MessageBox.Show("Aucun patient trouvé avec ce nom", "Information",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ne pas mettre de return ici pour permettre l'affichage de la grid vide
                }
            }
            catch (Exception ex)
            {
                string errorDetails = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Erreur lors de la recherche : {errorDetails}",
                              "Erreur",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);

                // Réafficher tous les patients en cas d'erreur
                ChargerListePatients();
            }
        }
    }
}
