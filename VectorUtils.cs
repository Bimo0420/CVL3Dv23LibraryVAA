using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public static class VectorUtils
    {
        public static Vector2d Rotate90Left(Vector2d vector)
        {
            double newX = -vector.Y;
            double newY = vector.X;

            return new Vector2d(newX, newY);
        }
        public static Vector2d Rotate90Right(Vector2d vector)
        {
            // Поворачиваем вектор на 90 градусов по часовой стрелке
            double newX = vector.Y;
            double newY = -vector.X;

            return new Vector2d(newX, newY);
        }
    }

   
}
