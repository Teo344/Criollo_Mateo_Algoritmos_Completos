using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Aplicacion;
using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Dominio.Algoritmos;
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
    public partial class FrmBresenhamCircle : Form
    {

        DrawingManager drawingManager;
        ICircleAlgorithm circleAlgorithm;

        public FrmBresenhamCircle()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmHome frm = new FrmHome())
            {
                frm.ShowDialog();
            }

            this.Close();
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

        private void bresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBresenhamLinecs frm = new FrmBresenhamLinecs())
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void floodFillToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void  btnDibujar_Click(object sender, EventArgs e)
        {
            float radius = float.Parse(txtRadius.Text);

            await drawingManager.DrawPixelsAsync(radius, picCanvas, Table);
        }

        private void FrmBresenhamCircle_Load(object sender, EventArgs e)
        {
            circleAlgorithm = new BresenhamCircle();
            drawingManager = new DrawingManager(circleAlgorithm);
            Table.ColumnCount = 3;
            Table.Columns[0].Name = "Punto #";
            Table.Columns[1].Name = "X";
            Table.Columns[2].Name = "Y";
        }
    }
}
