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
            if (len <= 0 || searchString.Length < len || searchString.Length <= 0)
            {
                // Originally I had these seperate and throwing exceptions, but for this scale I think this is adequate.
                maxOccurrences = 0;
                return "BAD PARAMETERS";
            }
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
                    return entry.Key;
                }
            }
            return ""; // Should never be reached
        }

        static void Main(string[] args)
        {
            int occurrences = 0;
            String theString = FindMaxSubStrings(2, "2tg5iTPoViM6PM5Nit6HVYG2D8lhS80Bpo0cMyxTaeFW5zbblahobZuKERgro7FL6CCgeWa2M7" +
                "9PDQqgNamCUZhrgIbu1lBbhGVRtEewtVblah05TLi6qYwPOLmUgQYaGNWwHPcoKblahergOcTu9WThk", out occurrences);
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
