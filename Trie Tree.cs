using System;
using System.Collections.Generic;

/*
TRIE TREE EXPLANATION
---------------------
A Trie (pronounced "try") is a tree-based data structure used to store a dynamic set of strings.
It's particularly useful for fast retrieval of words in dictionaries, autocomplete, and spell checking.

Time Complexity:
- Insertion: O(L) where L is the length of the word
- Search: O(L) where L is the length of the word
- Deletion: O(L) where L is the length of the word
- Prefix Search: O(L) where L is the length of the prefix

Space Complexity:
- Worst case: O(alphabet_size * L * N)
  where alphabet_size is the number of possible characters (e.g., 26 for lowercase English letters),
  L is the average length of words, and N is the number of words.
- In practice, it's usually much less due to prefix sharing.

How it Works:
1. Each node in the trie represents a single character
2. The path from root to a node forms a prefix/word
3. Each node may have multiple children (one for each character in the alphabet)
4. Words are stored by marking the last character node as an "end of word"
5. Common prefixes are shared, saving space compared to storing each word separately

Key Advantages:
- Fast lookups (O(L) where L is word length, regardless of dictionary size)
- Efficient prefix searching (great for autocomplete)
- Space-efficient for words with common prefixes
- Can be extended for fuzzy matching and other text processing tasks
*/

class Program
{
    static void Main(string[] args)
    {
        Trie trie = new Trie();

        while (true)
        {
            Console.WriteLine("\nTrie Operations:");
            Console.WriteLine("1. Insert a word");
            Console.WriteLine("2. Search for a word");
            Console.WriteLine("3. Check if any word starts with prefix");
            Console.WriteLine("4. Delete a word");
            Console.WriteLine("5. Show all words");
            Console.WriteLine("6. Auto-complete a prefix");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter word to insert: ");
                    string wordToInsert = Console.ReadLine();
                    trie.Insert(wordToInsert);
                    Console.WriteLine($"'{wordToInsert}' inserted successfully.");
                    break;

                case 2:
                    Console.Write("Enter word to search: ");
                    string wordToSearch = Console.ReadLine();
                    if (trie.Search(wordToSearch))
                        Console.WriteLine($"'{wordToSearch}' found in trie.");
                    else
                        Console.WriteLine($"'{wordToSearch}' not found in trie.");
                    break;

                case 3:
                    Console.Write("Enter prefix to check: ");
                    string prefixToCheck = Console.ReadLine();
                    if (trie.StartsWith(prefixToCheck))
                        Console.WriteLine($"There are words that start with '{prefixToCheck}'");
                    else
                        Console.WriteLine($"No words start with '{prefixToCheck}'");
                    break;

                case 4:
                    Console.Write("Enter word to delete: ");
                    string wordToDelete = Console.ReadLine();
                    trie.Delete(wordToDelete);
                    Console.WriteLine($"'{wordToDelete}' deleted (if it existed).");
                    break;

                case 5:
                    List<string> allWords = trie.GetAllWords();
                    if (allWords.Count == 0)
                        Console.WriteLine("The trie is empty.");
                    else
                    {
                        Console.WriteLine("All words in the trie:");
                        foreach (string word in allWords)
                            Console.WriteLine($"  {word}");
                    }
                    break;

                case 6:
                    Console.Write("Enter prefix for auto-complete: ");
                    string autoCompletePrefix = Console.ReadLine();
                    List<string> suggestions = trie.AutoComplete(autoCompletePrefix);
                    if (suggestions.Count == 0)
                        Console.WriteLine($"No words start with '{autoCompletePrefix}'");
                    else
                    {
                        Console.WriteLine($"Words that start with '{autoCompletePrefix}':");
                        foreach (string word in suggestions)
                            Console.WriteLine($"  {word}");
                    }
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool IsEndOfWord { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }
    }

    class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }
        public void Insert(string word)
        {
            TrieNode current = root;

            foreach (char c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    current.Children[c] = new TrieNode();
                }
                current = current.Children[c];
            }

            current.IsEndOfWord = true;
        }
        private TrieNode FindNode(string word)
        {
            TrieNode current = root;

            foreach (char c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return null;
                }
                current = current.Children[c];
            }

            return current;
        }
        public bool Search(string word)
        {
            TrieNode node = FindNode(word);
            return node != null && node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            return FindNode(prefix) != null;
        }

        private bool DeleteRecursive(TrieNode current, string word, int index)
        {
            if (index == word.Length)
            {
                if (!current.IsEndOfWord)
                {
                    return false;
                }
                current.IsEndOfWord = false;
                return current.Children.Count == 0;
            }

            char c = word[index];
            if (!current.Children.ContainsKey(c))
            {
                return false;
            }

            TrieNode child = current.Children[c];
            bool shouldDeleteChild = DeleteRecursive(child, word, index + 1);

            if (shouldDeleteChild)
            {
                current.Children.Remove(c);
                return !current.IsEndOfWord && current.Children.Count == 0;
            }

            return false;
        }

        public void Delete(string word)
        {
            DeleteRecursive(root, word, 0);
        }
    
        public List<string> GetAllWords()
        {
            List<string> words = new List<string>();
            GetAllWordsRecursive(root, "", words);
            return words;
        }

        private void GetAllWordsRecursive(TrieNode node, string currentWord, List<string> words)
        {
            if (node.IsEndOfWord)
            {
                words.Add(currentWord);
            }

            foreach (var entry in node.Children)
            {
                char c = entry.Key;
                TrieNode child = entry.Value;
                GetAllWordsRecursive(child, currentWord + c, words);
            }
        }
        public List<string> AutoComplete(string prefix)
        {
            List<string> results = new List<string>();
            TrieNode node = FindNode(prefix);

            if (node != null)
            {
                GetAllWordsRecursive(node, prefix, results);
            }

            return results;
        }
    }
}