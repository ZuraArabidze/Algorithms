using System;


class SelectionSort
{
    static void Main()
    {
        try
        {
            int size = GetValidArraySize();
            int[] arr = GetArrayElements(size);

            Console.WriteLine("\nOriginal array:");
            PrintArray(arr);

            Selection_Sort(arr);

            Console.WriteLine("\nSorted array with Comb Sort:");
            PrintArray(arr);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void Selection_Sort(int[] arr)
    {
        int n = arr.Length;
        
        for(int i = 0; i < n - 1; i++)
        {
            int minValueIndex = i;

            for(int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minValueIndex])
                {
                    minValueIndex = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[minValueIndex];
            arr[minValueIndex] = temp;
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
