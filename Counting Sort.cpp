#include <bits/stdc++.h>
using namespace std;

vector<int> countSort(vector<int>& inputArray)
{
    int N = inputArray.size();
    int M = 0;
    for (int i = 0; i < N; i++)
        M = max(M, inputArray[i]);

    vector<int> countArray(M + 1, 0);

    for (int i = 0; i < N; i++)
        countArray[inputArray[i]]++;

    for (int i = 1; i <= M; i++)
        countArray[i] += countArray[i - 1];

    vector<int> outputArray(N);
    for (int i = N - 1; i >= 0; i--)
    {
        outputArray[countArray[inputArray[i]] - 1] = inputArray[i];
        countArray[inputArray[i]]--;
    }

    return outputArray;
}

void printArray(const vector<int>& arr, const string& message) {
    cout << message;
    for (int num : arr) {
        cout << num << " ";
    }
    cout << endl;
}

int getValidSize() {
    int size;
    while (true) {
        cout << "Enter the size of array (1-10000): ";
        if (cin >> size && size > 0 && size <= 10000) {
            return size;
        }
        cout << "Invalid input! Please enter a number between 1 and 10000.\n";
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
}

vector<int> getArrayElements(int size) {
    vector<int> arr(size);
    cout << "Enter " << size << " non-negative integers separated by spaces:\n";

    for (int i = 0; i < size; i++) {
        while (true) {
            if (cin >> arr[i] && arr[i] >= 0) {
                break;
            }
            cout << "Invalid input! Please enter a non-negative integer for position " << i + 1 << ": ";
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
        }
    }
    return arr;
}

int main()
{
    try {
        // Get array size from user
        int size = getValidSize();

        // Get array elements from user
        vector<int> inputArray = getArrayElements(size);

        // Print original array
        printArray(inputArray, "\nOriginal array: ");

        // Sort and print result
        vector<int> outputArray = countSort(inputArray);
        printArray(outputArray, "Sorted array: ");

    } catch (const exception& e) {
        cout << "An error occurred: " << e.what() << endl;
        return 1;
    }

    return 0;
}
