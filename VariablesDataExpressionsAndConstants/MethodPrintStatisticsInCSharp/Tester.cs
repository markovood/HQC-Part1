using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodPrintStatisticsInCSharp
{
    public class Tester
    {
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

            PrintMax(max);

            double min = max;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            PrintMin(min);

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            PrintAvg(sum / count);
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

        public static void Main()
        {
            var t = new Tester();
            t.PrintStatistics(new double[] { 4, 5, 6, 7, 8, 9 }, 6);
        }
    }
}
