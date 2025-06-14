using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criollo_Mateo_Algoritmos_Gráficos_Básicos.Entidades
{
    public struct Point2D
    {
        public float X { get; }
        public float Y { get; }

        public Point2D(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}