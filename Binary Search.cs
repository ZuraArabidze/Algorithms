using System;

class BinarySearch
{
    public static void Main(string[] args)
    {
        Console.Write("Enter size of sorted array: ");
        int size = int.Parse(Console.ReadLine());

        int[] arr = new int[size];
        Console.Write("Enter {0} numbers in sorted order: ", size);
        string[] inputs = Console.ReadLine().Split(' ');

        for (int i = 0; i < size; i++)
        {
            arr[i] = int.Parse(inputs[i]);
        }

        Console.Write("Enter number to search: ");
        int target = int.Parse(Console.ReadLine());

        int result = Search(arr, target);

        if (result != -1)
        {
            Console.WriteLine("Found {0} at position {1}", target, result);
        }
        else
        {
            Console.WriteLine("{0} not found in array", target);
        }
    }

    public static int Search(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
            {
                return mid;
            }

            if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
}