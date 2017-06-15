namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive!");
            }

            double perimeter = (a + b + c) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));
            return area;
        }

        public static string Digits0To9AsString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Accepted numbers are 0 to 9 only!");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("You have to pass at least one argument!");
            }

            int maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintFormatedNumber(double number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;

                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;

                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;

                default:
                    throw new ArgumentException("Wrong format: could be 'f' or '%' or 'r' only!");
            }
        }


        public static double CalcDistance(double coordinateX1, double coordinateY1,
                                            double coordinateX2, double coordinateY2)
        {
            double distance = Math.Sqrt(
                (coordinateX2 - coordinateX1) * (coordinateX2 - coordinateX1) + 
                (coordinateY2 - coordinateY1) * (coordinateY2 - coordinateY1));
            return distance;
        }

        public static bool IsHorizontal(double coordinateY1, double coordinateY2)
        {
            if (coordinateY1 == coordinateY2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsVertical(double coordinateX1, double coordinateX2)
        {
            if (coordinateX1 == coordinateX2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(Digits0To9AsString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintFormatedNumber(1.3, "f");
            PrintFormatedNumber(0.75, "%");
            PrintFormatedNumber(2.30, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontal(-1, 2.5));
            Console.WriteLine("Vertical? " + IsVertical(3, 3));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
