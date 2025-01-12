using System;
using System.Linq;

//Time complexity: O(n log n) average case, O(n^2) worst case
//Space complexity: O(log n) due to recursion stack
//Not stable sorting algorithm
//Divide and conquer algorithm
class QuickSort
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
            // Get the partition index
            int pivot = Partition(arr, left, right);

            // Sort the elements before and after partition
            Sort(arr, left, pivot - 1);
            Sort(arr, pivot + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        // Choose the rightmost element as pivot
        int pivot = arr[right];

        // Index of smaller element
        int i = left - 1;

        // Compare each element with pivot
        for (int j = left; j < right; j++)
        {
            // If current element is smaller than or equal to pivot
            if (arr[j] <= pivot)
            {
                i++; // Increment index of smaller element
                // Swap elements
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }

        // Place pivot in its correct position
        (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);

        // Return the partition index
        return i + 1;
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