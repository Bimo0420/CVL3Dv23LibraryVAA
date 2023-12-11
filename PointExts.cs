using Autodesk.AutoCAD.Geometry;
using Autodesk.Civil.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public static class PointExts
    {
        public static Point2d Convert3DPointTo2D(Point3d point3D)
        {
            Point2d point2D = new Point2d(point3D.X,point3D.Y);
            return point2D;
        }

        public static Point3d ChangeH(Point3d point3D, double newH)
        {
            
            Point3d newPoint3D = new Point3d(point3D.X, point3D.Y, newH);
            return newPoint3D;
            
        }

        public static Point3d RoundPoint3d(Point3d point, int decimalPlaces)
        {
            double factor = Math.Pow(10, decimalPlaces);
            double x = Math.Round(point.X * factor) / factor;
            double y = Math.Round(point.Y * factor) / factor;
            double z = Math.Round(point.Z * factor) / factor;

            return new Point3d(x, y, z);
        }

        public static Point2d RoundPoint2d(Point2d point, int decimalPlaces)
        {
            double factor = Math.Pow(10, decimalPlaces);
            double x = Math.Round(point.X * factor) / factor;
            double y = Math.Round(point.Y * factor) / factor;

            return new Point2d(x, y);
        }

        public static double GetPointZValueOnLine(LineSegment3d lineSegment3D, Point3d point3D)
        {
            if (lineSegment3D.EndPoint.X != lineSegment3D.StartPoint.X)
            {
                double pointNewZ = lineSegment3D.StartPoint.Z + ((point3D.X - lineSegment3D.StartPoint.X)
                                                  / (lineSegment3D.EndPoint.X - lineSegment3D.StartPoint.X))
                                                  * (lineSegment3D.EndPoint.Z - lineSegment3D.StartPoint.Z);
                return pointNewZ;
            }
            else //исклбчение, если труба парралельна OX
            {
                double pointNewZ = lineSegment3D.StartPoint.Z + ((point3D.Y - lineSegment3D.StartPoint.Y)
                                                  / (lineSegment3D.EndPoint.Y - lineSegment3D.StartPoint.Y))
                                                  * (lineSegment3D.EndPoint.Z - lineSegment3D.StartPoint.Z);
                return pointNewZ;
            }
        }

        public static double GetZValueAtParameter(LineSegment3d segment, double parameter)
        {
            double delta = segment.EndPoint.Z - segment.StartPoint.Z;
            double zValue = segment.StartPoint.Z + delta * parameter;

            return zValue;
        }

        public static double GetPointZValueOnPipe(Pipe pipe, Point3d point3D)
        {
            if (pipe.EndPoint.X != pipe.StartPoint.X) 
            {
                double pointNewZ = pipe.StartPoint.Z + ((point3D.X - pipe.StartPoint.X)
                                                  / (pipe.EndPoint.X - pipe.StartPoint.X))
                                                  * (pipe.EndPoint.Z - pipe.StartPoint.Z);
                return pointNewZ;
            }
            else //исклбчение, если труба парралельна OX
            {
                double pointNewZ = pipe.StartPoint.Z + ((point3D.Y - pipe.StartPoint.Y)
                                                  / (pipe.EndPoint.Y - pipe.StartPoint.Y))
                                                  * (pipe.EndPoint.Z - pipe.StartPoint.Z);
                return pointNewZ;
            }
        }

        public static double GetPointZValueOnPressurePipe(PressurePipe pressurePipe, Point3d point3D)
        {
            if (pressurePipe.EndPoint.X != pressurePipe.StartPoint.X)
            {
                double pointNewZ = pressurePipe.StartPoint.Z + ((point3D.X - pressurePipe.StartPoint.X)
                                                   / (pressurePipe.EndPoint.X - pressurePipe.StartPoint.X))
                                                   * (pressurePipe.EndPoint.Z - pressurePipe.StartPoint.Z);
                return pointNewZ;
            }
            else //исклбчение, если труба парралельна OX
            {
                double pointNewZ = pressurePipe.StartPoint.Z + ((point3D.Y - pressurePipe.StartPoint.Y)
                                                  / (pressurePipe.EndPoint.Y - pressurePipe.StartPoint.Y))
                                                  * (pressurePipe.EndPoint.Z - pressurePipe.StartPoint.Z);
                return pointNewZ;
            }

        }

        public static Point3d GetMiddlePoint(this Point3d point, Point3d otherPoint)
        {
            return new Point3d((point.X + otherPoint.X) / 2,
                                (point.Y + otherPoint.Y) / 2,
                                (point.Z + otherPoint.Z) / 2);
        }

        public static double GetDistanceBetweenPoint(Point3d point, Point3d otherPoint)
        {
            double deltaX = otherPoint.X - point.X;
            double deltaY = otherPoint.Y - point.Y;
            double deltaZ = otherPoint.Z - point.Z;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }


        public static Point2d PointOffset(Point2d point1, Vector2d vector, double length)
        {
            // Вычисляем длину вектора
            double vectorLength = vector.Length;


            // Проверяем, чтобы длина вектора была ненулевой
            if (vectorLength > 0)
            {
                // Нормализуем вектор (делаем его единичной длины)
                Vector2d normalizedVector = vector / vectorLength;

                // Умножаем нормализованный вектор на заданное расстояние
                Vector2d scaledVector = normalizedVector * length;

                // Вычисляем координаты второй точки
                double x2 = point1.X + scaledVector.X;
                double y2 = point1.Y + scaledVector.Y;

                return new Point2d(x2, y2);
            }
            else
            {
                // Если длина вектора равна нулю, вернуть начальную точку
                return point1;
            }
        }

    }
}
