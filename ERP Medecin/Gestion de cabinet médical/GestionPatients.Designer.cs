namespace Gestion_de_cabinet_médical
{
    partial class GestionPatients
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
            dgvPatients = new DataGridView();
            groupBox1 = new GroupBox();
            btnAfficherTous = new Button();
            btnRechercheNom = new Button();
            btnSupprimerPatient = new Button();
            btnModifierPatient = new Button();
            btnAjouPatient = new Button();
            groupBox2 = new GroupBox();
            txtTelephone = new TextBox();
            lblTelephone = new Label();
            dtpDateNaissance = new DateTimePicker();
            lblDate = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblPrenom = new Label();
            txtPrenom = new TextBox();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(10, 262);
            dgvPatients.Margin = new Padding(3, 2, 3, 2);
            dgvPatients.MultiSelect = false;
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(788, 188);
            dgvPatients.TabIndex = 5;
            dgvPatients.SelectionChanged += dgvPatients_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAfficherTous);
            groupBox1.Controls.Add(btnRechercheNom);
            groupBox1.Controls.Add(btnSupprimerPatient);
            groupBox1.Controls.Add(btnModifierPatient);
            groupBox1.Controls.Add(btnAjouPatient);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(788, 248);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gestion des Patients";
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
            // btnRechercheNom
            // 
            btnRechercheNom.Location = new Point(510, 150);
            btnRechercheNom.Margin = new Padding(3, 2, 3, 2);
            btnRechercheNom.Name = "btnRechercheNom";
            btnRechercheNom.Size = new Size(210, 30);
            btnRechercheNom.TabIndex = 3;
            btnRechercheNom.Text = "Recherche par Nom";
            btnRechercheNom.UseVisualStyleBackColor = true;
            btnRechercheNom.Click += btnRechercheNom_Click;
            // 
            // btnSupprimerPatient
            // 
            btnSupprimerPatient.Location = new Point(510, 112);
            btnSupprimerPatient.Margin = new Padding(3, 2, 3, 2);
            btnSupprimerPatient.Name = "btnSupprimerPatient";
            btnSupprimerPatient.Size = new Size(210, 30);
            btnSupprimerPatient.TabIndex = 2;
            btnSupprimerPatient.Text = "Supprimer";
            btnSupprimerPatient.UseVisualStyleBackColor = true;
            btnSupprimerPatient.Click += btnSupprimerPatient_Click;
            // 
            // btnModifierPatient
            // 
            btnModifierPatient.Location = new Point(510, 77);
            btnModifierPatient.Margin = new Padding(3, 2, 3, 2);
            btnModifierPatient.Name = "btnModifierPatient";
            btnModifierPatient.Size = new Size(210, 30);
            btnModifierPatient.TabIndex = 1;
            btnModifierPatient.Text = "Modifier";
            btnModifierPatient.UseVisualStyleBackColor = true;
            btnModifierPatient.Click += btnModifierPatient_Click;
            // 
            // btnAjouPatient
            // 
            btnAjouPatient.Location = new Point(510, 40);
            btnAjouPatient.Margin = new Padding(3, 2, 3, 2);
            btnAjouPatient.Name = "btnAjouPatient";
            btnAjouPatient.Size = new Size(210, 30);
            btnAjouPatient.TabIndex = 0;
            btnAjouPatient.Text = "Ajouter";
            btnAjouPatient.UseVisualStyleBackColor = true;
            btnAjouPatient.Click += btnAjouPatient_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtTelephone);
            groupBox2.Controls.Add(lblTelephone);
            groupBox2.Controls.Add(dtpDateNaissance);
            groupBox2.Controls.Add(lblDate);
            groupBox2.Controls.Add(lblName);
            groupBox2.Controls.Add(txtName);
            groupBox2.Controls.Add(lblPrenom);
            groupBox2.Controls.Add(txtPrenom);
            groupBox2.Location = new Point(18, 22);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(438, 210);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informations Patient";
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(131, 173);
            txtTelephone.Margin = new Padding(3, 2, 3, 2);
            txtTelephone.MaxLength = 100;
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(280, 23);
            txtTelephone.TabIndex = 4;
            // 
            // lblTelephone
            // 
            lblTelephone.AutoSize = true;
            lblTelephone.Location = new Point(33, 176);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(67, 15);
            lblTelephone.TabIndex = 0;
            lblTelephone.Text = "Telephone :";
            // 
            // dtpDateNaissance
            // 
            dtpDateNaissance.Format = DateTimePickerFormat.Short;
            dtpDateNaissance.Location = new Point(131, 130);
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
            lblDate.Location = new Point(19, 136);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(93, 15);
            lblDate.TabIndex = 0;
            lblDate.Text = "Date Naissance :";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(33, 88);
            lblName.Name = "lblName";
            lblName.Size = new Size(40, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Nom :";
            // 
            // txtName
            // 
            txtName.Location = new Point(131, 85);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 23);
            txtName.TabIndex = 2;
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Location = new Point(33, 40);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(55, 15);
            lblPrenom.TabIndex = 0;
            lblPrenom.Text = "Prénom :";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(131, 37);
            txtPrenom.Margin = new Padding(3, 2, 3, 2);
            txtPrenom.MaxLength = 50;
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(280, 23);
            txtPrenom.TabIndex = 1;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // GestionPatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 458);
            Controls.Add(groupBox1);
            Controls.Add(dgvPatients);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GestionPatients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Patients";
            Load += GestionPatients_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDateNaissance;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Button btnAjouPatient;
        private System.Windows.Forms.Button btnModifierPatient;
        private System.Windows.Forms.Button btnSupprimerPatient;
        private System.Windows.Forms.Button btnRechercheNom;
        private System.Windows.Forms.Button btnAfficherTous;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}