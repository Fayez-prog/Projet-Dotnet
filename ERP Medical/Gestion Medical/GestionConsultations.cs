using Gestion_Medical.Models;
using Gestion_Medical.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Medical
{
    public partial class GestionConsultations : Form
    {
        private readonly IPatientService _patientService;
        private readonly IConsultationService _consultationService;
        private Patient patientSelectionne;

        public GestionConsultations(IPatientService patientService, IConsultationService consultationService)
        {
            InitializeComponent();
            _patientService = patientService;
            _consultationService = consultationService;
            InitialiserDataGridViews();
            ConfigurerControles();
            ConfigurerToolTips();
        }

        private void ConfigurerToolTips()
        {
            toolTip1.SetToolTip(cbPatients, "Sélectionnez un patient dans la liste");
            toolTip1.SetToolTip(txtSexe, "Sexe du patient");
            toolTip1.SetToolTip(txtAge, "Âge du patient");
            toolTip1.SetToolTip(txtDernierConsul, "Date de la dernière consultation");
            toolTip1.SetToolTip(dateConsultation, "Date de la consultation");
            toolTip1.SetToolTip(txtDiagnostique, "Diagnostic établi");
            toolTip1.SetToolTip(txtTraitement, "Traitement prescrit");
            toolTip1.SetToolTip(txtPrix, "Prix de la consultation (30.00 pour visite, 0.00 pour contrôle)");
            toolTip1.SetToolTip(rbVisite, "Type de consultation - Visite (30.00)");
            toolTip1.SetToolTip(rbControle, "Type de consultation - Contrôle (0.00)");
            toolTip1.SetToolTip(btnNouvelle, "Créer une nouvelle consultation");
            toolTip1.SetToolTip(btnModifier, "Modifier la consultation sélectionnée");
            toolTip1.SetToolTip(btnTotalJour, "Afficher le total des consultations du jour");
            toolTip1.SetToolTip(btnAnnuler, "Annuler les modifications en cours");
            toolTip1.SetToolTip(dgvConsultationsJour, "Liste des consultations");
            toolTip1.SetToolTip(dgvConsultationsPatient, "Historique des consultations du patient sélectionné");
            toolTip1.SetToolTip(dateTimePickerHistorique, "Sélectionnez une date pour afficher les consultations");
            toolTip1.SetToolTip(btnAfficherHistorique, "Afficher les consultations pour la date sélectionnée");
        }

        private void ConfigurerControles()
        {
            txtPrix.Enabled = false;
            txtPrix.Text = "0.00";

            dgvConsultationsJour.CellDoubleClick += DgvConsultationsJour_CellDoubleClick;
            dgvConsultationsPatient.CellDoubleClick += DgvConsultationsPatient_CellDoubleClick;

            dateConsultation.Format = DateTimePickerFormat.Custom;
            dateConsultation.CustomFormat = "dd/MM/yyyy HH:mm";
            dateConsultation.ShowUpDown = true;

            dateTimePickerHistorique.Format = DateTimePickerFormat.Short;
            dateTimePickerHistorique.ValueChanged += dateTimePickerHistorique_ValueChanged;
        }

        private void dateTimePickerHistorique_ValueChanged(object sender, EventArgs e)
        {
            AfficherConsultationsParDate(dateTimePickerHistorique.Value);
        }

        private void DgvConsultationsJour_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cellValue = dgvConsultationsJour.Rows[e.RowIndex].Cells["colPatient"].Value;
            if (cellValue == null) return;

            string patientInfo = cellValue.ToString();
            var parts = patientInfo.Split('(', ')');
            if (parts.Length < 2) return;

            var cnamParts = parts[1].Split(':');
            if (cnamParts.Length < 2) return;

            string numCNAM = cnamParts[1].Trim();
            patientSelectionne = _patientService.GetPatientByNumCNAM(numCNAM);
            if (patientSelectionne == null) return;

            for (int i = 0; i < cbPatients.Items.Count; i++)
            {
                if (cbPatients.Items[i].ToString().Contains(numCNAM))
                {
                    cbPatients.SelectedIndex = i;
                    break;
                }
            }

            btnModifier.Enabled = true;
            ChargerCreneauxDisponibles();
        }

        private void DgvConsultationsPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || patientSelectionne == null) return;

            var cellValue = dgvConsultationsPatient.Rows[e.RowIndex].Cells["colDate"].Value;
            if (cellValue == null) return;

            string dateStr = cellValue.ToString();
            if (DateTime.TryParseExact(dateStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                var consultation = _consultationService.GetConsultationsByPatientId(patientSelectionne.Id)
                    .FirstOrDefault(c => c.DateConsultation == date);

                if (consultation != null)
                {
                    dateConsultation.Value = consultation.DateConsultation;
                    txtDiagnostique.Text = consultation.Diagnostique;
                    txtTraitement.Text = consultation.Traitement;
                    rbVisite.Checked = consultation.EstVisite;
                    rbControle.Checked = !consultation.EstVisite;
                    txtPrix.Text = consultation.Prix.ToString("0.00");

                    btnModifier.Enabled = true;
                    btnNouvelle.Enabled = true;
                }
            }
        }

        private void InitialiserDataGridViews()
        {
            dgvConsultationsJour.Columns.Clear();
            dgvConsultationsJour.Columns.Add("colPatient", "Patient");
            dgvConsultationsJour.Columns.Add("colDate", "Date");
            dgvConsultationsJour.Columns.Add("colDiagnostic", "Diagnostic");
            dgvConsultationsJour.Columns.Add("colTraitement", "Traitement");
            dgvConsultationsJour.Columns.Add("colType", "Type");
            dgvConsultationsJour.Columns.Add("colPrix", "Prix");

            dgvConsultationsPatient.Columns.Clear();
            dgvConsultationsPatient.Columns.Add("colDate", "Date");
            dgvConsultationsPatient.Columns.Add("colDiagnostic", "Diagnostic");
            dgvConsultationsPatient.Columns.Add("colTraitement", "Traitement");
            dgvConsultationsPatient.Columns.Add("colType", "Type");
            dgvConsultationsPatient.Columns.Add("colPrix", "Prix");

            foreach (DataGridView dgv in new[] { dgvConsultationsJour, dgvConsultationsPatient })
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                dgv.BackgroundColor = SystemColors.Window;
                dgv.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void GestionConsultations_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerListePatients();
                dateTimePickerHistorique.Value = DateTime.Today;
                AfficherConsultationsParDate(DateTime.Today);
                dateConsultation.Value = DateTime.Today.AddHours(8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerListePatients()
        {
            cbPatients.Items.Clear();
            foreach (Patient p in _patientService.GetAllPatients().OrderBy(p => p.Nom))
            {
                cbPatients.Items.Add($"{p.Nom} {p.Prenom} ({p.TypeCNAM}:{p.NumCNAM})");
            }
        }

        private void AfficherConsultationsParDate(DateTime date)
        {
            try
            {
                dgvConsultationsJour.Rows.Clear();
                decimal total = 0;

                var consultations = _patientService.GetAllPatients()
                    .SelectMany(p => _consultationService.GetConsultationsByPatientId(p.Id))
                    .Where(c => c.DateConsultation.Date == date.Date)
                    .OrderBy(c => c.DateConsultation)
                    .ToList();

                foreach (Consultation c in consultations)
                {
                    var patient = _patientService.GetPatientById(c.PatientId);
                    string patientInfo = patient != null ? $"{patient.Nom} {patient.Prenom} ({patient.TypeCNAM}:{patient.NumCNAM})" : "Patient inconnu";

                    dgvConsultationsJour.Rows.Add(
                        patientInfo,
                        c.DateConsultation.ToString("dd/MM/yyyy HH:mm"),
                        c.Diagnostique,
                        c.Traitement,
                        c.EstVisite ? "Visite" : "Contrôle",
                        c.Prix.ToString("C"));

                    total += c.Prix;
                }

                lblTotalJour.Text = $"Total du {date.ToString("dd/MM/yyyy")}: {total.ToString("C")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage des consultations: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DateTime> GetAvailableTimeSlots(DateTime date)
        {
            var availableSlots = new List<DateTime>();
            var timeSlots = new[]
            {
                new { Start = date.Date.AddHours(8), End = date.Date.AddHours(12) },
                new { Start = date.Date.AddHours(14), End = date.Date.AddHours(17) }
            };

            var consultationsDuJour = _patientService.GetAllPatients()
                .SelectMany(p => _consultationService.GetConsultationsByPatientId(p.Id))
                .Where(c => c.DateConsultation.Date == date.Date)
                .ToList();

            foreach (var slot in timeSlots)
            {
                for (DateTime current = slot.Start; current < slot.End; current = current.AddMinutes(30))
                {
                    if (IsTimeSlotAvailable(current, consultationsDuJour))
                    {
                        availableSlots.Add(current);
                    }
                }
            }

            return availableSlots;
        }

        private bool IsTimeSlotAvailable(DateTime slot, List<Consultation> consultationsDuJour)
        {
            foreach (var consultation in consultationsDuJour)
            {
                DateTime consultationEnd = consultation.DateConsultation.AddMinutes(30);
                if (slot < consultationEnd && slot.AddMinutes(30) > consultation.DateConsultation)
                {
                    return false;
                }
            }
            return true;
        }

        private void ChargerCreneauxDisponibles()
        {
            try
            {
                var availableSlots = GetAvailableTimeSlots(dateConsultation.Value.Date);
                if (availableSlots.Count > 0 && !availableSlots.Contains(dateConsultation.Value))
                {
                    dateConsultation.Value = availableSlots.First();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des créneaux: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTotalJour_Click(object sender, EventArgs e)
        {
            try
            {
                AfficherConsultationsParDate(dateTimePickerHistorique.Value);

                if (dgvConsultationsJour.Rows.Count == 0)
                {
                    MessageBox.Show($"Aucune consultation le {dateTimePickerHistorique.Value.ToString("dd/MM/yyyy")}.",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du rafraîchissement: {ex.Message}", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherConsultationsPatient()
        {
            try
            {
                dgvConsultationsPatient.Rows.Clear();
                if (patientSelectionne == null) return;

                var consultations = _consultationService.GetConsultationsByPatientId(patientSelectionne.Id)
                    .OrderByDescending(c => c.DateConsultation);

                foreach (Consultation c in consultations)
                {
                    dgvConsultationsPatient.Rows.Add(
                        c.DateConsultation.ToString("dd/MM/yyyy HH:mm"),
                        c.Diagnostique,
                        c.Traitement,
                        c.EstVisite ? "Visite" : "Contrôle",
                        c.Prix.ToString("C"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage des consultations: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbPatients.SelectedIndex == -1) return;

                string selected = cbPatients.SelectedItem.ToString();
                var parts = selected.Split('(', ')');
                if (parts.Length < 2) return;

                var cnamParts = parts[1].Split(':');
                if (cnamParts.Length < 2) return;

                string numCNAM = cnamParts[1].Trim();
                patientSelectionne = _patientService.GetPatientByNumCNAM(numCNAM);
                if (patientSelectionne == null) return;

                txtSexe.Text = patientSelectionne.Sexe;
                txtAge.Text = patientSelectionne.Age.ToString();
                AfficherConsultationsPatient();
                AfficherDerniereConsultation();
                ChargerCreneauxDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection du patient: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherDerniereConsultation()
        {
            try
            {
                var derniere = _consultationService.GetConsultationsByPatientId(patientSelectionne.Id)
                    .OrderByDescending(c => c.DateConsultation)
                    .FirstOrDefault();

                if (derniere != null)
                {
                    txtDernierConsul.Text = derniere.DateConsultation.ToString("dd/MM/yyyy HH:mm");
                    dateConsultation.Value = derniere.DateConsultation;
                    txtDiagnostique.Text = derniere.Diagnostique;
                    txtTraitement.Text = derniere.Traitement;
                    rbVisite.Checked = derniere.EstVisite;
                    rbControle.Checked = !derniere.EstVisite;
                    txtPrix.Text = derniere.Prix.ToString("0.00");

                    btnModifier.Enabled = true;
                    btnNouvelle.Enabled = true;
                }
                else
                {
                    txtDernierConsul.Text = "Aucune consultation";
                    btnModifier.Enabled = false;
                    btnNouvelle.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de la dernière consultation: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNouvelle_Click(object sender, EventArgs e)
        {
            if (!ValiderChampsConsultation()) return;

            try
            {
                decimal prix = rbVisite.Checked ? 30.00m : 0.00m;

                var nouvelle = new Consultation
                {
                    DateConsultation = dateConsultation.Value,
                    Diagnostique = txtDiagnostique.Text,
                    Traitement = txtTraitement.Text,
                    EstVisite = rbVisite.Checked,
                    Prix = prix,
                    PatientId = patientSelectionne.Id
                };

                _consultationService.AddConsultation(nouvelle);
                AfficherConsultationsPatient();
                AfficherConsultationsParDate(dateTimePickerHistorique.Value);
                ChargerCreneauxDisponibles();
                ViderChampsConsultation();

                MessageBox.Show("Consultation ajoutée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (!ValiderChampsConsultation()) return;

            if (MessageBox.Show("Confirmer la modification?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                decimal prix = rbVisite.Checked ? 30.00m : 0.00m;

                var derniere = _consultationService.GetConsultationsByPatientId(patientSelectionne.Id)
                    .OrderByDescending(c => c.DateConsultation)
                    .FirstOrDefault();

                if (derniere != null)
                {
                    derniere.DateConsultation = dateConsultation.Value;
                    derniere.Diagnostique = txtDiagnostique.Text;
                    derniere.Traitement = txtTraitement.Text;
                    derniere.EstVisite = rbVisite.Checked;
                    derniere.Prix = prix;

                    _consultationService.UpdateConsultation(derniere);
                    AfficherConsultationsPatient();
                    AfficherConsultationsParDate(dateTimePickerHistorique.Value);
                    ChargerCreneauxDisponibles();
                    ViderChampsConsultation();

                    MessageBox.Show("Consultation modifiée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderChampsConsultation()
        {
            if (patientSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            TimeSpan heureDebut = dateConsultation.Value.TimeOfDay;
            TimeSpan heureFin = dateConsultation.Value.TimeOfDay.Add(TimeSpan.FromMinutes(30));

            bool isMorningSlot = (heureDebut >= new TimeSpan(8, 0, 0) && heureFin <= new TimeSpan(12, 0, 0));
            bool isAfternoonSlot = (heureDebut >= new TimeSpan(14, 0, 0) && heureFin <= new TimeSpan(17, 0, 0));

            if (!isMorningSlot && !isAfternoonSlot)
            {
                MessageBox.Show("Les consultations doivent être entre 8h-12h ou 14h-17h!", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var availableSlots = GetAvailableTimeSlots(dateConsultation.Value.Date);
            if (!availableSlots.Contains(dateConsultation.Value))
            {
                MessageBox.Show("Ce créneau horaire n'est plus disponible!", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiagnostique.Text))
            {
                MessageBox.Show("Le diagnostic est obligatoire!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnostique.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTraitement.Text))
            {
                MessageBox.Show("Le traitement est obligatoire!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTraitement.Focus();
                return false;
            }

            return true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            ViderChampsConsultation();
            ViderInfosPatient();
            if (patientSelectionne != null)
            {
                AfficherDerniereConsultation();
            }
        }

        private void rbVisite_CheckedChanged(object sender, EventArgs e)
        {
            txtPrix.Enabled = false;
            label8.Enabled = rbVisite.Checked;
            txtPrix.Text = rbVisite.Checked ? "30.00" : "0.00";
        }

        private void ViderChampsConsultation()
        {
            txtDiagnostique.Clear();
            txtTraitement.Clear();
            rbVisite.Checked = true;
            txtPrix.Text = "0.00";

            DateTime now = DateTime.Now;
            TimeSpan heureActuelle = now.TimeOfDay;
            DateTime nextSlot = now;

            int minutes = now.Minute;
            if (minutes >= 45)
            {
                nextSlot = now.AddHours(1).AddMinutes(-minutes);
            }
            else if (minutes >= 15)
            {
                nextSlot = now.AddMinutes(30 - minutes);
            }
            else
            {
                nextSlot = now.AddMinutes(-minutes);
            }

            if (nextSlot.TimeOfDay < new TimeSpan(8, 0, 0))
            {
                nextSlot = nextSlot.Date.AddHours(8);
            }
            else if (nextSlot.TimeOfDay >= new TimeSpan(12, 0, 0) && nextSlot.TimeOfDay < new TimeSpan(14, 0, 0))
            {
                nextSlot = nextSlot.Date.AddHours(14);
            }
            else if (nextSlot.TimeOfDay >= new TimeSpan(17, 0, 0))
            {
                nextSlot = nextSlot.AddDays(1).Date.AddHours(8);
            }

            dateConsultation.Value = nextSlot;
            ChargerCreneauxDisponibles();
        }

        private void ViderInfosPatient()
        {
            txtSexe.Clear();
            txtAge.Clear();
            txtDernierConsul.Clear();
            cbPatients.SelectedIndex = -1;
            dgvConsultationsPatient.Rows.Clear();
            patientSelectionne = null;
        }

        private void dateConsultation_ValueChanged(object sender, EventArgs e)
        {
            if (patientSelectionne != null)
            {
                var availableSlots = GetAvailableTimeSlots(dateConsultation.Value.Date);
                if (!availableSlots.Contains(dateConsultation.Value))
                {
                    MessageBox.Show("Ce créneau horaire n'est pas disponible. Veuillez en choisir un autre.", "Créneau indisponible",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    DateTime nextAvailable = availableSlots.FirstOrDefault(s => s >= dateConsultation.Value);

                    if (nextAvailable == default(DateTime))
                    {
                        nextAvailable = availableSlots.Last();
                    }

                    dateConsultation.Value = nextAvailable;
                }
            }
        }

        private void btnAfficherHistorique_Click(object sender, EventArgs e)
        {
            AfficherConsultationsParDate(dateTimePickerHistorique.Value);
        }
    }
}
