using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConflictingObjectives.Repositories
{
    public class WordlistRepo 
    {
        public ILookup<char, string> GetDictOfWordsByFirstLetter(string filePath, int compoundWordsLength)
        {
            return File.ReadLines(filePath).Where(l => l.Length <= compoundWordsLength).ToLookup(l => l[0], l => l);
        }
    }
}