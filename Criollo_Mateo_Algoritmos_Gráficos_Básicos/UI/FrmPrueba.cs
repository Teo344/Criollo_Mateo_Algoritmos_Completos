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
    public partial class FrmPrueba : Form
    {
        DrawingManager drawingManager;
        IFillAlgorithm fillAlgorithm;
        private Point2D? fillStartPoint = null;

        public FrmPrueba()
        {
            InitializeComponent();
        }
        private void FrmPrueba_Load(object sender, EventArgs e)
        {
            fillAlgorithm = new FloodFill();
            drawingManager = new DrawingManager(fillAlgorithm);
            Table.ColumnCount = 3;
            Table.Columns[0].Name = "Punto #";
            Table.Columns[1].Name = "X";
            Table.Columns[2].Name = "Y";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float centerx  = picCanvas.Width / 2f;
            float centery = picCanvas.Height / 2f;
            Point2D center = new Point2D(centerx, centery);
            int sides = int.Parse(txtLade.Text);


            drawingManager.DrawPolygon(center, 70, sides, picCanvas);
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            fillStartPoint = new Point2D(e.X, e.Y);
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            if (fillStartPoint == null)
            {
                MessageBox.Show("Haz clic sobre la figura primero.");
                return;
            }

            Color targetColor = drawingManager.GetBuffer().GetPixel((int)fillStartPoint.Value.X, (int)fillStartPoint.Value.Y);
            Color fillColor = Color.Blue;

            var pixels = fillAlgorithm.Fill(drawingManager.GetBuffer(), fillStartPoint.Value, targetColor, fillColor);

            Table.Rows.Clear();

            for (int i = 0; i < pixels.Count; i++)
            {
                Table.Rows.Add(i + 1, pixels[i].X, pixels[i].Y);
                if (i % 10 == 0) // solo renderizar cada 10 píxeles para evitar ralentizar
                {
                    drawingManager.RenderBuffer(picCanvas);
                    await Task.Delay(10);
                }
            }

            drawingManager.RenderBuffer(picCanvas); // final render
        }
    }
}
