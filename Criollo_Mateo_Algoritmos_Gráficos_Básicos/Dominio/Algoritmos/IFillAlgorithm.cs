using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criollo_Mateo_Algoritmos_Gráficos_Básicos.Dominio.Algoritmos
{
    public interface IFillAlgorithm
    {
        Task FillAsync( Bitmap bitmap, Point2D startPoint, Color targetColor,Color replacementColor,Action<Point2D, Bitmap, List<Point2D>> progressCallback,int delay);

    }
}

