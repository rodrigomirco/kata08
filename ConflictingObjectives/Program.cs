using System;
using System.Linq;

namespace ConflictingObjectives
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new WordlistRepo();

            var dictOfWords = repo.GetListOfWords();

            // Each dictionary entry has a list of all words starting with same letter
            foreach(var words in dictOfWords){
                var firstLetter = words.Key;

                foreach(var word in words.Where(w => w.Length < 6)){
                    //Find all 6-letter-words that start with the given smaller word 
                    var similarWords = words.Where(w => w.Length == 6 && w.StartsWith(word));

                    // Each similar word is necessarily bigger than initial word
                    foreach(var similarWord in similarWords){
                        var remainingString = similarWord.Substring(word.Length);

                        var matchingWord = dictOfWords[firstLetter].FirstOrDefault(w => w == remainingString);
                        if(matchingWord != null){
                            Console.WriteLine(word + " + " + matchingWord + " => " + similarWord);
                        }
                    }
                }
            }
        }
    }
}
