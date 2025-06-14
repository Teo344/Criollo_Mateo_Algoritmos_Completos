using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criollo_Mateo_Algoritmos_Gráficos_Básicos.Dominio.Algoritmos
{
    public class FloodFill: IFillAlgorithm
    {

        public List<Point2D> Fill(Bitmap bitmap, Point2D startPoint, Color targetColor, Color replacementColor)
        {
            Stack<Point2D> stack = new Stack<Point2D>();
            List<Point2D> filledPixels = new List<Point2D>();

            int width = bitmap.Width;
            int height = bitmap.Height;

            stack.Push(startPoint);

            while (stack.Count > 0)
            {
                Point2D p = stack.Pop();

                if (p.X < 0 || p.X >= width || p.Y < 0 || p.Y >= height)
                    continue;

                if (bitmap.GetPixel((int)p.X, (int)p.Y).ToArgb() != targetColor.ToArgb())
                    continue;

                bitmap.SetPixel((int)p.X, (int)p.Y, replacementColor);
                filledPixels.Add(p);

                stack.Push(new Point2D(p.X + 1, p.Y));
                stack.Push(new Point2D(p.X - 1, p.Y));
                stack.Push(new Point2D(p.X, p.Y + 1));
                stack.Push(new Point2D(p.X, p.Y - 1));
            }

            return filledPixels;
        }


    }

}
