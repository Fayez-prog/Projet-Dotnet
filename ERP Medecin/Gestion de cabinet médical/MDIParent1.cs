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
    public partial class MDIParent1 : Form
    {
        private readonly CabinetContext _context;
        private readonly IMedecinService _medecinService;
        private readonly IPatientService _patientService;
        private readonly IRendezVousService _rendezVousService;

        public MDIParent1(
            CabinetContext context,
            IMedecinService medecinService,
            IPatientService patientService,
            IRendezVousService rendezVousService)
        {
            InitializeComponent();
            _context = context;
            _medecinService = medecinService;
            _patientService = patientService;
            _rendezVousService = rendezVousService;
        }

        private void GestionMedecinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GestionMedecins(_medecinService)
            {
                MdiParent = this
            };
            form.Show();
        }

        private void GestionPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GestionPatients(_patientService)
            {
                MdiParent = this
            };
            form.Show();
        }

        private void GestionRendezVousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GestionRendezVous(_rendezVousService)
            {
                MdiParent = this
            };
            form.Show();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}
