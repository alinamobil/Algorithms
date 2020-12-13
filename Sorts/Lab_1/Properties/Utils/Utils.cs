using System;

namespace Lab_1.Properties.Utils
{
    public class Utils
    {
        public static (int, double) FindOptimalElement(int amountOfArrays, int sizeOfArray, int maxValueOfElement, Program.SortHybridMethod sortMethod)
        {
            int k = 1;

            double minimalTime = Double.MaxValue;
            int OptimalElement = -1;
            double currentTime = 0;
            
            int[][] arrayOfArrays = new int[amountOfArrays][];
            
            for (int i = 0; i < amountOfArrays; i++) 
                arrayOfArrays[i] = CreateRandomArray(sizeOfArray, maxValueOfElement);

            while (k <= 10)
            {
                for (int i = 0; i < amountOfArrays; i++)
                    currentTime += CountTimeForOneSort((int[])arrayOfArrays[i].Clone(), k, sortMethod);

                currentTime /= amountOfArrays;
                
                Console.WriteLine($"k = {k}, time = {currentTime}");
            
                if (minimalTime > currentTime)
                {
                    minimalTime = currentTime;
                    OptimalElement = k;
                }
                
                currentTime = 0;
                k++;
            }

            return (OptimalElement, minimalTime);
        }

        public static double CountTimeForManySorts(int amountOfArrays, int sizeOfArray, int maxValueOfElement, Program.SortMethod sortMethod)
        {
            double time = 0;
            
            int[][] arrayOfArrays = new int[amountOfArrays][];
            
            for (int i = 0; i < amountOfArrays; i++) 
                arrayOfArrays[i] = CreateRandomArray(sizeOfArray, maxValueOfElement);
            
            for (int i = 0; i < amountOfArrays; i++)
                time += CountTimeForOneSort((int[])arrayOfArrays[i].Clone(), sortMethod);

            time /= amountOfArrays;

            return time;
        }
        static double CountTimeForOneSort(int[] arrayToSort, int k, Program.SortHybridMethod sortMethod)
        {
            long startTime = DateTime.Now.Ticks;
            
            sortMethod(arrayToSort, 0, arrayToSort.Length - 1, k);
            
            long endTime = DateTime.Now.Ticks - startTime;
            return endTime;
        }
        
        static double CountTimeForOneSort(int[] arrayToSort, Program.SortMethod sortMethod)
        {
            long startTime = DateTime.Now.Ticks;
            
            sortMethod(arrayToSort, 0, arrayToSort.Length - 1);
            
            long endTime = DateTime.Now.Ticks - startTime;
            return endTime;
        }
        
        

        public static int[] CreateRandomArray(int sizeOfArray, int maxValueOfElement)
        {
            int[] array = new int[sizeOfArray];
            Random random = new Random();
            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = random.Next(0, maxValueOfElement);
            }
            return array;
        }

        public static void Display(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            
            Console.WriteLine();
        }
    }
}