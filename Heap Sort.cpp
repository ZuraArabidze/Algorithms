/*
Heap Sort Algorithm Notes:
-------------------------
1. Time Complexity:
   - Best Case: O(n log n)
   - Average Case: O(n log n)
   - Worst Case: O(n log n)

2. Space Complexity: O(1) - In-place sorting

3. Heap Properties:
   - Parent Node Index: i
   - Left Child Index: 2*i + 1
   - Right Child Index: 2*i + 2
   - Last Parent Index: (size/2) - 1
*/

#include <bits/stdc++.h>
using namespace std;

// Function to create max heap (parent is greater than children)
void heapify(vector<int>& arr, int size, int parent_idx) {
    int largest = parent_idx;
    int left_child = 2 * parent_idx + 1;
    int right_child = 2 * parent_idx + 2;

    if (left_child < size && arr[left_child] > arr[largest]) {
        largest = left_child;
    }

    if (right_child < size && arr[right_child] > arr[largest]) {
        largest = right_child;
    }

    if (largest != parent_idx) {
        swap(arr[parent_idx], arr[largest]);
        heapify(arr, size, largest);
    }
}

// Main heap sort function
void heapSort(vector<int>& arr) {
    int size = arr.size();

    // Build max heap
    for (int i = size / 2 - 1; i >= 0; i--) {
        heapify(arr, size, i);
    }

    // Extract elements from heap one by one
    for (int i = size - 1; i > 0; i--) {
        swap(arr[0], arr[i]);
        heapify(arr, i, 0);
    }
}

void printArray(const vector<int>& arr) {
    for (int num : arr) {
        cout << num << " ";
    }
    cout << endl;
}

int getValidSize() {
    int size;
    while (true) {
        cout << "Enter size of array: ";
        if (cin >> size && size > 0) {
            return size;
        }
        cout << "Invalid input! Please enter a positive number\n";
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
}

int main() {
    try {
        int size = getValidSize();

        vector<int> arr;
        cout << "Enter " << size << " numbers: ";
        for (int i = 0; i < size; i++) {
            int num;
            while (!(cin >> num)) {
                cout << "Invalid input! Enter a number for position " << i + 1 << ": ";
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
            }
            arr.push_back(num);
        }

        cout << "\nOriginal array: ";
        printArray(arr);

        heapSort(arr);

        cout << "Sorted array: ";
        printArray(arr);

    } catch (const exception& e) {
        cout << "An error occurred: " << e.what() << endl;
        return 1;
    }

    return 0;
}
