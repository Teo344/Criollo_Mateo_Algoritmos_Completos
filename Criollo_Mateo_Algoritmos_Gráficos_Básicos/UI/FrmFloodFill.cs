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
    public partial class FrmFloodFill : Form
    {

        DrawingManager drawingManager;
        IFillAlgorithm fillAlgorithm;
        private Point2D? fillStartPoint = null;


        public FrmFloodFill()
        {
            InitializeComponent();
        }

        private void FrmFloodFill_Load(object sender, EventArgs e)
        {
            fillAlgorithm = new FloodFill();
            drawingManager = new DrawingManager(fillAlgorithm, picCanvas);
            Table.ColumnCount = 3;
            Table.Columns[0].Name = "Punto #";
            Table.Columns[1].Name = "X";
            Table.Columns[2].Name = "Y";

            btnPintar.Enabled = false; 


        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            float centerx = picCanvas.Width / 2f;
            float centery = picCanvas.Height / 2f;
            Point2D center = new Point2D(centerx, centery);
            int sides = int.Parse(txtLade.Text);


            drawingManager.DrawPolygon(center, 70, sides, picCanvas);
            btnPintar.Enabled = true;
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            fillStartPoint = new Point2D(e.X, e.Y);
        }

        private async void btnPintar_Click(object sender, EventArgs e)
        {
            if (fillStartPoint == null)
            {
                MessageBox.Show("Haz clic sobre la figura primero.");
                return;
            }

            Bitmap buffer = drawingManager.GetBuffer();
            if (buffer == null)
            {
                MessageBox.Show("No se ha generado el polígono aún.");
                return;
            }

            Color targetColor = buffer.GetPixel((int)fillStartPoint.Value.X, (int)fillStartPoint.Value.Y);
            Color fillColor = Color.Blue;

            await drawingManager.DrawFloodFill(buffer, fillStartPoint.Value, targetColor, fillColor, picCanvas, Table, 2);
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void bresenhamToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBresenhamCircle frm = new FrmBresenhamCircle())
            {
                frm.ShowDialog();
            }

            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            drawingManager.ClearAll(picCanvas, Table);
            txtLade.Text = "";
            fillStartPoint = null;
            btnPintar.Enabled = false;

        }
    }
}
