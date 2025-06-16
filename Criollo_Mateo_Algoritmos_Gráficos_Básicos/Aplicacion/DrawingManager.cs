using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Dominio;
using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Dominio.Algoritmos;
using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Criollo_Mateo_Algoritmos_Gráficos_Básicos.Aplicacion
{
    public class DrawingManager
    {
        private readonly ILineAlgorithm _lineAlgorithm;
        private readonly ICircleAlgorithm _circleAlgorithm; // No se usa, pero se puede implementar si es necesario
        private readonly IFillAlgorithm _fillAlgorithm; // No se usa, pero se puede implementar si es necesario
        private readonly PolygonGenerator _polygonGenerator;
        private Bitmap _buffer;

        public DrawingManager(ILineAlgorithm lineAlgorithm)
        {
            _lineAlgorithm = lineAlgorithm;
            _polygonGenerator = new PolygonGenerator(); // Si la usas para más adelante
        }

        public DrawingManager(IFillAlgorithm fillAlgorithm, PictureBox canvas)
        {
            _polygonGenerator = new PolygonGenerator();
            _fillAlgorithm = fillAlgorithm;
            _buffer = new Bitmap(canvas.Width, canvas.Height); // Usa el tamaño real del canvas
        }

        public DrawingManager( ICircleAlgorithm circleAlgorithm)
        {
            _circleAlgorithm = circleAlgorithm;
        }

        public Bitmap GetBuffer()
        {
            return _buffer;
        }



        public void DrawPolygon(Point2D center, float radius, int sides, PictureBox picCanvas)
        {
            var polygon = _polygonGenerator.GenerateRegularPolygon(center, radius, sides);
            _buffer = new Bitmap(picCanvas.Width, picCanvas.Height); // reinicia buffer

            using (Graphics g = Graphics.FromImage(_buffer))
            {
                Pen pen = new Pen(Color.Red, 3);
                Point[] points = polygon.vertices.Select(v => new Point((int)v.X, (int)v.Y)).ToArray();
                g.DrawPolygon(pen, points);
            }

            picCanvas.Image = _buffer; // mostrar en canvas

        }

      
        public async Task DrawFloodFill(Bitmap bitmap, Point2D startPoint, Color targetColor, Color fillColor, PictureBox canvas, DataGridView dgv, int delay)
        {
            dgv.Rows.Clear();

            FloodFill floodFill = _fillAlgorithm as FloodFill;
            if (floodFill == null)
                throw new InvalidOperationException("El algoritmo de relleno debe ser FloodFill para usar este método.");

            int count = 0;

            await _fillAlgorithm.FillAsync(bitmap, startPoint, targetColor, fillColor, (point, bmp, pixels) =>
            {
                // Actualiza imagen
                canvas.Image = (Bitmap)bmp.Clone();

                // Actualiza tabla con el último pixel pintado
                if (count < pixels.Count)
                {
                    var p = pixels[count];
                    dgv.Rows.Add(count + 1, p.X.ToString("0.00"), p.Y.ToString("0.00"));
                    count++;
                }
            }, delay);
        }


        public async Task DrawPixelsAsync(Point2D start, Point2D end, PictureBox canvas, DataGridView dgv)
        {

            if (start.X < 0 || start.Y < 0 || end.X < 0 || end.Y < 0)
                throw new ArgumentException("Las coordenadas deben ser números positivos.");

            var pixels = _lineAlgorithm.DrawLine(start, end, Color.Black);

            using (Graphics g = canvas.CreateGraphics())
            {
                dgv.Rows.Clear(); // Limpia la tabla antes

                float offsetX = canvas.Height / 6;
                float offsetY = canvas.Width / 2;

                for (int i = 0; i < pixels.Count; i++)
                {
                    var pixel = pixels[i];


                    float pixelX = (pixel.Position.X ) + offsetX;
                    float pixelY = offsetY - (pixel.Position.Y );


                    // Dibuja el pixel
                    g.FillRectangle(new SolidBrush(pixel.Color), pixelX, pixelY, 3, 3);

                    // Agrega a la tabla
                    dgv.Rows.Add(i + 1, pixel.Position.X.ToString("0.00"), pixel.Position.Y.ToString("0.00"));


                    await Task.Delay(100);
                }
            }
        }


        public async Task DrawPixelsAsync( float radius,PictureBox canvas, DataGridView dgv)
        {
            if (radius <= 0)
                throw new ArgumentException("El radio debe ser un número positivo.");

            float offsetX = canvas.Width / 2;
            float offsetY = canvas.Height / 2;
            Point2D center = new Point2D(offsetX, offsetY); 

            var pixels = _circleAlgorithm.DrawCircle(center, radius, Color.Black);


            using (Graphics g = canvas.CreateGraphics())
            {
                dgv.Rows.Clear();

                for (int i = 0; i < pixels.Count; i++)
                {
                    var pixel = pixels[i];

                    float pixelX = pixel.Position.X;
                    float pixelY = pixel.Position.Y;

                    g.FillRectangle(new SolidBrush(pixel.Color), pixelX, pixelY, 3, 3);

                    dgv.Rows.Add(i + 1, pixel.Position.X.ToString("0.00"), pixel.Position.Y.ToString("0.00"));

                    await Task.Delay(50);
                }
            }

        }

        public void ClearAll(PictureBox canvas, DataGridView dgv = null)
        {
            if (_buffer != null)
            {
                _buffer.Dispose();
                _buffer = null;
            }
            Bitmap blank = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = blank;

            dgv?.Rows.Clear();

        }


        }
}
