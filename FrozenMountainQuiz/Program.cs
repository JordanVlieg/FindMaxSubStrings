using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FrozenMountainQuiz
{
    class Program
    {
        static String FindMaxSubStrings(int len, String searchString, out int maxOccurrences)
        {
            if (len <= 0 || len > searchString.Length || searchString.Length <= 0)
            {
                // Originally I had these seperate and throwing exceptions, but for this scale I think this is adequate.
                maxOccurrences = 0;
                return "BAD PARAMETERS";
            }
            Dictionary<string, int> tempMap = new Dictionary<string, int>();

            for (var offset = 0; offset + len < searchString.Length; offset++)
            {
                var sub = searchString.Substring(offset, len);
                if (!tempMap.ContainsKey(sub))
                {
                    tempMap.Add(sub, 1);
                }
                else
                {
                    tempMap[sub]++;
                }
            }
            maxOccurrences = tempMap.Values.Max();
            foreach (var entry in tempMap)
            {
                if (entry.Value == maxOccurrences)
                {
                    return entry.Key;
                }
            }
            return ""; // Should never be reached
        }

        static void Main(string[] args)
        {
            int occurrences = 0;
            String theString = FindMaxSubStrings(3, "zfabcde224lkfabc51+crsdtab=", out occurrences);
            if(occurrences > 0)
            {
                Console.WriteLine("The substring '" + theString + "' occurs " + occurrences + " times");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("BAD PARAMETERS");
                Console.ReadLine();
            }

        }
    }
}
