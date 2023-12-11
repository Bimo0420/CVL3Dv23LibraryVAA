using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public class GeometryUtils
    {
        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public static Point3d GetPoint3dOnLine (Point3d startPoint, Point3d endPoint, double parameter) //подобие треугольников
        {
            double interpolatedX = startPoint.X + parameter*(endPoint.X - startPoint.X);
            double interpolatedY = startPoint.Y + parameter*(endPoint.Y - startPoint.Y);
            double interpolatedZ = startPoint.Z + parameter*(endPoint.Z - startPoint.Z);

            return new Point3d(interpolatedX, interpolatedY, interpolatedZ);
         
        }
    }
}
