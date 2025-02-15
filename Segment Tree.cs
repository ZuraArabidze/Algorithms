using System;

/*
SEGMENT TREE EXPLANATION
------------------------
A Segment Tree is a data structure for efficiently performing range queries and updates on an array.

Time Complexity:
- Construction: O(n) - we build the tree bottom-up
- Query: O(log n) - we traverse at most 4 log n nodes in the worst case
- Update: O(log n) - we update log n nodes from leaf to root

Space Complexity:
- O(4n) = O(n) - we need an array of size 4n to store the tree (worst case)

How it Works:
1. We build a binary tree where:
   - Leaf nodes contain individual array elements
   - Each internal node stores the result of an operation (e.g., sum, min, max)
     on its children's values
   - The root represents the result for the entire array

2. The tree is typically represented as an array where:
   - For a node at index i:
     - Its left child is at index 2i
     - Its right child is at index 2i + 1
     - Its parent is at index i/2
   (Note: Some implementations use 0-based indexing with 2i+1 and 2i+2)

3. Each node represents a segment of the original array:
   - Root represents the entire array [0...n-1]
   - Each node represents segment [start...end]
   - Left child represents [start...mid]
   - Right child represents [mid+1...end]

Key Benefits:
- Allows for efficient range queries (sum, min, max, etc.)
- Supports efficient individual element updates
- Can be adapted for various operations (not just sum)
*/

class Program
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

        SegmentTree segTree = new SegmentTree(arr);

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

                int result = segTree.Query(left, right);
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

                arr[index] = newValue;
                segTree.Update(index, newValue);
                Console.WriteLine("Value updated successfully!");
            }
        }
    }
    class SegmentTree
    {
        private int[] tree;  
        private int n;      

        public SegmentTree(int[] arr)
        {
            n = arr.Length;
            int treeSize = 4 * n;
            tree = new int[treeSize];
            Build(arr, 1, 0, n - 1);
        }

        private void Build(int[] arr, int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = arr[start];
                return;
            }

            int mid = (start + end) / 2;

            Build(arr, node * 2, start, mid);        
            Build(arr, node * 2 + 1, mid + 1, end);  
            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        public int Query(int queryStart, int queryEnd)
        {
            return QueryRecursive(1, 0, n - 1, queryStart, queryEnd);
        }

        private int QueryRecursive(int node, int start, int end, int queryStart, int queryEnd)
        {
            if (queryEnd < start || queryStart > end)
                return 0;

            if (queryStart <= start && end <= queryEnd)
                return tree[node];

            int mid = (start + end) / 2;
            int leftSum = QueryRecursive(node * 2, start, mid, queryStart, queryEnd);
            int rightSum = QueryRecursive(node * 2 + 1, mid + 1, end, queryStart, queryEnd);

            return leftSum + rightSum;
        }

        public void Update(int index, int newValue)
        {
            UpdateRecursive(1, 0, n - 1, index, newValue);
        }

        private void UpdateRecursive(int node, int start, int end, int index, int newValue)
        {
            if (start == end)
            {
                tree[node] = newValue;
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
                UpdateRecursive(node * 2, start, mid, index, newValue);
            else
                UpdateRecursive(node * 2 + 1, mid + 1, end, index, newValue);

            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }
    }
}