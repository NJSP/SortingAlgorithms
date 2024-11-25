using System;
using System.Diagnostics;

public class SortingAlgorithms
{
    public static void Main(string[] args)
    {
        int[] array = { 64, 34, 25, 12, 22, 11, 90, 7, 55, 89 };

        Console.WriteLine("Original array:");
        PrintArray(array);

        // Test Bubble Sort
        int[] bubbleSortedArray = (int[])array.Clone();
        Stopwatch stopwatch = Stopwatch.StartNew();
        BubbleSort(bubbleSortedArray);
        stopwatch.Stop();
        Console.WriteLine("Bubble Sorted array:");
        PrintArray(bubbleSortedArray);
        Console.WriteLine("Bubble Sort elapsed time: " + stopwatch.Elapsed.TotalMilliseconds.ToString("F6") + " ms\n");

        // Test Insertion Sort
        int[] insertionSortedArray = (int[])array.Clone();
        stopwatch.Restart();
        InsertionSort(insertionSortedArray);
        stopwatch.Stop();
        Console.WriteLine("Insertion Sorted array:");
        PrintArray(insertionSortedArray);
        Console.WriteLine("Insertion Sort elapsed time: " + stopwatch.Elapsed.TotalMilliseconds.ToString("F6") + " ms\n");

        // Test Selection Sort
        int[] selectionSortedArray = (int[])array.Clone();
        stopwatch.Restart();
        SelectionSort(selectionSortedArray);
        stopwatch.Stop();
        Console.WriteLine("Selection Sorted array:");
        PrintArray(selectionSortedArray);
        Console.WriteLine("Insertion Sort elapsed time: " + stopwatch.Elapsed.TotalMilliseconds.ToString("F6") + " ms\n");

        // Test Merge Sort
        int[] mergeSortedArray = (int[])array.Clone();
        stopwatch.Restart();
        MergeSort(mergeSortedArray, 0, mergeSortedArray.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("Merge Sorted array:");
        PrintArray(mergeSortedArray);
        Console.WriteLine("Insertion Sort elapsed time: " + stopwatch.Elapsed.TotalMilliseconds.ToString("F6") + " ms\n");

        // Test Quick Sort
        int[] quickSortedArray = (int[])array.Clone();
        stopwatch.Restart();
        QuickSort(quickSortedArray, 0, quickSortedArray.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("Quick Sorted array:");
        PrintArray(quickSortedArray);
        Console.WriteLine("Insertion Sort elapsed time: " + stopwatch.Elapsed.TotalMilliseconds.ToString("F6") + " ms\n");
    }

    public static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Bubble Sort
    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap array[j] and array[j + 1]
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    // Insertion Sort
    public static void InsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            // Move elements of array[0..i-1], that are greater than key, to one position ahead of their current position
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
    }

    // Selection Sort
    public static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            // Find the minimum element in unsorted array
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap the found minimum element with the first element
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    // Merge Sort
    public static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;

            // Sort first and second halves
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);

            // Merge the sorted halves
            Merge(array, left, middle, right);
        }
    }

    private static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        // Create temporary arrays
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temporary arrays
        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, middle + 1, rightArray, 0, n2);

        // Merge the temporary arrays back into array[left..right]
        int i = 0, j = 0;
        int k = left;
        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        // Copy the remaining elements of leftArray, if any
        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        // Copy the remaining elements of rightArray, if any
        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }

    // Quick Sort
    public static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // pi is partitioning index, array[pi] is now at right place
            int pi = Partition(array, low, high);

            // Recursively sort elements before partition and after partition
            QuickSort(array, low, pi - 1);
            QuickSort(array, pi + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = (low - 1); // Index of smaller element

        for (int j = low; j < high; j++)
        {
            // If current element is smaller than or equal to pivot
            if (array[j] <= pivot)
            {
                i++;

                // Swap array[i] and array[j]
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Swap array[i + 1] and array[high] (or pivot)
        int temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;

        return i + 1;
    }
}