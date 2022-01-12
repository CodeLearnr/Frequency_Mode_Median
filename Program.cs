using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA13FrequencyModeMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            int[] freqA;

            Console.Write("Please enter the array size: ");
            int arrSize = int.Parse(Console.ReadLine());

            Console.Write("Enter any integer to be used as a seed number: ");
            int seed = int.Parse(Console.ReadLine());

            Random r = new Random(seed);

            arr = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                arr[i] = r.Next(0, 100);
            }

            Console.WriteLine("\nThe elements of the array are:");
            ShowArray(arr);

            Array.Sort(arr);
            Console.WriteLine("\n==== Sorted Array === ");
            ShowArray(arr);

            Console.WriteLine("\nThe frequencies of the elements in the array are: ");
            Frequency(arr);

            Console.WriteLine("\nThe sum of the array is:  " + SumAll(arr));
            Console.WriteLine("The length of the array is: " + arrSize);
            double mean = (SumAll(arr)) / (Convert.ToDouble(arrSize));
            Console.WriteLine($"The mean of the array is:   {mean:N2}");
            Console.WriteLine("The median of the array is: " + Median(arr));
            freqA = new int[arr.Length];
            Frequency2(arr, freqA);
            //Console.WriteLine(freqA);
            int m = freqA.Max();
            if (m == 1)
            {
                Console.WriteLine("There is no mode.");
            }else
            {
            Console.WriteLine("The maximum occurance is:   " + m + " times.");
            int p = Array.IndexOf(freqA, m);
            Console.WriteLine($"The indices of the mode are: {p} to {p+m-1}");
            Console.WriteLine($"The mode has the value of {arr[p]}");
            }

            Console.Read();
        }
        
        public static void Frequency2(int[] arr, int[] freqA)
        {
            
            for (int i = 0; i < arr.Length; i++)
            {
                //int[] freqA = new int[arr.Length];
                freqA[i] = arr.Count(f => f == arr[i]);
                //Console.Write(freqA[i]);
            }
           
        }
        public static void Frequency(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int freq = arr.Count(f => f == arr[i]);
                if (i == 0)
                {
                    Console.WriteLine("Number {0} occurs {1} times", arr[i], freq);
                }
                else if (arr[i] != arr[i - 1])
                {
                    Console.WriteLine("Number {0} occurs {1} times", arr[i], freq);
                }
            }
        }
        
        private static double Median(int[] arr)
        {
            double median;

            if (arr.Length % 2 == 0)
            {
                median = (arr[(arr.Length - 1) / 2] + arr[arr.Length / 2]) / 2.0;
            }
            else
            {
                median = arr[(arr.Length / 2)];
            }
            return median;
        }

        private static double SumAll(int[] arr)
        {
            int sumA = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sumA += arr[i];
            }
            return sumA;
        }

        private static void ShowArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Index = " + i + "  , value = " + arr[i]);
            }
        }
    }
}
