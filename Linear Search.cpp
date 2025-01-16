/*
Linear Search Algorithm Notes:
----------------------------
1. Time Complexity:
   - Best Case: O(1) - Element found at first position
   - Average Case: O(n) - Element found at middle or uniformly distributed
   - Worst Case: O(n) - Element at last position or not present
2. Space Complexity: O(1) - In-place searching
3. Algorithm Properties:
   - Simplest searching algorithm
   - Works on both sorted and unsorted arrays
   - Suitable for small arrays
   - Can find all occurrences of an element
4. Advantages:
   - Easy to implement
   - No pre-processing required
   - Works with any data type
   - Good for small datasets
*/

#include <bits/stdc++.h>
using namespace std;

int linearSearch(vector<int>& arr, int target) {
    for(int i = 0; i < arr.size(); i++) {
        if(arr[i] == target) {
            return i;
        }
    }
    return -1;
}

void printArray(vector<int>& arr) {
    for(int x : arr) {
        cout<< x << " ";
    }
    cout<<endl;
}

int main() {
    int size;
    cout << "Enter size of array: ";
    cin >> size;

    vector<int> arr;
    cout << "Enter " << size << " numbers: ";
    for (int i = 0; i < size; i++) {
        int num;
        cin >> num;
        arr.push_back(num);
    }

    int target;
    cout << "Enter number to search: ";
    cin >> target;

    cout << "\nArray: ";
    printArray(arr);

    int result = linearSearch(arr, target);

    if (result != -1) {
        cout << "Found " << target << " at position " << result << endl;
    } else {
        cout << target << " not found in array" << endl;
    }

    return 0;
}
