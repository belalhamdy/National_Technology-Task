using System;

namespace National_Technology
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 25; // number of dates for testing

            Date[] data = new Date[N];

            Random rnd = new Random();
            for (int i = 0; i < N; ++i) data[i] = new Date(rnd.Next(1, 29), rnd.Next(1, 13), rnd.Next(1900, 2100));

            Console.WriteLine();
            Console.WriteLine("Array before sorting:\n\n");
            Console.WriteLine();
            Console.WriteLine();

            // printing in formatted mode
            Console.WriteLine("{0,-15} {1,5}\n", "Date", "Days in Year");
            for (int idx = 0; idx < N; idx++)
                Console.WriteLine("{0,-15} {1,5}", data[idx], data[idx].YearDays());

            SelectionSort(data);

            Console.WriteLine();
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Array after sorting:\n\n");
            Console.WriteLine();
            Console.WriteLine();

            // printing in formatted mode
            Console.WriteLine("{0,-15} {1,5}\n", "Date", "Days in Year");
            for (int idx = 0; idx < N; idx++)
                Console.WriteLine("{0,-15} {1,5}", data[idx], data[idx].YearDays());

        }
        /// <summary>
        /// Implementation of selection sort algorithm to sort array of dates and takes the array by reference
        /// </summary>
        /// <param array of dates="data"></param>
        static void SelectionSort(Date[] data)
        {
            int size = data.Length;

            int minimum;
            Date temp;

            for (int idx = 0; idx < size - 1; idx++)
            {
                minimum = idx;
                for (int j = idx + 1; j < size; j++) if (data[j] < data[minimum])  minimum = j; // gets the minimum element

                // Swap the minimum
                temp = data[minimum];
                data[minimum] = data[idx];
                data[idx] = temp;
            }
        }
    }
}
