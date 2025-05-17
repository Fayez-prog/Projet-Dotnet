namespace Gestion_Medical
{
    partial class GestionConsultations
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            groupBox1 = new GroupBox();
            cbPatients = new ComboBox();
            txtSexe = new TextBox();
            txtAge = new TextBox();
            txtDernierConsul = new TextBox();
            groupBox2 = new GroupBox();
            btnAfficherHistorique = new Button();
            rbControle = new RadioButton();
            rbVisite = new RadioButton();
            dateConsultation = new DateTimePicker();
            txtDiagnostique = new TextBox();
            txtTraitement = new TextBox();
            txtPrix = new TextBox();
            groupBox3 = new GroupBox();
            btnAnnuler = new Button();
            btnTotalJour = new Button();
            btnModifier = new Button();
            btnNouvelle = new Button();
            groupBox4 = new GroupBox();
            dateTimePickerHistorique = new DateTimePicker();
            dgvConsultationsJour = new DataGridView();
            lblTotalJour = new Label();
            dgvConsultationsPatient = new DataGridView();
            toolTip1 = new ToolTip(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsultationsJour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvConsultationsPatient).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Patient :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 60);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Sexe :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 90);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 2;
            label3.Text = "Âge :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 120);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 15);
            label4.TabIndex = 3;
            label4.Text = "Dernière consultation :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 25);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 4;
            label5.Text = "Date :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 55);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 5;
            label6.Text = "Diagnostic :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 115);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 6;
            label7.Text = "Traitement :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 175);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 7;
            label8.Text = "Prix :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbPatients);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSexe);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtAge);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDernierConsul);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(14, 14);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(350, 162);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informations patient";
            // 
            // cbPatients
            // 
            cbPatients.FormattingEnabled = true;
            cbPatients.Location = new Point(149, 25);
            cbPatients.Margin = new Padding(4, 3, 4, 3);
            cbPatients.Name = "cbPatients";
            cbPatients.Size = new Size(193, 23);
            cbPatients.TabIndex = 0;
            cbPatients.SelectedIndexChanged += cbPatients_SelectedIndexChanged;
            // 
            // txtSexe
            // 
            txtSexe.Location = new Point(149, 57);
            txtSexe.Margin = new Padding(4, 3, 4, 3);
            txtSexe.Name = "txtSexe";
            txtSexe.ReadOnly = true;
            txtSexe.Size = new Size(193, 23);
            txtSexe.TabIndex = 1;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(149, 87);
            txtAge.Margin = new Padding(4, 3, 4, 3);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(193, 23);
            txtAge.TabIndex = 2;
            // 
            // txtDernierConsul
            // 
            txtDernierConsul.Location = new Point(149, 117);
            txtDernierConsul.Margin = new Padding(4, 3, 4, 3);
            txtDernierConsul.Name = "txtDernierConsul";
            txtDernierConsul.ReadOnly = true;
            txtDernierConsul.Size = new Size(193, 23);
            txtDernierConsul.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAfficherHistorique);
            groupBox2.Controls.Add(rbControle);
            groupBox2.Controls.Add(rbVisite);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dateConsultation);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtDiagnostique);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtTraitement);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtPrix);
            groupBox2.Location = new Point(14, 182);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(350, 254);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nouvelle consultation";
            // 
            // btnAfficherHistorique
            // 
            btnAfficherHistorique.Cursor = Cursors.Hand;
            btnAfficherHistorique.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnAfficherHistorique.Image = Properties.Resources._72647;
            btnAfficherHistorique.ImageAlign = ContentAlignment.MiddleLeft;
            btnAfficherHistorique.Location = new Point(189, 202);
            btnAfficherHistorique.Margin = new Padding(4, 3, 4, 3);
            btnAfficherHistorique.Name = "btnAfficherHistorique";
            btnAfficherHistorique.Size = new Size(140, 40);
            btnAfficherHistorique.TabIndex = 4;
            btnAfficherHistorique.Text = "Afficher";
            btnAfficherHistorique.TextAlign = ContentAlignment.MiddleRight;
            btnAfficherHistorique.UseVisualStyleBackColor = true;
            btnAfficherHistorique.Click += btnAfficherHistorique_Click;
            // 
            // rbControle
            // 
            rbControle.AutoSize = true;
            rbControle.Location = new Point(76, 202);
            rbControle.Margin = new Padding(4, 3, 4, 3);
            rbControle.Name = "rbControle";
            rbControle.Size = new Size(71, 19);
            rbControle.TabIndex = 6;
            rbControle.Text = "Contrôle";
            rbControle.UseVisualStyleBackColor = true;
            // 
            // rbVisite
            // 
            rbVisite.AutoSize = true;
            rbVisite.Checked = true;
            rbVisite.Location = new Point(10, 202);
            rbVisite.Margin = new Padding(4, 3, 4, 3);
            rbVisite.Name = "rbVisite";
            rbVisite.Size = new Size(53, 19);
            rbVisite.TabIndex = 5;
            rbVisite.TabStop = true;
            rbVisite.Text = "Visite";
            rbVisite.UseVisualStyleBackColor = true;
            rbVisite.CheckedChanged += rbVisite_CheckedChanged;
            // 
            // dateConsultation
            // 
            dateConsultation.CustomFormat = "dd/MM/yyyy HH:mm";
            dateConsultation.Format = DateTimePickerFormat.Custom;
            dateConsultation.Location = new Point(149, 22);
            dateConsultation.Margin = new Padding(4, 3, 4, 3);
            dateConsultation.Name = "dateConsultation";
            dateConsultation.ShowUpDown = true;
            dateConsultation.Size = new Size(193, 23);
            dateConsultation.TabIndex = 0;
            dateConsultation.ValueChanged += dateConsultation_ValueChanged;
            // 
            // txtDiagnostique
            // 
            txtDiagnostique.Location = new Point(149, 52);
            txtDiagnostique.Margin = new Padding(4, 3, 4, 3);
            txtDiagnostique.Multiline = true;
            txtDiagnostique.Name = "txtDiagnostique";
            txtDiagnostique.Size = new Size(193, 57);
            txtDiagnostique.TabIndex = 1;
            // 
            // txtTraitement
            // 
            txtTraitement.Location = new Point(149, 112);
            txtTraitement.Margin = new Padding(4, 3, 4, 3);
            txtTraitement.Multiline = true;
            txtTraitement.Name = "txtTraitement";
            txtTraitement.Size = new Size(193, 57);
            txtTraitement.TabIndex = 2;
            // 
            // txtPrix
            // 
            txtPrix.Enabled = false;
            txtPrix.Location = new Point(149, 172);
            txtPrix.Margin = new Padding(4, 3, 4, 3);
            txtPrix.Name = "txtPrix";
            txtPrix.Size = new Size(193, 23);
            txtPrix.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnAnnuler);
            groupBox3.Controls.Add(btnTotalJour);
            groupBox3.Controls.Add(btnModifier);
            groupBox3.Controls.Add(btnNouvelle);
            groupBox3.Location = new Point(14, 443);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(350, 115);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Actions";
            // 
            // btnAnnuler
            // 
            btnAnnuler.Cursor = Cursors.Hand;
            btnAnnuler.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnAnnuler.Image = Properties.Resources.annulled;
            btnAnnuler.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnnuler.Location = new Point(177, 63);
            btnAnnuler.Margin = new Padding(4, 3, 4, 3);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(163, 40);
            btnAnnuler.TabIndex = 3;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.TextAlign = ContentAlignment.MiddleRight;
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // btnTotalJour
            // 
            btnTotalJour.Cursor = Cursors.Hand;
            btnTotalJour.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnTotalJour.Image = Properties.Resources._10677592;
            btnTotalJour.ImageAlign = ContentAlignment.MiddleLeft;
            btnTotalJour.Location = new Point(7, 63);
            btnTotalJour.Margin = new Padding(4, 3, 4, 3);
            btnTotalJour.Name = "btnTotalJour";
            btnTotalJour.Size = new Size(163, 40);
            btnTotalJour.TabIndex = 2;
            btnTotalJour.Text = "Total Jour";
            btnTotalJour.TextAlign = ContentAlignment.MiddleRight;
            btnTotalJour.UseVisualStyleBackColor = true;
            btnTotalJour.Click += btnTotalJour_Click;
            // 
            // btnModifier
            // 
            btnModifier.Cursor = Cursors.Hand;
            btnModifier.Enabled = false;
            btnModifier.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnModifier.Image = Properties.Resources.compose;
            btnModifier.ImageAlign = ContentAlignment.MiddleLeft;
            btnModifier.Location = new Point(178, 22);
            btnModifier.Margin = new Padding(4, 3, 4, 3);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(162, 40);
            btnModifier.TabIndex = 1;
            btnModifier.Text = "Modifier";
            btnModifier.TextAlign = ContentAlignment.MiddleRight;
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnNouvelle
            // 
            btnNouvelle.Cursor = Cursors.Hand;
            btnNouvelle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnNouvelle.Image = Properties.Resources._new;
            btnNouvelle.ImageAlign = ContentAlignment.MiddleLeft;
            btnNouvelle.Location = new Point(7, 22);
            btnNouvelle.Margin = new Padding(4, 3, 4, 3);
            btnNouvelle.Name = "btnNouvelle";
            btnNouvelle.Size = new Size(163, 40);
            btnNouvelle.TabIndex = 0;
            btnNouvelle.Text = "Nouveau";
            btnNouvelle.TextAlign = ContentAlignment.MiddleRight;
            btnNouvelle.UseVisualStyleBackColor = true;
            btnNouvelle.Click += btnNouvelle_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dateTimePickerHistorique);
            groupBox4.Controls.Add(dgvConsultationsJour);
            groupBox4.Controls.Add(lblTotalJour);
            groupBox4.Controls.Add(dgvConsultationsPatient);
            groupBox4.Location = new Point(371, 14);
            groupBox4.Margin = new Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4, 3, 4, 3);
            groupBox4.Size = new Size(700, 545);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Consultations";
            // 
            // dateTimePickerHistorique
            // 
            dateTimePickerHistorique.Format = DateTimePickerFormat.Short;
            dateTimePickerHistorique.Location = new Point(7, 22);
            dateTimePickerHistorique.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerHistorique.Name = "dateTimePickerHistorique";
            dateTimePickerHistorique.Size = new Size(139, 23);
            dateTimePickerHistorique.TabIndex = 3;
            dateTimePickerHistorique.ValueChanged += dateTimePickerHistorique_ValueChanged;
            // 
            // dgvConsultationsJour
            // 
            dgvConsultationsJour.AllowUserToAddRows = false;
            dgvConsultationsJour.AllowUserToDeleteRows = false;
            dgvConsultationsJour.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultationsJour.Location = new Point(7, 52);
            dgvConsultationsJour.Margin = new Padding(4, 3, 4, 3);
            dgvConsultationsJour.Name = "dgvConsultationsJour";
            dgvConsultationsJour.ReadOnly = true;
            dgvConsultationsJour.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultationsJour.Size = new Size(686, 231);
            dgvConsultationsJour.TabIndex = 0;
            dgvConsultationsJour.CellDoubleClick += DgvConsultationsJour_CellDoubleClick;
            // 
            // lblTotalJour
            // 
            lblTotalJour.AutoSize = true;
            lblTotalJour.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalJour.Location = new Point(7, 286);
            lblTotalJour.Margin = new Padding(4, 0, 4, 0);
            lblTotalJour.Name = "lblTotalJour";
            lblTotalJour.Size = new Size(87, 13);
            lblTotalJour.TabIndex = 2;
            lblTotalJour.Text = "Total du jour :";
            // 
            // dgvConsultationsPatient
            // 
            dgvConsultationsPatient.AllowUserToAddRows = false;
            dgvConsultationsPatient.AllowUserToDeleteRows = false;
            dgvConsultationsPatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultationsPatient.Location = new Point(7, 307);
            dgvConsultationsPatient.Margin = new Padding(4, 3, 4, 3);
            dgvConsultationsPatient.Name = "dgvConsultationsPatient";
            dgvConsultationsPatient.ReadOnly = true;
            dgvConsultationsPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultationsPatient.Size = new Size(686, 231);
            dgvConsultationsPatient.TabIndex = 1;
            dgvConsultationsPatient.CellDoubleClick += DgvConsultationsPatient_CellDoubleClick;
            // 
            // GestionConsultations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 577);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "GestionConsultations";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des consultations";
            Load += GestionConsultations_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsultationsJour).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvConsultationsPatient).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPatients;
        private System.Windows.Forms.TextBox txtSexe;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtDernierConsul;
        private System.Windows.Forms.DateTimePicker dateConsultation;
        private System.Windows.Forms.TextBox txtDiagnostique;
        private System.Windows.Forms.TextBox txtTraitement;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.RadioButton rbVisite;
        private System.Windows.Forms.RadioButton rbControle;
        private System.Windows.Forms.Button btnNouvelle;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnTotalJour;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.DataGridView dgvConsultationsJour;
        private System.Windows.Forms.DataGridView dgvConsultationsPatient;
        private System.Windows.Forms.Label lblTotalJour;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker dateTimePickerHistorique;
        private System.Windows.Forms.Button btnAfficherHistorique;
        private System.Windows.Forms.Label label8;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
    }
}