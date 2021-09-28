using System;
using System.Collections.Generic;
using System.Linq;

namespace ConflictingObjectives.Extensions
{
    public static class StringExtensions
    {
        public static string GetFirstMatch(this IEnumerable<string> stringsInAlphabeticalOrder, string match)
        {
            // We assume that all strings are in alphabetical order and use that to enhance performance
            // We also know that all strings in the given list start with the same letter
            foreach(string str in stringsInAlphabeticalOrder)
            {
                if(str == match) return match;
                if(str.Length > 1 && match.Length > 1 && str[1] > match[1]) return null; // Since we know that list is in alphabetical order and first letter is the same
            }
            
            return null;
        }

        public static IEnumerable<string> GetPotentialCompoundWords(this IEnumerable<string> stringsInAlphabeticalOrder, string baseWord, int compoundWordLength)
        {
            List<string> potentialCompoundWords = new List<string>();
            foreach(string str in stringsInAlphabeticalOrder)
            {
                if(str.Length != compoundWordLength) continue;
                if(baseWord.Length > 1 && str[1] > baseWord[1]) return potentialCompoundWords;
                if(str.StartsWith(baseWord)) potentialCompoundWords.Add(str);
            }
            return potentialCompoundWords;
        }
    }
}