/* 
Tree Traversals:
1. Inorder (Left-Root-Right):
   - Visits left subtree
   - Visits root
   - Visits right subtree
   - Produces sorted output

2. Preorder (Root-Left-Right):
   - Visits root first
   - Then left subtree
   - Then right subtree
   - Useful for creating a copy of the tree

3. Postorder (Left-Right-Root):
   - Visits left subtree
   - Visits right subtree
   - Visits root last
   - Useful for deleting the tree

Time Complexities:
- Insertion: O(log n) average, O(n) worst
- Deletion: O(log n) average, O(n) worst
- Search: O(log n) average, O(n) worst

Space Complexity: O(h), where h is tree height
*/


using System;
public class Node
{
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

public class BST
{
    public static void Main(string[] args)
    {
        BST bst = new BST();

        int[] values = { 50, 30, 70, 20, 40, 60, 80 };
        foreach (int val in values)
        {
            bst.Insert(val);
        }

        bst.InorderTraversal();
        bst.PreorderTraversal();
        bst.PostorderTraversal();

        Console.WriteLine($"\nMinimum value: {bst.FindMin()}");
        Console.WriteLine($"Maximum value: {bst.FindMax()}");

        Console.WriteLine("\nDeleting 30");
        bst.Delete(30);
        bst.InorderTraversal();
    }

    private Node root;

    public BST()
    {
        root = null;
    }

    public void Insert(int data)
    {
        root = InsertRecursive(root, data);
    }

    private Node InsertRecursive(Node current, int data)
    {
        if (current == null)
        {
            return new Node(data);
        }

        if (data < current.Data)
        {
            current.Left = InsertRecursive(current.Left, data);
        }
        else if (data > current.Data)
        {
            current.Right = InsertRecursive(current.Right, data);
        }

        return current;
    }

    public int FindMin()
    {
        if (root == null)
        {
            throw new InvalidOperationException("Tree is empty");
        }
        return FindMinRecursive(root);
    }

    private int FindMinRecursive(Node current)
    {
        return current.Left == null ? current.Data : FindMinRecursive(current.Left);
    }

    public int FindMax()
    {
        if (root == null)
        {
            throw new InvalidOperationException("Tree is empty");
        }
        return FindMaxRecursive(root);
    }

    private int FindMaxRecursive(Node current)
    {
        return current.Right == null ? current.Data : FindMaxRecursive(current.Right);
    }

    public void Delete(int data)
    {
        root = DeleteRecursive(root, data);
    }

    private Node DeleteRecursive(Node current, int data)
    {
        if (current == null)
        {
            return null;
        }

        // Find the node to delete
        if (data < current.Data)
        {
            current.Left = DeleteRecursive(current.Left, data);
        }
        else if (data > current.Data)
        {
            current.Right = DeleteRecursive(current.Right, data);
        }
        else
        {
            // Node with only one child or no child
            if (current.Left == null)
            {
                return current.Right;
            }
            else if (current.Right == null)
            {
                return current.Left;
            }

            // Node with two children
            current.Data = FindMinRecursive(current.Right);
            current.Right = DeleteRecursive(current.Right, current.Data);
        }

        return current;
    }

    // Inorder Traversal (Left-Root-Right)
    public void InorderTraversal()
    {
        Console.WriteLine("\nInorder Traversal:");
        InorderRecursive(root);
        Console.WriteLine();
    }

    private void InorderRecursive(Node current)
    {
        if (current != null)
        {
            InorderRecursive(current.Left);
            Console.Write(current.Data + " ");
            InorderRecursive(current.Right);
        }
    }

    // Preorder Traversal (Root-Left-Right)
    public void PreorderTraversal()
    {
        Console.WriteLine("\nPreorder Traversal:");
        PreorderRecursive(root);
        Console.WriteLine();
    }

    private void PreorderRecursive(Node current)
    {
        if (current != null)
        {
            Console.Write(current.Data + " ");
            PreorderRecursive(current.Left);
            PreorderRecursive(current.Right);
        }
    }

    // Postorder Traversal (Left-Right-Root)
    public void PostorderTraversal()
    {
        Console.WriteLine("\nPostorder Traversal:");
        PostorderRecursive(root);
        Console.WriteLine();
    }

    private void PostorderRecursive(Node current)
    {
        if (current != null)
        {
            PostorderRecursive(current.Left);
            PostorderRecursive(current.Right);
            Console.Write(current.Data + " ");
        }
    }
}

