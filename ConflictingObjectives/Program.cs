using System;
using System.Linq;
using ConflictingObjectives.Services;

namespace ConflictingObjectives
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "./ConflictingObjectives/data/wordlist.txt";
            var compoundWordsLength = 6;
            var compoundWordsService = new CompoundWordsService();

            var start = DateTime.Now;
            compoundWordsService.DisplayCompoundWordsFromFile(filePath, compoundWordsLength);
            var end = DateTime.Now;
            var timeSpan = end - start;

            Console.WriteLine("Execution time: {0} ms", timeSpan.TotalMilliseconds);

            
            start = DateTime.Now;
            compoundWordsService.DisplayCompoundWordsFromFile2(filePath, compoundWordsLength);
            end = DateTime.Now;
            timeSpan = end - start;

            Console.WriteLine("Execution time: {0} ms", timeSpan.TotalMilliseconds);
        }
    }
}
