using System;

/*
FENWICK TREE (BINARY INDEXED TREE) EXPLANATION
---------------------------------------------
A Fenwick Tree is a data structure that efficiently updates elements and calculates prefix sums in an array.

Time Complexity:
- Construction: O(n log n) - we perform n updates, each taking O(log n)
- Update: O(log n) - we update log n nodes in the tree
- Query: O(log n) - we access log n nodes to get the sum
- Range Query: O(log n) - we perform two prefix sum queries

Space Complexity:
- O(n) - we need an array of size n+1 to store the tree

How it Works:
1. The tree uses a binary representation of indices to store partial sums
2. Each index i in the tree is responsible for elements from i-LSB(i)+1 to i
   where LSB(i) is the Least Significant Bit of i
3. Updates and queries use LSB manipulation to traverse the tree efficiently

Key Concepts:
- 1-based indexing is used internally (we convert 0-based indices from user input)
- LSB is calculated using: index & (-index)
- Parent is found by removing LSB: index - (index & (-index))
- Next node is found by adding LSB: index + (index & (-index))
*/

class BIT
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

        FenwickTree fenwick = new FenwickTree(n);
        fenwick.BuildTree(arr);

        while (true)
        {
            Console.WriteLine("\nChoose operation:");
            Console.WriteLine("1. Query Range Sum");
            Console.WriteLine("2. Update Value");
            Console.WriteLine("3. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 3) break;

            if (choice == 1)
            {
                Console.WriteLine("Enter range (left right):");
                string[] query = Console.ReadLine().Split(' ');
                int left = int.Parse(query[0]);
                int right = int.Parse(query[1]);

                if (left < 0 || right >= n || left > right)
                {
                    Console.WriteLine("Invalid range!");
                    continue;
                }

                int result = fenwick.GetRangeSum(left, right);
                Console.WriteLine($"Sum from index {left} to {right}: {result}");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter index and new value:");
                string[] update = Console.ReadLine().Split(' ');
                int index = int.Parse(update[0]);
                int newValue = int.Parse(update[1]);

                if (index < 0 || index >= n)
                {
                    Console.WriteLine("Invalid index!");
                    continue;
                }

                int diff = newValue - arr[index];
                arr[index] = newValue;
                fenwick.Update(index, diff);
                Console.WriteLine("Value updated successfully!");
            }
        }
    }
    class FenwickTree
    {
        private int[] tree; 
        private int size;    

        public FenwickTree(int n)
        {
            size = n + 1;
            tree = new int[size];
        }

        public void Update(int index, int val)
        {
            index++; 
            while (index < size)
            {
                tree[index] += val;
                index += index & (-index); 
            }
        }

        private int GetSum(int index)
        {
            index++;
            int sum = 0;
            while (index > 0)
            {
                sum += tree[index];
                index -= index & (-index); 
            }
            return sum;
        }

        public int GetRangeSum(int left, int right)
        {
            return GetSum(right) - GetSum(left - 1);
        }

        public void BuildTree(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Update(i, arr[i]);
            }
        }
    }
}