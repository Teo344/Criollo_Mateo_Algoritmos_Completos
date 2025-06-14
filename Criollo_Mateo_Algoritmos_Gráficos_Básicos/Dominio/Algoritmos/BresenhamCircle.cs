using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criollo_Mateo_Algoritmos_Gráficos_Básicos.Dominio.Algoritmos
{
    public class BresenhamCircle : ICircleAlgorithm
    {
        public List<Pixel> DrawCircle(Point2D center, float radius, Color color)
        {
            List<Pixel> pixels = new List<Pixel>();

            float x = 0;
            float y = radius;
            float d = 3 - 2 * radius;

            while (x <= y)
            {
                // 8 octantes del círculo
                pixels.Add(new Pixel(new Point2D(center.X + x, center.Y + y), color));
                pixels.Add(new Pixel(new Point2D(center.X - x, center.Y + y), color));
                pixels.Add(new Pixel(new Point2D(center.X + x, center.Y - y), color));
                pixels.Add(new Pixel(new Point2D(center.X - x, center.Y - y), color));
                pixels.Add(new Pixel(new Point2D(center.X + y, center.Y + x), color));
                pixels.Add(new Pixel(new Point2D(center.X - y, center.Y + x), color));
                pixels.Add(new Pixel(new Point2D(center.X + y, center.Y - x), color));
                pixels.Add(new Pixel(new Point2D(center.X - y, center.Y - x), color));

                if (d < 0)
                {
                    d += 4 * x + 6;
                }
                else
                {
                    d += 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }

            return pixels;
        }

    }
}
