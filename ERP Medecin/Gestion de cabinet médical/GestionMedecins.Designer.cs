namespace Gestion_de_cabinet_médical
{
    partial class GestionMedecins
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvMedecins = new DataGridView();
            groupBox1 = new GroupBox();
            btnAfficherTous = new Button();
            btnRechercheAdresse = new Button();
            btnSupprimerMedecin = new Button();
            btnModifierMedecin = new Button();
            btnAjouMedecin = new Button();
            groupBox2 = new GroupBox();
            txtAdresse = new TextBox();
            lblAdresse = new Label();
            dtpDateNaissance = new DateTimePicker();
            lblDate = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblPrenom = new Label();
            txtPrenom = new TextBox();
            txtCin = new TextBox();
            lblCin = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvMedecins).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // dgvMedecins
            // 
            dgvMedecins.AllowUserToAddRows = false;
            dgvMedecins.AllowUserToDeleteRows = false;
            dgvMedecins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedecins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedecins.Location = new Point(10, 262);
            dgvMedecins.Margin = new Padding(3, 2, 3, 2);
            dgvMedecins.MultiSelect = false;
            dgvMedecins.Name = "dgvMedecins";
            dgvMedecins.ReadOnly = true;
            dgvMedecins.RowHeadersWidth = 51;
            dgvMedecins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedecins.Size = new Size(788, 188);
            dgvMedecins.TabIndex = 5;
            dgvMedecins.SelectionChanged += dgvMedecins_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAfficherTous);
            groupBox1.Controls.Add(btnRechercheAdresse);
            groupBox1.Controls.Add(btnSupprimerMedecin);
            groupBox1.Controls.Add(btnModifierMedecin);
            groupBox1.Controls.Add(btnAjouMedecin);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(788, 248);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gestion des Médecins";
            // 
            // btnAfficherTous
            // 
            btnAfficherTous.Location = new Point(510, 190);
            btnAfficherTous.Margin = new Padding(3, 2, 3, 2);
            btnAfficherTous.Name = "btnAfficherTous";
            btnAfficherTous.Size = new Size(210, 30);
            btnAfficherTous.TabIndex = 4;
            btnAfficherTous.Text = "Afficher Tous";
            btnAfficherTous.UseVisualStyleBackColor = true;
            btnAfficherTous.Click += btnAfficherTous_Click;
            // 
            // btnRechercheAdresse
            // 
            btnRechercheAdresse.Location = new Point(510, 150);
            btnRechercheAdresse.Margin = new Padding(3, 2, 3, 2);
            btnRechercheAdresse.Name = "btnRechercheAdresse";
            btnRechercheAdresse.Size = new Size(210, 30);
            btnRechercheAdresse.TabIndex = 3;
            btnRechercheAdresse.Text = "Recherche par Adresse";
            btnRechercheAdresse.UseVisualStyleBackColor = true;
            btnRechercheAdresse.Click += btnRechercheAdresse_Click;
            // 
            // btnSupprimerMedecin
            // 
            btnSupprimerMedecin.Location = new Point(510, 112);
            btnSupprimerMedecin.Margin = new Padding(3, 2, 3, 2);
            btnSupprimerMedecin.Name = "btnSupprimerMedecin";
            btnSupprimerMedecin.Size = new Size(210, 30);
            btnSupprimerMedecin.TabIndex = 2;
            btnSupprimerMedecin.Text = "Supprimer";
            btnSupprimerMedecin.UseVisualStyleBackColor = true;
            btnSupprimerMedecin.Click += btnSupprimerMedecin_Click;
            // 
            // btnModifierMedecin
            // 
            btnModifierMedecin.Location = new Point(510, 77);
            btnModifierMedecin.Margin = new Padding(3, 2, 3, 2);
            btnModifierMedecin.Name = "btnModifierMedecin";
            btnModifierMedecin.Size = new Size(210, 30);
            btnModifierMedecin.TabIndex = 1;
            btnModifierMedecin.Text = "Modifier";
            btnModifierMedecin.UseVisualStyleBackColor = true;
            btnModifierMedecin.Click += btnModifierMedecin_Click;
            // 
            // btnAjouMedecin
            // 
            btnAjouMedecin.Location = new Point(510, 40);
            btnAjouMedecin.Margin = new Padding(3, 2, 3, 2);
            btnAjouMedecin.Name = "btnAjouMedecin";
            btnAjouMedecin.Size = new Size(210, 30);
            btnAjouMedecin.TabIndex = 0;
            btnAjouMedecin.Text = "Ajouter";
            btnAjouMedecin.UseVisualStyleBackColor = true;
            btnAjouMedecin.Click += btnAjouMedecin_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtAdresse);
            groupBox2.Controls.Add(lblAdresse);
            groupBox2.Controls.Add(dtpDateNaissance);
            groupBox2.Controls.Add(lblDate);
            groupBox2.Controls.Add(lblName);
            groupBox2.Controls.Add(txtName);
            groupBox2.Controls.Add(lblPrenom);
            groupBox2.Controls.Add(txtPrenom);
            groupBox2.Controls.Add(txtCin);
            groupBox2.Controls.Add(lblCin);
            groupBox2.Location = new Point(18, 22);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(438, 210);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informations Médecin";
            // 
            // txtAdresse
            // 
            txtAdresse.Location = new Point(131, 165);
            txtAdresse.Margin = new Padding(3, 2, 3, 2);
            txtAdresse.MaxLength = 100;
            txtAdresse.Name = "txtAdresse";
            txtAdresse.Size = new Size(280, 23);
            txtAdresse.TabIndex = 4;
            // 
            // lblAdresse
            // 
            lblAdresse.AutoSize = true;
            lblAdresse.Location = new Point(33, 168);
            lblAdresse.Name = "lblAdresse";
            lblAdresse.Size = new Size(54, 15);
            lblAdresse.TabIndex = 0;
            lblAdresse.Text = "Adresse :";
            // 
            // dtpDateNaissance
            // 
            dtpDateNaissance.Format = DateTimePickerFormat.Short;
            dtpDateNaissance.Location = new Point(131, 128);
            dtpDateNaissance.Margin = new Padding(3, 2, 3, 2);
            dtpDateNaissance.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            dtpDateNaissance.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpDateNaissance.Name = "dtpDateNaissance";
            dtpDateNaissance.Size = new Size(280, 23);
            dtpDateNaissance.TabIndex = 3;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(18, 134);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(93, 15);
            lblDate.TabIndex = 0;
            lblDate.Text = "Date Naissance :";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(39, 93);
            lblName.Name = "lblName";
            lblName.Size = new Size(40, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Nom :";
            // 
            // txtName
            // 
            txtPrenom.Location = new Point(131, 52);
            txtPrenom.Margin = new Padding(3, 2, 3, 2);
            txtPrenom.MaxLength = 50;
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(280, 23);
            txtPrenom.TabIndex = 1;
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(32, 55);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(55, 15);
            lblPrenom.TabIndex = 0;
            lblPrenom.Text = "Prénom :";
            // 
            // txtName
            // 
            txtName.Location = new Point(131, 90);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 23);
            txtName.TabIndex = 2;
            // 
            // txtCin
            // 
            txtCin.Location = new Point(131, 15);
            txtCin.Margin = new Padding(3, 2, 3, 2);
            txtCin.MaxLength = 20;
            txtCin.Name = "txtCin";
            txtCin.Size = new Size(280, 23);
            txtCin.TabIndex = 0;
            // 
            // lblCin
            // 
            lblCin.AutoSize = true;
            lblCin.Location = new Point(39, 18);
            lblCin.Name = "lblCin";
            lblCin.Size = new Size(33, 15);
            lblCin.TabIndex = 0;
            lblCin.Text = "CIN :";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // GestionMedecins
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 458);
            Controls.Add(groupBox1);
            Controls.Add(dgvMedecins);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GestionMedecins";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Médecins";
            Load += GestionMedecins_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedecins).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedecins;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCin;
        private System.Windows.Forms.Label lblCin;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDateNaissance;
        private System.Windows.Forms.Label lblAdresse;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Button btnAjouMedecin;
        private System.Windows.Forms.Button btnModifierMedecin;
        private System.Windows.Forms.Button btnSupprimerMedecin;
        private System.Windows.Forms.Button btnRechercheAdresse;
        private System.Windows.Forms.Button btnAfficherTous;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}