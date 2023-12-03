using System;
using System.Collections.Generic;
using System.IO;

namespace MyApp
{
    class Program
    {
        public static Dictionary<string, int> NumberLastDigitPairs = new Dictionary<string, int>()
        {
            { "three", 3 },
            { "five", 5 },
            { "seven", 7 },
            { "nine", 9 },
            { "eight", 8 },
            { "two", 2 },
            { "one", 1 },
            { "four", 4 },
            { "six", 6 }
        };

        //create a function that takes a string, searches for all keys of NumberLastDigitPairs dictionary as substrings, if finds any, replaces them with their values, and returns the result
        public static string ReplaceWordsWithNumbers(string input)
        {
            string result = input;

            foreach (KeyValuePair<string, int> pair in NumberLastDigitPairs)
            {
                if (input.Contains(pair.Key))
                {
                    result = result.Replace(pair.Key, pair.Key + pair.Value.ToString()+ pair.Key);
                }
            }

            return result;
        }
        
        public static int GetTwoDigitNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            input = ReplaceWordsWithNumbers(input);

            char firstDigit = ' ';
            char lastDigit = ' ';
            
            for (int i = 0; i < input.Length; i++)
            {  
                if (char.IsDigit(input[i]) && firstDigit == ' ')
                {
                    firstDigit = input[i];
                    lastDigit = input[i];
                }
                else if (char.IsDigit(input[i]))
                {
                    lastDigit = input[i];
                }
            }

            if (firstDigit == ' ' || lastDigit == ' ')
            {
                return 0;
            }

            int twoDigitNumber = int.Parse(firstDigit.ToString() + lastDigit.ToString());

            return twoDigitNumber;
        }

        public static int GetInput()
        {
            string filePath = "1_input.txt";
            int sum = 0;

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    int result = GetTwoDigitNumber(line);
                    sum += result;
                }
            }

            return sum;
        }
        
        
        static void Main(string[] args)
        {
            int a = GetInput();
            //string a = ReplaceWordsWithNumbers("one hundred and sixty seventeen three");
            Console.WriteLine(a);
        }
    }
}
