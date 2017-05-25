using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSizeInCSharp
{
    public class Size
    {
        private double width, height;
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public static Size GetRotatedSize(
            Size dimensions, double angle)
        {
            double width = Math.Abs(Math.Cos(angle)) * dimensions.Width +
                            Math.Abs(Math.Sin(angle)) * dimensions.Height;
            double height = Math.Abs(Math.Sin(angle)) * dimensions.Width +
                            Math.Abs(Math.Cos(angle)) * dimensions.Height;

            var rotatedSize = new Size(width, height);
            return rotatedSize;
        }
    }

    public class Tester
    {
        public static void Main()
        {
        }
    }
}
