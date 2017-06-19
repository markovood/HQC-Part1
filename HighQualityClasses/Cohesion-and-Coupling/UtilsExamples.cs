using System;

namespace CohesionAndCoupling
{
    public class UtilsExamples
    {
        public static void Main()
        {
            //Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            double x1 = 1;
            double y1 = -2;
            double x2 = 3;
            double y2 = 4;
            Console.WriteLine("Distance in the 2D space = {0:f2}",
                MathUtils.CalcDistance2D(x1, y1, x2, y2));

            x1 = 5;
            y1 = 2;
            double z1 = -1;
            x2 = 3;
            y2 = -6;
            double z2 = 4;
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                MathUtils.CalcDistance3D(x1, y1, z1, x2, y2, z2));
            
            double width = 3;
            double height = 4;
            double depth = 5;
            Console.WriteLine("Volume = {0:f2}", MathUtils.CalcVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", MathUtils.CalcDiagonalXYZ(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", MathUtils.CalcDiagonalXY(width, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", MathUtils.CalcDiagonalXZ(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", MathUtils.CalcDiagonalYZ(height, depth));
        }
    }
}
