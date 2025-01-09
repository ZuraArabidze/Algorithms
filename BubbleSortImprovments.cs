using System;

//Cocktail Sort:

//Performs forward and backward passes to improve sorting efficiency compared to Bubble Sort.
//Handles edge cases more efficiently, especially with elements at the beginning and end of the array.
//Time Complexity: O(n²)

//Odd-Even Sort:

//Alternates between sorting odd-indexed and even-indexed elements.
//Odd Pass: Compares elements at odd positions with the next even position.
//Even Pass: Compares elements at even positions with the next odd position.
//Optimized for arrays where odd and even indexed elements tend to be misordered.
//Time Complexity: O(n²)

//Comb Sort:

//Gap Shrinking: Starts with a large gap and reduces it using a shrink factor(typically 1.2473309) to speed up the sorting process.
//Efficient for Larger Arrays: The larger initial gap helps to move elements that are far apart, making the sorting process more efficient than Bubble Sort.
//Time Complexity: On average, O(n log n), but in the worst case, it can degrade to O(n²) if the array is in reverse order.
class BubbleSortImprovments
{
    static void Main()
    {
        try
        {
            int size = GetValidArraySize();
            int[] arr = GetArrayElements(size);

            Console.WriteLine("\nOriginal array:");
            PrintArray(arr);

            //CocktailSort(arr);

            //Console.WriteLine("\nSorted array with Cocktail Sort:");
            //PrintArray(arr);

            //OddEvenSort(arr);

            //Console.WriteLine("\nSorted array with Odd Even Sort:");
            //PrintArray(arr);

            CombSort(arr);
            Console.WriteLine("\nSorted array with Comb Sort:");
            PrintArray(arr);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void CocktailSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n / 2; i++)
        {
            bool swapped = false;

            for (int j = i; j < n - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            for (int j = n - 2 - i; j >= i; j--)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    static void OddEvenSort(int[] arr)
    {
        int n = arr.Length;
        bool sorted = false;

        while (!sorted)
        {
            sorted = true;

            for (int i = 1; i < n - 1; i += 2)
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    sorted = false;
                }
            }

            for (int i = 0; i < n - 1; i += 2)
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    sorted = false;
                }
            }
        }
    }

    static void CombSort(int[] arr)
    {
        int n = arr.Length;
        double gap = n;
        const double shrink = 1.2473309; 
        bool swapped = true;

        while (gap > 1 || swapped)
        {
            gap = Math.Max(1, gap / shrink); 
            swapped = false;

            for (int i = 0; i + (int)gap < n; i++)
            {
                int j = i + (int)gap;

                if (arr[i] > arr[j])
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    swapped = true;
                }
            }
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
