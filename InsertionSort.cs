using System;

//Time complexity: O(n²) in worst and average cases, O(n) in best case (nearly sorted array)
//Space complexity: O(1) as it sorts in-place
//Stable sorting algorithm
//Good for small data sets or nearly sorted arrays
class InsertionSort
{
    static void Main()
    {
        try
        {
            int size = GetValidArraySize();
            int[] arr = GetArrayElements(size);

            Console.WriteLine("\nOriginal array:");
            PrintArray(arr);

            Sort(arr);

            Console.WriteLine("\nSorted array:");
            PrintArray(arr);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void Sort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
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
