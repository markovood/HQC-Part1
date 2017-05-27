namespace MethodPrintStatisticsInCSharp
{
    using System;

    public class Tester
    {
        public static void Main()
        {
            var t = new Tester();
            t.PrintStatistics(new double[] { 4, 5, 6, 7, 8, 9 }, 6);
        }

        public void PrintStatistics(double[] arr, int count)
        {
            double max = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            this.PrintMax(max);

            double min = max;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            this.PrintMin(min);

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            this.PrintAvg(sum / count);
        }

        private void PrintMax(double max)
        {
            Console.WriteLine(max);
        }

        private void PrintMin(double min)
        {
            Console.WriteLine(min);
        }

        private void PrintAvg(double average)
        {
            Console.WriteLine(average);
        }
    }
}
