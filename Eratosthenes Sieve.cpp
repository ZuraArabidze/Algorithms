/*
Sieve of Eratosthenes Algorithm Notes:
-------------------------------------
1. Time Complexity: O(n * log(log(n)))
2. Space Complexity: O(n)
3. Algorithm Properties:
   - Efficient for finding all primes up to n
   - Uses boolean array to mark non-prime numbers
   - Eliminates multiples of each prime number
4. Key Optimizations:
   - Only checks up to square root of n
   - Starts marking multiples from p*p
   - Skips even numbers after 2
*/

#include <bits/stdc++.h>
using namespace std;

vector<int> sieveOfEratosthenes(int n) {
    vector<bool> isPrime(n + 1, true);
    vector<int> primes;

    for (int i = 2; i * i <= n; i++) {
        if (isPrime[i]) {
            for (int j = i * i; j <= n; j += i) {
                isPrime[j] = false;
            }
        }
    }

    for (int i = 2; i <= n; i++) {
        if (isPrime[i]) {
            primes.push_back(i);
        }
    }

    return primes;
}

void printPrimes(const vector<int>& primes) {
    for (int prime : primes) {
        cout << prime << " ";
    }
    cout << endl;
}

int getValidInput() {
    int n;
    while (true) {
        cout << "Enter a number (n > 1) to find primes up to n: ";
        if (cin >> n && n > 1) {
            return n;
        }
        cout << "Invalid input! Please enter a number greater than 1\n";
        cin.clear();
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
    }
}

int main() {
    try {
        int n = getValidInput();

        cout << "\nFinding prime numbers up to " << n << "...\n\n";
        vector<int> primes = sieveOfEratosthenes(n);

        cout << "Found " << primes.size() << " prime numbers:\n";
        printPrimes(primes);

    }
    catch (const exception& e) {
        cout << "An error occurred: " << e.what() << endl;
        return 1;
    }

    return 0;
}
