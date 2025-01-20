/*
Interpolation Search Algorithm Notes:
----------------------------------
1. Time Complexity:
   - Best Case: O(1)
   - Average Case: O(log(log n)) for uniform distribution
   - Worst Case: O(n) for exponential distributions
2. Space Complexity: O(1)
3. Requirements:
   - Array must be sorted
   - Values should be uniformly distributed for best performance
4. Probe Formula:
   pos = low + ((target - arr[low]) * (high - low)) / (arr[high] - arr[low])
*/

using System;

class InterpolationSearch
{
    public static int Search(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high && target >= arr[low] && target <= arr[high])
        {
            if (low == high)
            {
                if (arr[low] == target) return low;
                return -1;
            }

            int pos = low + ((target - arr[low]) * (high - low))
                         / (arr[high] - arr[low]);

            if (arr[pos] == target)
                return pos;

            if (arr[pos] < target)
                low = pos + 1;
            else
                high = pos - 1;
        }
        return -1;  
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter size of sorted array: ");
            int size = int.Parse(Console.ReadLine());

            int[] arr = new int[size];
            Console.Write("Enter {0} numbers (uniformly distributed): ", size);
            string[] inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            Console.Write("Enter number to search: ");
            int target = int.Parse(Console.ReadLine());

            int result = Search(arr, target);

            if (result != -1)
                Console.WriteLine("Found {0} at position {1}", target, result);
            else
                Console.WriteLine("{0} not found in array", target);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}