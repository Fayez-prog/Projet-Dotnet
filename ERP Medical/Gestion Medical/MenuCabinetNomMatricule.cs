using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Medical
{
    public partial class MenuCabinetNomMatricule : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MenuCabinetNomMatricule(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void nouveauPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<GestionPatients>();
            form.MdiParent = this;
            form.Show();
        }

        private void gestionConsultationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<GestionConsultations>();
            form.MdiParent = this;
            form.Show();
        }
    }
}
