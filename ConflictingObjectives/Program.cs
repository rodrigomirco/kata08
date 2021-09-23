using System;

namespace ConflictingObjectives
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new WordlistRepo();

            var words = repo.GetListOfWords();

            foreach(var word in words) 
                Console.WriteLine(word);
        }
    }
}
