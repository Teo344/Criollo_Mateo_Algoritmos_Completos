using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Criollo_Mateo_Algoritmos_Gráficos_Básicos.UI
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmDDA frm = new FrmDDA())
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void brasenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBresenhamLinecs frm = new FrmBresenhamLinecs())
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void bresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBresenhamCircle frm = new FrmBresenhamCircle())
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void floodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmFloodFill frm = new FrmFloodFill())
            {
                frm.ShowDialog();
            }

            this.Close();
        }
    }
}
