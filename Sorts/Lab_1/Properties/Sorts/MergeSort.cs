namespace Lab_1.Properties.Sorts
{
    public static class MergeSort
    {
        public static void DoHybridMergeSort(int[] array, int leftIndex, int rightIndex, int k)
        {
            if (rightIndex - leftIndex + 1 <= k) //3    4?  if
            {
                InsertionSort.DoInsertionSort(array, leftIndex, rightIndex); //1
                return; //1
            }
            
            if (leftIndex < rightIndex) //1    2?  if
            {
                int middleIndex = (leftIndex + rightIndex) / 2; //4
                DoHybridMergeSort(array, leftIndex, middleIndex, k); //1
                DoHybridMergeSort(array, middleIndex + 1, rightIndex, k); //1 
                DoMerge(array, leftIndex, middleIndex, rightIndex); //1
            }
        }
        
        public static void DoMergeSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex) //1     2?  if
            {
                int middleIndex = (leftIndex + rightIndex) / 2; //4
                DoMergeSort(array, leftIndex, middleIndex); //1
                DoMergeSort(array, middleIndex + 1, rightIndex); //1 
                DoMerge(array, leftIndex, middleIndex, rightIndex); //1
            }
        }


        static void DoMerge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            
            int left = leftIndex; //2
            int right = middleIndex + 1; //3
            int[] sortedSubArray = new int[rightIndex - leftIndex + 1]; //4
            int k = 0; //2
            
            while (left <= middleIndex && right <= rightIndex) //3     4? while
            {
                if (array[left] > array[right]) //3   4? if
                {
                    sortedSubArray[k] = array[right]; //3
                    right++; //2
                }
                else
                {
                    sortedSubArray[k] = array[left]; //3
                    left++; //2
                }
                k++; //2
            }

            while (left <= middleIndex) //1   2?
            {
                sortedSubArray[k] = array[left]; //3
                k++; //2
                left++; //2
            }
            while (right <= rightIndex) //1    2?
            {
                sortedSubArray[k] = array[right]; //3
                k++; //2
                right++; //2
            }

            for (left = leftIndex, k = 0; left <= rightIndex; left++, k++) //7     8?
            {
                array[left] = sortedSubArray[k]; //3
            }
        }
    }
}