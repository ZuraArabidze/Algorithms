using System;
using System.Linq;

//Time complexity: O(n log n) in all cases (best, average, and worst)
//Space complexity: O(n) - requires extra space for temporary arrays
//Stable sorting algorithm
//Divide and conquer algorithm
class MergeSort
{
    static void Main()
    {
        try
        {
            int size = GetValidArraySize();
            int[] arr = GetArrayElements(size);
            Console.WriteLine("\nOriginal array:");
            PrintArray(arr);
            Sort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nSorted array:");
            PrintArray(arr);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            // Find the middle point
            int middle = left + (right - left) / 2;

            // Sort first and second halves
            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);

            // Merge the sorted halves
            Merge(arr, left, middle, right);
        }
    }

    static void Merge(int[] arr, int left, int middle, int right)
    {
        // Calculate sizes of two subarrays to be merged
        int n1 = middle - left + 1;
        int n2 = right - middle;

        // Create temporary arrays
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temporary arrays
        for (int i = 0; i < n1; i++)
            leftArray[i] = arr[left + i];
        for (int j = 0; j < n2; j++)
            rightArray[j] = arr[middle + 1 + j];

        // Merge the temporary arrays

        // Initial indexes of first and second subarrays
        int iLeft = 0, iRight = 0;

        // Initial index of merged subarray
        int k = left;

        // Compare and merge elements
        while (iLeft < n1 && iRight < n2)
        {
            if (leftArray[iLeft] <= rightArray[iRight])
            {
                arr[k] = leftArray[iLeft];
                iLeft++;
            }
            else
            {
                arr[k] = rightArray[iRight];
                iRight++;
            }
            k++;
        }

        // Copy remaining elements of leftArray[] if any
        while (iLeft < n1)
        {
            arr[k] = leftArray[iLeft];
            iLeft++;
            k++;
        }

        // Copy remaining elements of rightArray[] if any
        while (iRight < n2)
        {
            arr[k] = rightArray[iRight];
            iRight++;
            k++;
        }
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }

    static int GetValidArraySize()
    {
        while (true)
        {
            Console.Write("Enter the number of elements (1-10000): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0 && n <= 10000)
            {
                return n;
            }
            Console.WriteLine("Invalid input. Please enter a valid number between 1 and 10000.");
        }
    }

    static int[] GetArrayElements(int size)
    {
        while (true)
        {
            Console.WriteLine($"Enter {size} integers separated by spaces:");
            string[] inputs = Console.ReadLine().Split(' ');
            if (inputs.Length != size)
            {
                Console.WriteLine($"Please enter exactly {size} numbers.");
                continue;
            }
            try
            {
                return inputs.Select(int.Parse).ToArray();
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter valid integers separated by spaces.");
            }
        }
    }
}