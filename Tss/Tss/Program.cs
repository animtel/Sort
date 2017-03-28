using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sort
{
    class Program
    {
        static double number;
        static void Main()
        {
            Stopwatch stopWatch = new Stopwatch();
           
//______________________________________________________________________________________________________________________________
            Random rd = new Random();
            
            int[] lol = new int[rd.Next(83992)];
            for(int j = 0; j < lol.Length; j++)
            {
                lol[j] = rd.Next(-100, 100);
            }
            Console.WriteLine(lol.Max());
            long i = lol.Length-1;
            stopWatch.Start();//Start Timer;
            InsertionSort_Recursive(i, lol);
            //lol = InsertionSort(lol);
            //lol = Merge_Sort(lol);
            //foreach (int ass in lol)
            //{
            //    Console.WriteLine(ass);
            //}
            Console.WriteLine(lol[lol.Length-1]);

//______________________________________________________________________________________________________________________________

            stopWatch.Stop();//Stop Timer and write time;

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            Console.WriteLine();
            string elapsedTime = String.Format("{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);

        }


        public static void InsertionSort_Recursive(long i, int[] array)
            {
                if (i >=0)  // n
                {
                    long j;  //n
                    int temp = array[i];//n

                    for (j = i; j <array.Length-1 && array[j + 1] > temp; j++) // сумма t_j , j=0, 
                        array[j] = array[j + 1];
                    array[j] = temp;

                    InsertionSort_Recursive(--i, array);
                }
            } //Рекурсивная сортировка вставками

        /// <summary>
        /// Не рекурсивная сортировка вставками.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] InsertionSort(int[] array)// принимает несортированный массив.(Не рекурсивная сортировка вставками)
        {

            int[] result = new int[array.Length]; // (1) нов. массив с длинной несортированного.
            for (int i = 0; i < array.Length; i++)// (n, n - длинна входного массива)
            {
                int j = i; // (n-1)
                while (j > 0 && result[j - 1] > array[i]) // (сумма t_j, j=2, n)
                {
                    result[j] = result[j - 1];  // (сумма t_j - 1 , j=2 , n)
                    j--;   // (сумма t_j - 1 , j=2, n)
                }
                result[j] = array[i]; //(n-1)
            }
            return result; //(1)
        }

        static int[] Merge_Sort(int[] array)
        {
            if (array.Length == 1)
                return array;
            int mid_point = array.Length / 2;
            return Merge(Merge_Sort(array.Take(mid_point).ToArray()), Merge_Sort(array.Skip(mid_point).ToArray()));
        }//Сортировка слиянием

        static int[] Merge(int[] mass1, int[] mass2)
        {
            long a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (long i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else //if int go for
                        merged[i] = mass1[a++];
                else
                  if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }//сортировка двух массивов при сортировке слиянием
    }
}