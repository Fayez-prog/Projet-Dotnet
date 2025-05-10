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
    public partial class GestionRendezVous : Form
    {
        private readonly IRendezVousService _rendezVousService;
        private readonly CabinetContext _context;

        public GestionRendezVous(IRendezVousService rendezVousService)
        {
            InitializeComponent();
            _rendezVousService = rendezVousService;
            _context = new CabinetContext();
            this.Load += GestionRendezVous_Load;
        }

        private void GestionRendezVous_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerDonnees();
                ConfigurerDataGridView();
                ChargerTousLesRendezVous();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerDonnees()
        {
            comboBoxMedecin.DataSource = _context.Medecins.ToList();
            comboBoxMedecin.DisplayMember = "NomComplet";
            comboBoxMedecin.ValueMember = "Id";

            comboBoxPatient.DataSource = _context.Patients.ToList();
            comboBoxPatient.DisplayMember = "NomComplet";
            comboBoxPatient.ValueMember = "Id";

            dateTimePickerDate.MinDate = DateTime.Today;
            dateTimePickerDate.Value = DateTime.Today;
            dateTimePickerHeure.Value = DateTime.Today.AddHours(8).AddMinutes(0);
        }

        private void ConfigurerDataGridView()
        {
            dataGridViewRendezVous.AutoGenerateColumns = false;
            dataGridViewRendezVous.Columns.Clear();

            var columns = new[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "Id", Visible = false },
                new DataGridViewTextBoxColumn { DataPropertyName = "DateHeure", HeaderText = "Date et Heure", Name = "DateHeure" },
                new DataGridViewTextBoxColumn { DataPropertyName = "MedecinNomComplet", HeaderText = "Médecin", Name = "Medecin" },
                new DataGridViewTextBoxColumn { DataPropertyName = "PatientNomComplet", HeaderText = "Patient", Name = "Patient" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Statut", HeaderText = "Statut", Name = "Statut" }
            };

            dataGridViewRendezVous.Columns.AddRange(columns);
            dataGridViewRendezVous.SelectionChanged += DataGridViewRendezVous_SelectionChanged;
        }

        private void ChargerTousLesRendezVous()
        {
            try
            {
                var rendezVous = _rendezVousService.GetAllRendezVous()
                         .OrderBy(r => r.DateHeure)
                         .Select(r => new
                {
                    r.Id,
                    DateHeure = r.DateHeure.ToString("g"),
                    MedecinNomComplet = r.Medecin != null ? $"{r.Medecin.Nom} {r.Medecin.Prenom}" : "Médecin inconnu",
                    PatientNomComplet = r.Patient != null ? $"{r.Patient.Nom} {r.Patient.Prenom}" : "Patient inconnu",
                    Statut = r.DateHeure < DateTime.Now ? "Terminé" : "À venir",
                    RendezVous = r
                })
                .ToList();

                dataGridViewRendezVous.DataSource = rendezVous;
                dataGridViewRendezVous.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des rendez-vous : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!ValiderChamps()) return;

            try
            {
                var dateHeure = CombineDateAndTime(dateTimePickerDate.Value, dateTimePickerHeure.Value);
                var medecin = (Medecin)comboBoxMedecin.SelectedItem;
                var patient = (Patient)comboBoxPatient.SelectedItem;

                if (!_rendezVousService.VerifierDisponibilite(dateHeure, medecin.Id))
                {
                    MessageBox.Show("Le médecin a déjà un rendez-vous à cette heure.", "Conflit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var rendezVous = new RendezVous
                {
                    DateHeure = dateHeure,
                    MedecinId = medecin.Id,
                    PatientId = patient.Id
                };

                _rendezVousService.AjouterRendezVous(rendezVous);
                ChargerTousLesRendezVous();
                ReinitialiserChamps();

                MessageBox.Show("Rendez-vous ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridViewRendezVous.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un rendez-vous.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValiderChamps()) return;

            try
            {
                var id = (int)dataGridViewRendezVous.SelectedRows[0].Cells["Id"].Value;
                var rendezVous = _rendezVousService.GetRendezVousById(id);

                if (rendezVous == null)
                {
                    MessageBox.Show("Rendez-vous introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dateHeure = CombineDateAndTime(dateTimePickerDate.Value, dateTimePickerHeure.Value);
                var medecin = (Medecin)comboBoxMedecin.SelectedItem;

                // Vérifier conflit seulement si date/heure ou médecin a changé
                if (rendezVous.DateHeure != dateHeure || rendezVous.MedecinId != medecin.Id)
                {
                    if (!_rendezVousService.VerifierDisponibilite(dateHeure, medecin.Id))
                    {
                        MessageBox.Show("Le médecin a déjà un rendez-vous à cette heure.", "Conflit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                rendezVous.DateHeure = dateHeure;
                rendezVous.MedecinId = medecin.Id;
                rendezVous.PatientId = ((Patient)comboBoxPatient.SelectedItem).Id;

                _rendezVousService.ModifierRendezVous(rendezVous);
                ChargerTousLesRendezVous();

                MessageBox.Show("Rendez-vous modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridViewRendezVous.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un rendez-vous.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmation = MessageBox.Show("Confirmez-vous la suppression de ce rendez-vous ?",
                                            "Confirmation",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes) return;

            try
            {
                var id = (int)dataGridViewRendezVous.SelectedRows[0].Cells["Id"].Value;
                _rendezVousService.SupprimerRendezVous(id);
                ChargerTousLesRendezVous();
                ReinitialiserChamps();

                MessageBox.Show("Rendez-vous supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewRendezVous_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRendezVous.SelectedRows.Count > 0)
            {
                var id = (int)dataGridViewRendezVous.SelectedRows[0].Cells["Id"].Value;
                var rendezVous = _rendezVousService.GetRendezVousById(id);

                if (rendezVous != null)
                {
                    dateTimePickerDate.Value = rendezVous.DateHeure.Date;
                    dateTimePickerHeure.Value = new DateTime(2000, 1, 1,
                                                          rendezVous.DateHeure.Hour,
                                                          rendezVous.DateHeure.Minute,
                                                          0);
                    comboBoxMedecin.SelectedValue = rendezVous.MedecinId;
                    comboBoxPatient.SelectedValue = rendezVous.PatientId;
                }
            }
        }

        private bool ValiderChamps()
        {
            if (comboBoxMedecin.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un médecin.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxPatient.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dateTimePickerDate.Value < DateTime.Today)
            {
                MessageBox.Show("La date ne peut pas être dans le passé.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private DateTime CombineDateAndTime(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
        }

        private void ReinitialiserChamps()
        {
            dateTimePickerDate.Value = DateTime.Today;
            dateTimePickerHeure.Value = DateTime.Today.AddHours(8);
            comboBoxMedecin.SelectedIndex = -1;
            comboBoxPatient.SelectedIndex = -1;
            dataGridViewRendezVous.ClearSelection();
        }

        private void btnRechercherMedecin_Click(object sender, EventArgs e)
        {
            if (comboBoxMedecin.SelectedItem == null) return;

            var medecinId = ((Medecin)comboBoxMedecin.SelectedItem).Id;
            AfficherRendezVous(_rendezVousService.GetRendezVousByMedecin(medecinId));
        }

        private void btnRechercherPatient_Click(object sender, EventArgs e)
        {
            if (comboBoxPatient.SelectedItem == null) return;

            var patientId = ((Patient)comboBoxPatient.SelectedItem).Id;
            AfficherRendezVous(_rendezVousService.GetRendezVousByPatient(patientId));
        }

        private void btnRechercherDate_Click(object sender, EventArgs e)
        {
            AfficherRendezVous(_rendezVousService.GetRendezVousByDate(dateTimePickerDate.Value));
        }

        private void AfficherRendezVous(IEnumerable<RendezVous> rendezVous)
        {
            dataGridViewRendezVous.DataSource = rendezVous
                .OrderBy(r => r.DateHeure)
                .Select(r => new
                {
                    r.Id,
                    DateHeure = r.DateHeure.ToString("g"),
                    MedecinNomComplet = $"{r.Medecin.Nom} {r.Medecin.Prenom}",
                    PatientNomComplet = $"{r.Patient.Nom} {r.Patient.Prenom}",
                    Statut = r.DateHeure < DateTime.Now ? "Terminé" : "À venir"
                })
                .ToList();
        }

        private void btnAfficherTous_Click(object sender, EventArgs e)
        {
            ChargerTousLesRendezVous();
            ReinitialiserChamps();
        }
    }
}
