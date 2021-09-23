using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ConflictingObjectives
{
    public class WordlistRepo 
    {
        public ILookup<char, string> GetListOfWords(){
            string filePath = "./ConflictingObjectives/data/wordlist.txt";

            return File.ReadLines(filePath).Where(l => l.Length <= 6).ToLookup(l => l[0], l => l);
        }
    }
}