using System;
using System.Collections.Generic;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1) Merge Sort (user input array)");
                Console.WriteLine("2) Reverse Vowels in String");
                Console.WriteLine("3) Anagram Check");
                Console.WriteLine("4) Exit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                if (choice == "1") RunMergeSort();
                else if (choice == "2") RunReverseVowels();
                else if (choice == "3") RunAnagram();
                else if (choice == "4") break;
                else Console.WriteLine("Invalid choice.");
            }
        }

        
        // 1) MERGE SORT
        
        static void RunMergeSort()
        {
            Console.Write("Enter numbers separated by spaces: ");
            string input = Console.ReadLine() ?? "";

            int[] arr = Array.ConvertAll(
                input.Split(' ', StringSplitOptions.RemoveEmptyEntries),
                int.Parse
            );

            MergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Sorted: " + string.Join(" ", arr));
        }

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            int mid = left + (right - left) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++) L[i] = arr[left + i];
            for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

            int a = 0, b = 0, k = left;

            while (a < n1 && b < n2)
            {
                if (L[a] <= R[b]) arr[k++] = L[a++];
                else arr[k++] = R[b++];
            }

            while (a < n1) arr[k++] = L[a++];
            while (b < n2) arr[k++] = R[b++];
        }

        
        // 2) REVERSE VOWELS
        
        static void RunReverseVowels()
        {
            Console.Write("Enter a string: ");
            string s = Console.ReadLine() ?? "";

            Console.WriteLine("Output: " + ReverseVowels(s));
        }

        static string ReverseVowels(string s)
        {
            char[] chars = s.ToCharArray();
            HashSet<char> vowels = new HashSet<char>
            {
                'a','e','i','o','u','A','E','I','O','U'
            };

            int i = 0, j = chars.Length - 1;

            while (i < j)
            {
                while (i < j && !vowels.Contains(chars[i])) i++;
                while (i < j && !vowels.Contains(chars[j])) j--;

                if (i < j)
                {
                    char temp = chars[i];
                    chars[i] = chars[j];
                    chars[j] = temp;
                    i++;
                    j--;
                }
            }

            return new string(chars);
        }

        
        // 3) ANAGRAM CHECK
        
        static void RunAnagram()
        {
            Console.Write("Enter s: ");
            string s = Console.ReadLine() ?? "";

            Console.Write("Enter t: ");
            string t = Console.ReadLine() ?? "";

            Console.WriteLine("Anagram? " + IsAnagram(s, t));
        }

        static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            int[] count = new int[256];

            for (int i = 0; i < s.Length; i++)
            {
                count[(int)s[i]]++;
                count[(int)t[i]]--;
            }

            for (int i = 0; i < count.Length; i++)
                if (count[i] != 0) return false;

            return true;
        }
    }
}