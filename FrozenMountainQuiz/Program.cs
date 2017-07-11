using System;
using System.Collections.Generic;
using System.Linq;

namespace FrozenMountainQuiz
{
    class Program
    {
        static List<String> FindMaxSubStrings(int len, String searchString, out int maxOccurrences)
        {
            List<String> foundSubSubstrings = new List<string>();
            Dictionary<string, int> ssMap = new Dictionary<string, int>();

            for (var offset = 0; offset + len < searchString.Length; offset++)
            {
                var subStr = searchString.Substring(offset, len);
                if (!ssMap.ContainsKey(subStr))
                {
                    ssMap.Add(subStr, 1);
                }
                else
                {
                    ssMap[subStr]++;
                }
            }
            maxOccurrences = ssMap.Values.Max();
            foreach (var entry in ssMap)
            {
                if (entry.Value == maxOccurrences)
                {
                    foundSubSubstrings.Add(entry.Key);
                }
            }
            return foundSubSubstrings;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Please enter a string: ");
                String searchString = Console.ReadLine();
                Console.WriteLine("Enter a length of substrings to search for: ");
                int subStringLen = 0;
                try
                {
                    subStringLen = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Enter a valid integer.");
                    continue;
                }

                // Checks that the input is valid, pretty dirty way of doing this but it is quick and should meet the requirements for this scope.
                if (subStringLen <= 0 || searchString.Length <= subStringLen || searchString.Length <= 0)
                {
                    Console.WriteLine("Invalid input, please check input string is longer than substring length specified, and that both lengths are larger than 0.");
                    continue;
                }
                
                int occurrences = 0;
                List<String> foundSubSubstrings = FindMaxSubStrings(subStringLen, searchString, out occurrences);
                foreach(String foundString in foundSubSubstrings)
                {
                    Console.WriteLine("The substring " + foundString + " occurs " + occurrences + " times in string " + searchString);
                }
            }
        }
    }
}
