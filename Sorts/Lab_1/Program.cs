using System;
using Lab_1.Properties.Sorts;
using Lab_1.Properties.Utils;

namespace Lab_1
{
    public class Program
    {
        public delegate void SortMethod(int[] array, int leftIndex, int rightIndex);
        public delegate void SortHybridMethod(int[] array, int leftIndex, int rightIndex, int k);
        static void Main()
        {
            int[] arrayToInsertionSort = Utils.CreateRandomArray(10, 1000);
            int[] arrayToQuickSort = Utils.CreateRandomArray(10, 1000);
            int[] arrayToMergeSort = Utils.CreateRandomArray(10, 1000);
            
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Неотсортированный массив для сотрировки вставками:");
            Utils.Display(arrayToInsertionSort);
            Console.WriteLine("Неотсортированный массив для быстрой сортировки :");
            Utils.Display(arrayToQuickSort);
            Console.WriteLine("Неотсортированный массив для сортировки слиянием:");
            Utils.Display(arrayToMergeSort);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\n");
            
            InsertionSort.DoInsertionSort(arrayToInsertionSort, 0, arrayToInsertionSort.Length - 1);
            QuickSort.DoQuickSort(arrayToQuickSort, 0, arrayToQuickSort.Length - 1);
            MergeSort.DoMergeSort(arrayToMergeSort, 0, arrayToMergeSort.Length - 1);
            
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Отсортированный массив для сотрировки вставками:");
            Utils.Display(arrayToInsertionSort);
            Console.WriteLine("Отсортированный массив для быстрой сортировки :");
            Utils.Display(arrayToQuickSort);
            Console.WriteLine("Отсортированный массив для сортировки слиянием:");
            Utils.Display(arrayToMergeSort);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("\n");
            
            SortMethod sortMethod = QuickSort.DoQuickSort;
            double timeForQuick = Utils.CountTimeForManySorts(100, 100000, 1000000, sortMethod);
            Console.WriteLine("Для быстрой сортировки:");
            Console.WriteLine($"Время: {timeForQuick}\n");
            
            
            sortMethod = MergeSort.DoMergeSort;
            double timeForMerge = Utils.CountTimeForManySorts(100, 100000, 1000000, sortMethod);
            Console.WriteLine("Для сортировки слиянием:");
            Console.WriteLine($"Время: {timeForMerge}\n");
            
            
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Для гибридной быстрой сортировки:");
            SortHybridMethod sortHybridMethod = QuickSort.DoHybridQuickSort;
            (int optimalQuickSortK, double timeForQuickSortK) = Utils.FindOptimalElement(100, 100000, 1000000, sortHybridMethod);
            Console.WriteLine($"Оптимальное k: {optimalQuickSortK}\nВремя: {timeForQuickSortK}\n");
            
            
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Для гибридной сортировки слиянием:");
            sortHybridMethod = MergeSort.DoHybridMergeSort;
            (int optimalMergeSortK, double timeForMergeSortK) = Utils.FindOptimalElement(100, 100000, 1000000, sortHybridMethod);
            Console.WriteLine($"Оптимальное k: {optimalMergeSortK}\nВремя: {timeForMergeSortK}\n");
        }
    }
}