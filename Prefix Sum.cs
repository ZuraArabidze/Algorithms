using System;

class PrefixSum
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the size of the array:");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter the array elements:");
        string[] elements = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(elements[i]);
        }

        int[] prefixSum = CalculatePrefixSum(arr);

        Console.WriteLine("Enter the number of queries:");
        int q = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter queries (left right) on separate lines:");
        for (int i = 0; i < q; i++)
        {
            string[] query = Console.ReadLine().Split(' ');
            int left = int.Parse(query[0]);
            int right = int.Parse(query[1]);

            if (left < 0 || right >= n || left > right)
            {
                Console.WriteLine("Invalid range!");
                continue;
            }

            int rangeSum = GetRangeSum(prefixSum, left, right);
            Console.WriteLine($"Sum from index {left} to {right}: {rangeSum}");
        }
    }
    static int[] CalculatePrefixSum(int[] arr)
    {
        int n = arr.Length;
        int[] prefixSum = new int[n];

        prefixSum[0] = arr[0];
        for (int i = 1; i < n; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + arr[i];
        }

        return prefixSum;
    }

    static int GetRangeSum(int[] prefixSum, int left, int right)
    {
        if (left == 0)
            return prefixSum[right];
        return prefixSum[right] - prefixSum[left - 1];
    }
}