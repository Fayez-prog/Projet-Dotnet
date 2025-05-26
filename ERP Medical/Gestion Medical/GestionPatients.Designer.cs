namespace Gestion_Medical
{
    partial class GestionPatients
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
            dgvPatients = new DataGridView();
            gbInformations = new GroupBox();
            numAge = new NumericUpDown();
            label7 = new Label();
            cbSexe = new ComboBox();
            label6 = new Label();
            txtPrenom = new TextBox();
            label5 = new Label();
            txtNom = new TextBox();
            label4 = new Label();
            cbTypeCNAM = new ComboBox();
            label3 = new Label();
            txtNumCNAM = new TextBox();
            label2 = new Label();
            txtCIN = new TextBox();
            label1 = new Label();
            gbActions = new GroupBox();
            btnReset = new Button();
            btnRechercher = new Button();
            btnNouveau = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            gbInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            gbActions.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Dock = DockStyle.Fill;
            dgvPatients.Location = new Point(0, 275);
            dgvPatients.Margin = new Padding(4, 3, 4, 3);
            dgvPatients.MultiSelect = false;
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(933, 244);
            dgvPatients.TabIndex = 0;
            // 
            // gbInformations
            // 
            gbInformations.Controls.Add(numAge);
            gbInformations.Controls.Add(label7);
            gbInformations.Controls.Add(cbSexe);
            gbInformations.Controls.Add(label6);
            gbInformations.Controls.Add(txtPrenom);
            gbInformations.Controls.Add(label5);
            gbInformations.Controls.Add(txtNom);
            gbInformations.Controls.Add(label4);
            gbInformations.Controls.Add(cbTypeCNAM);
            gbInformations.Controls.Add(label3);
            gbInformations.Controls.Add(txtNumCNAM);
            gbInformations.Controls.Add(label2);
            gbInformations.Controls.Add(txtCIN);
            gbInformations.Controls.Add(label1);
            gbInformations.Dock = DockStyle.Top;
            gbInformations.Location = new Point(0, 0);
            gbInformations.Margin = new Padding(4, 3, 4, 3);
            gbInformations.Name = "gbInformations";
            gbInformations.Padding = new Padding(4, 3, 4, 3);
            gbInformations.Size = new Size(933, 185);
            gbInformations.TabIndex = 1;
            gbInformations.TabStop = false;
            gbInformations.Text = "Informations Patient";
            // 
            // numAge
            // 
            numAge.Location = new Point(700, 96);
            numAge.Margin = new Padding(4, 3, 4, 3);
            numAge.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numAge.Name = "numAge";
            numAge.Size = new Size(140, 23);
            numAge.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(700, 78);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 12;
            label7.Text = "Age";
            // 
            // cbSexe
            // 
            cbSexe.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSexe.FormattingEnabled = true;
            cbSexe.Location = new Point(525, 127);
            cbSexe.Margin = new Padding(4, 3, 4, 3);
            cbSexe.Name = "cbSexe";
            cbSexe.Size = new Size(139, 23);
            cbSexe.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(525, 104);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 10;
            label6.Text = "Sexe";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(350, 127);
            txtPrenom.Margin = new Padding(4, 3, 4, 3);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(139, 23);
            txtPrenom.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(350, 104);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 8;
            label5.Text = "Prénom";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(175, 127);
            txtNom.Margin = new Padding(4, 3, 4, 3);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(139, 23);
            txtNom.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(175, 104);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 6;
            label4.Text = "Nom";
            // 
            // cbTypeCNAM
            // 
            cbTypeCNAM.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTypeCNAM.FormattingEnabled = true;
            cbTypeCNAM.Location = new Point(525, 58);
            cbTypeCNAM.Margin = new Padding(4, 3, 4, 3);
            cbTypeCNAM.Name = "cbTypeCNAM";
            cbTypeCNAM.Size = new Size(139, 23);
            cbTypeCNAM.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(525, 35);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 4;
            label3.Text = "Type CNAM";
            // 
            // txtNumCNAM
            // 
            txtNumCNAM.Location = new Point(350, 58);
            txtNumCNAM.Margin = new Padding(4, 3, 4, 3);
            txtNumCNAM.Name = "txtNumCNAM";
            txtNumCNAM.Size = new Size(139, 23);
            txtNumCNAM.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(350, 35);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 2;
            label2.Text = "Num CNAM";
            // 
            // txtCIN
            // 
            txtCIN.Location = new Point(175, 58);
            txtCIN.Margin = new Padding(4, 3, 4, 3);
            txtCIN.Name = "txtCIN";
            txtCIN.Size = new Size(139, 23);
            txtCIN.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(175, 35);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 0;
            label1.Text = "CIN";
            // 
            // gbActions
            // 
            gbActions.Controls.Add(btnReset);
            gbActions.Controls.Add(btnRechercher);
            gbActions.Controls.Add(btnNouveau);
            gbActions.Dock = DockStyle.Top;
            gbActions.Location = new Point(0, 185);
            gbActions.Margin = new Padding(4, 3, 4, 3);
            gbActions.Name = "gbActions";
            gbActions.Padding = new Padding(4, 3, 4, 3);
            gbActions.Size = new Size(933, 90);
            gbActions.TabIndex = 2;
            gbActions.TabStop = false;
            gbActions.Text = "Actions";
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnReset.Image = Properties.Resources.reset;
            btnReset.ImageAlign = ContentAlignment.MiddleLeft;
            btnReset.Location = new Point(651, 14);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(217, 70);
            btnReset.TabIndex = 2;
            btnReset.Text = "Réinitialiser";
            btnReset.TextAlign = ContentAlignment.MiddleRight;
            btnReset.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnRechercher
            // 
            btnRechercher.Cursor = Cursors.Hand;
            btnRechercher.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnRechercher.Image = Properties.Resources.profile;
            btnRechercher.ImageAlign = ContentAlignment.MiddleLeft;
            btnRechercher.Location = new Point(350, 14);
            btnRechercher.Margin = new Padding(4, 3, 4, 3);
            btnRechercher.Name = "btnRechercher";
            btnRechercher.Size = new Size(196, 70);
            btnRechercher.TabIndex = 1;
            btnRechercher.Text = "Rechercher";
            btnRechercher.TextAlign = ContentAlignment.MiddleRight;
            btnRechercher.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRechercher.UseVisualStyleBackColor = true;
            btnRechercher.Click += btnRechercher_Click;
            // 
            // btnNouveau
            // 
            btnNouveau.Cursor = Cursors.Hand;
            btnNouveau.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnNouveau.Image = Properties.Resources.new1;
            btnNouveau.ImageAlign = ContentAlignment.MiddleLeft;
            btnNouveau.Location = new Point(59, 14);
            btnNouveau.Margin = new Padding(4, 3, 4, 3);
            btnNouveau.Name = "btnNouveau";
            btnNouveau.Size = new Size(178, 70);
            btnNouveau.TabIndex = 0;
            btnNouveau.Text = "Nouveau";
            btnNouveau.TextAlign = ContentAlignment.MiddleRight;
            btnNouveau.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNouveau.UseVisualStyleBackColor = true;
            btnNouveau.Click += btnNouveau_Click;
            // 
            // GestionPatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(dgvPatients);
            Controls.Add(gbActions);
            Controls.Add(gbInformations);
            Margin = new Padding(4, 3, 4, 3);
            Name = "GestionPatients";
            Text = "Gestion des Patients";
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            gbInformations.ResumeLayout(false);
            gbInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            gbActions.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.GroupBox gbInformations;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSexe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTypeCNAM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumCNAM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCIN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Button btnNouveau;
    }
}