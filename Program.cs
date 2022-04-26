using System;
using System.Diagnostics;


namespace Projecto_sorting
{   
    public class SortingArray
    {
        public int[] array;
        public int[] arrayCreciente;
        public int[] arrayDecreciente;
        
        public SortingArray(int elements, Random random)
        {
            array = new int[elements];
            arrayCreciente = new int[elements];
            arrayDecreciente = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                array[i] = random.Next();
            }
            Array.Copy(array, arrayCreciente, elements);
            Array.Sort(arrayCreciente);
            Array.Copy(arrayCreciente, arrayDecreciente, elements);
            Array.Reverse(arrayDecreciente);
        }
        public void Sort(Action<int[]> func)
        {
            Stopwatch time = new Stopwatch();
            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Initial: " + time.ElapsedMilliseconds +"ms " +time.ElapsedTicks+"Ticks");

            time.Reset();

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Increasing: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + "Ticks");

            time.Reset();

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Decreasing: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + "Ticks");
        }
        public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < array.Length-1; j++)
                {
                    if(array[j] > array[j+1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        public void BubbleSortEarlyExit(int[] array)
        {
            bool ordered = true;
            for (int i = 0; i < array.Length-1; i++)
            {
                ordered = true;
                for (int j = 0; j < array.Length-1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        ordered = false;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
                if (ordered)
                {
                    return;
                }
            }
        }
        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        public void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = QuickSortPivot(array, left, right);
                QuickSort(array, left, pivot);
                QuickSort(array, pivot+1, right);
            }
        }
        public int QuickSortPivot(int[] array, int left, int right)
        {
            int pivot = array[(left + right) / 2];
            while (true)
            {
                while (array[left] < pivot)
                {
                    left++;
                }
                while (array[right] > pivot)
                {
                    right--;
                }
                if(left >= right)
                {
                    return left;
                }
                else
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
            }
        }
        public void Sort1(int[] array)
        {

        }
        public void Sort2(int[] array)
        {

        }
        public void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                int key = array[i];
                for (int j =i; j > 0 && array[ j-1 ]>key; j--)
                {
                    array[j] = array[j - 1];
                    array[j] = key;

                }
            }
        }
        public int[] SortArray(int[] array,int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                SortArray(array, left, middle);
                SortArray(array, middle + 1, right);
                MergeSort(array, left, middle, right);
            }
            return array;
        }
        public void MergeSort(int[] array)
        {
            SortArray(array, 0, array.Length - 1);
        }
        public void MergeSort(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("How many elments do you want?");
             int elements = int.Parse(Console.ReadLine());

            Console.WriteLine("What seed do you want to use");
            int seed = int.Parse(Console.ReadLine());
            
            Random random = new Random();
            SortingArray array = new SortingArray(elements,random);
            Console.WriteLine("");
            Console.WriteLine("BubleSort");
            Console.WriteLine("");
            array.Sort(array.BubbleSort);
            Console.WriteLine("");
            Console.WriteLine("BubleSortEarly");
            Console.WriteLine("");
            array.Sort(array.BubbleSortEarlyExit);
            Console.WriteLine("");
            Console.WriteLine("QuickSort");
            Console.WriteLine("");
            array.Sort(array.QuickSort);
            Console.WriteLine("");
            Console.WriteLine("IsertionSort");
            Console.WriteLine("");
            array.Sort(array.InsertionSort);
            Console.WriteLine("");
            Console.WriteLine("MergeSort");
            Console.WriteLine("");
            array.Sort(array.MergeSort);

        }
    }
}
