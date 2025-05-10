namespace Gestion_Medical
{
    partial class MenuCabinetNomMatricule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            patientToolStripMenuItem = new ToolStripMenuItem();
            nouveauPatientToolStripMenuItem = new ToolStripMenuItem();
            gestionConsultationsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { patientToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // patientToolStripMenuItem
            // 
            patientToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nouveauPatientToolStripMenuItem, gestionConsultationsToolStripMenuItem });
            patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            patientToolStripMenuItem.Size = new Size(56, 20);
            patientToolStripMenuItem.Text = "Patient";
            // 
            // nouveauPatientToolStripMenuItem
            // 
            nouveauPatientToolStripMenuItem.Name = "nouveauPatientToolStripMenuItem";
            nouveauPatientToolStripMenuItem.Size = new Size(209, 22);
            nouveauPatientToolStripMenuItem.Text = "Nouveau";
            nouveauPatientToolStripMenuItem.Click += nouveauPatientToolStripMenuItem_Click;
            // 
            // gestionConsultationsToolStripMenuItem
            // 
            gestionConsultationsToolStripMenuItem.Name = "gestionConsultationsToolStripMenuItem";
            gestionConsultationsToolStripMenuItem.Size = new Size(209, 22);
            gestionConsultationsToolStripMenuItem.Text = "Gestion des consultations";
            gestionConsultationsToolStripMenuItem.Click += gestionConsultationsToolStripMenuItem_Click;
            // 
            // MenuCabinetNomMatricule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MenuCabinetNomMatricule";
            Text = "Cabinet Médical";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouveauPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionConsultationsToolStripMenuItem;
    }
}



