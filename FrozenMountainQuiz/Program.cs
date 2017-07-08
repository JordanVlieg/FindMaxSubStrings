using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FrozenMountainQuiz
{
    class SubString
    {
        /*
         * I realize this is complete overkill to make this class, 
         * and to make everything private with getters and setters,
         * just figured I should adhere to good practices and it makes future modification easier.
        */

        private int numOccurrences;
        private String value;

        public SubString()
        {
            numOccurrences = -1;
            value = "NO REPEATS FOUND";
        }
        
        public int GetOccurrences()
        {
            return this.numOccurrences;
        }
        public String GetValue()
        {
            return this.value;
        }
        public void SetOccurrences(int num)
        {
            this.numOccurrences = num;
        }
        public void SetValue(String newValue)
        {
            this.value = newValue;
        }
        public void PrintInfo()
        {
            Console.WriteLine("The substring '" + value + "' occurs " + numOccurrences + " times");
            Console.ReadLine();
        }
    }

    class Program
    {
        static SubString FindMaxSubStrings(int len, String searchString)
        {
            var subString = new SubString();
            Dictionary<string, int> tempMap = new Dictionary<string, int>();

            for (var offset = 0; offset < (searchString.Length - len); offset++)
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

            var mostOccurences = tempMap.Values.Max(); // Allows for faster access in the loop
            subString.SetOccurrences(mostOccurences);
            foreach (var entry in tempMap)
            {
                if(entry.Value == mostOccurences)
                {
                    subString.SetValue(entry.Key);
                    return subString;
                }
            }
            return subString; //This should never be reached in theory
        }

        static void Main(string[] args)
        {
            SubString myString = FindMaxSubStrings(3, "zfabcde224lkfabc51+crsdtab=");
            myString.PrintInfo();
        }
    }
}
