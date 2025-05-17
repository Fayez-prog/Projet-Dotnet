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
    public partial class GestionMedecins : Form
    {
        private readonly IMedecinService _medecinService;
        private object? resultats;

        public GestionMedecins(IMedecinService medecinService)
        {
            InitializeComponent();
            _medecinService = medecinService;
        }

        private void GestionMedecins_Load(object sender, EventArgs e)
        {
            ChargerListeMedecins();
        }

        private void btnAjouMedecin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValiderChamps())
                    return;

                Medecin medecin = new Medecin
                {
                    CIN = txtCin.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    Nom = txtName.Text.Trim(),
                    DateNaissance = dtpDateNaissance.Value,
                    Adresse = txtAdresse.Text.Trim()
                };

                _medecinService.AjouterMedecin(medecin);
                ChargerListeMedecins();
                ViderChamps();

                MessageBox.Show("Médecin ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimerMedecin_Click(object sender, EventArgs e)
        {
            if (dgvMedecins.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un médecin à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int Id = Convert.ToInt32(dgvMedecins.SelectedRows[0].Cells["ID"].Value);

            DialogResult result = MessageBox.Show($"Voulez-vous vraiment supprimer le médecin {Id} ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _medecinService.SupprimerMedecin(Id);
                ChargerListeMedecins();
                MessageBox.Show("Médecin supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataGridView GetDgvMedecins()
        {
            return dgvMedecins;
        }

        private void btnAfficherTous_Click(object sender, EventArgs e)
        {
            ChargerListeMedecins();
        }

        private void btnModifierMedecin_Click(object sender, EventArgs e)
        {
            if (dgvMedecins.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un médecin à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ValiderChamps())
                    return;

                // Récupérer l'ID du medecin sélectionné
                int id = Convert.ToInt32(dgvMedecins.SelectedRows[0].Cells["ID"].Value);

                Medecin medecin = new Medecin
                {
                    Id = id,
                    CIN = txtCin.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    Nom = txtName.Text.Trim(),
                    DateNaissance = dtpDateNaissance.Value,
                    Adresse = txtAdresse.Text.Trim()
                };

                _medecinService.ModifierMedecin(medecin);
                ChargerListeMedecins();
                ViderChamps();

                MessageBox.Show("Médecin modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMedecins_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedecins.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMedecins.SelectedRows[0];
                txtCin.Text = row.Cells["CIN"].Value.ToString();
                txtPrenom.Text = row.Cells["Prenom"].Value.ToString();
                txtName.Text = row.Cells["Nom"].Value.ToString();
                dtpDateNaissance.Value = Convert.ToDateTime(row.Cells["DateNaissance"].Value);
                txtAdresse.Text = row.Cells["Adresse"].Value.ToString();
            }
        }

        private bool ValiderChamps()
        {
            if (string.IsNullOrWhiteSpace(txtCin.Text))
            {
                MessageBox.Show("Le CIN est obligatoire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

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

        private void ChargerListeMedecins()
        {
            dgvMedecins.DataSource = _medecinService.GetAllMedecins();
            dgvMedecins.ClearSelection();
        }

        private void ViderChamps()
        {
            txtCin.Clear();
            txtPrenom.Clear();
            txtName.Clear();
            txtAdresse.Clear();
            dtpDateNaissance.Value = DateTime.Today;
        }

        private void btnRechercheAdresse_Click(object sender, EventArgs e)
        {
            try
            {
                string adresse = txtAdresse.Text;

                if (string.IsNullOrWhiteSpace(adresse))
                {
                    MessageBox.Show("Veuillez entrer une adresse valide");
                    return;
                }

                var resultats = _medecinService.RechercherParAdresse(adresse).ToList();

                if (resultats.Count == 0)
                {
                    MessageBox.Show("Aucun médecin trouvé à cette adresse");
                }

                dgvMedecins.DataSource = resultats;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche : {ex.Message}");
            }
        }
    }
}
