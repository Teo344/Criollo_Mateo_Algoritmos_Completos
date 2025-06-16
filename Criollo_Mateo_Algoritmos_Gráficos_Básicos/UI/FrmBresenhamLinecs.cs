using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Aplicacion;
using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Dominio.Algoritmos;
using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Entidades;
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
    public partial class FrmBresenhamLinecs : Form
    {

        DrawingManager drawingManager;
        ILineAlgorithm lineAlgorithm;

        public FrmBresenhamLinecs()
        {
            InitializeComponent();
        }

        private async void btnDibujar_Click(object sender, EventArgs e)
        {
            float X1 = float.Parse(txtX1.Text);
            float Y1 = float.Parse(txtY1.Text);
            float X2 = float.Parse(txtX2.Text);
            float Y2 = float.Parse(txtY2.Text);
            Point2D start = new Point2D(X1, Y1);
            Point2D end = new Point2D(X2, Y2);

            await drawingManager.DrawPixelsAsync(start, end, picCanvas, Table);
        }

        private void FrmBresenhamLinecs_Load(object sender, EventArgs e)
        {
            lineAlgorithm = new BresenhamLine();
            drawingManager = new DrawingManager(lineAlgorithm);
            Table.ColumnCount = 3;
            Table.Columns[0].Name = "Punto #";
            Table.Columns[1].Name = "X";
            Table.Columns[2].Name = "Y";
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

        private void bresenhamToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBresenhamCircle frm = new FrmBresenhamCircle())
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmFloodFill frm = new FrmFloodFill())
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            drawingManager.ClearAll(picCanvas, Table);

            txtX1.Text = "";
            txtY1.Text = "";
            txtX2.Text = "";
            txtY2.Text = "";
        }
    }
}
