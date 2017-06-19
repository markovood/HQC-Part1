using System;

namespace CohesionAndCoupling
{
    public static class MathUtils
    {
        public static double CalcDistance2D(double coordinateX1, double coordinateY1,
                                            double coordinateX2, double coordinateY2)
        {
            double distance = Math.Sqrt(
                (coordinateX2 - coordinateX1) * (coordinateX2 - coordinateX1) +
                (coordinateY2 - coordinateY1) * (coordinateY2 - coordinateY1));
            return distance;
        }

        public static double CalcDistance3D(double coordinateX1, double coordinateY1, double coordinateZ1,
                                            double coordinateX2, double coordinateY2, double coordinateZ2)
        {
            double distance = Math.Sqrt(
                (coordinateX2 - coordinateX1) * (coordinateX2 - coordinateX1) +
                (coordinateY2 - coordinateY1) * (coordinateY2 - coordinateY1) +
                (coordinateZ2 - coordinateZ1) * (coordinateZ2 - coordinateZ1));
            return distance;
        }

        public static double CalcVolume(double width, double height, double depth)
        {
            ValidateDimensions(width, height, depth);
            double volume = width * height * depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(double width, double height, double depth)
        {
            ValidateDimensions(width, height, depth);
            double distance = CalcDistance3D(0, 0, 0, width, height, depth);
            return distance;
        }

        public static double CalcDiagonalXY(double width, double height)
        {
            ValidateDimensions(width, height);
            double distance = CalcDistance2D(0, 0, width, height);
            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            ValidateDimensions(width, depth);
            double distance = CalcDistance2D(0, 0, width, depth);
            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            ValidateDimensions(height, depth);
            double distance = CalcDistance2D(0, 0, height, depth);
            return distance;
        }

        private static void ValidateDimensions(params double[] dimensions)
        {
            foreach (var dimension in dimensions)
            {
                if (dimension < 0)
                {
                    throw new ArgumentException("Dimension cannot be negative!");
                }
            }
        }
    }
}
