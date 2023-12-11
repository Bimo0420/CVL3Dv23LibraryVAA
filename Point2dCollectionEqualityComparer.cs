using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public class Point2dCollectionEqualityComparer : IEqualityComparer<Point2dCollection>
    {
        public bool Equals(Point2dCollection x, Point2dCollection y)
        {
            // Сравниваем две коллекции точек
            if (x.Count != y.Count)
                return false;

            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                    return false;
            }

            return true;
        }

        public int GetHashCode(Point2dCollection obj)
        {
            // Генерируем хеш-код для коллекции точек
            int hashCode = 17;
            foreach (Point2d point in obj)
            {
                hashCode = hashCode * 23 + point.GetHashCode();
            }
            return hashCode;
        }
    }
}
