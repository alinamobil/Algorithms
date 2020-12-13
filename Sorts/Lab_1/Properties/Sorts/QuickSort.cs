namespace Lab_1.Properties.Sorts
{
    public static class QuickSort
    {
       //метод для обмена элементов массива
        static void Swap(ref int x, ref int y)
        {
            int t = x; //2
            x = y; //1
            y = t; //1
        }
        public static void DoHybridQuickSort(int[] array, int leftIndex, int rightIndex, int k)
        {
            if (rightIndex - leftIndex + 1 <= k) //3    4?
            {
                InsertionSort.DoInsertionSort(array, leftIndex, rightIndex);//1
                return;//1
            }
            if (leftIndex < rightIndex) //1     2?
            {
                int middleIndex = FindBorder(array, leftIndex, rightIndex); //3
                DoHybridQuickSort(array, leftIndex, middleIndex, k); //1
                DoHybridQuickSort(array, middleIndex + 1, rightIndex, k); //1
            }
        }
        
        public static void DoQuickSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex) //2
            {
                int middleIndex = FindBorder(array, leftIndex, rightIndex); //3
                DoQuickSort(array, leftIndex, middleIndex); //1
                DoQuickSort(array, middleIndex + 1, rightIndex); //1
            }
        }

        static int FindBorder(int[] array, int leftIndex, int rightIndex)
        {
            int pivot = array[(leftIndex + rightIndex) / 2]; //4  5? int + array + "+" + /
            int i = leftIndex - 1; //3
            int j = rightIndex + 1; //3
            while (true) //1?
            {
                do 
                {
                    i++; //2
                } while (array[i] < pivot); //2    3?

                do 
                {
                    j--; //2
                } while (array[j] > pivot); //2    3?

                if (i < j) //2
                    Swap(ref array[i], ref array[j]); //3
                else return j; //2   ???
            }
        }

        
    }
}
