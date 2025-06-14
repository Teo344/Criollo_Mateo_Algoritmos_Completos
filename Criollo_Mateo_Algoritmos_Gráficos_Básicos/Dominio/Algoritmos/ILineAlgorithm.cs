using Criollo_Mateo_Algoritmos_Gráficos_Básicos.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criollo_Mateo_Algoritmos_Gráficos_Básicos.Dominio.Algoritmos
{
    public interface ILineAlgorithm
    {
        List<Pixel> DrawLine(Point2D start, Point2D end, Color color);
    }
}
