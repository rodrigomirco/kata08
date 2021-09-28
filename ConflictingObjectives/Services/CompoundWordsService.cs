using System;
using System.Collections.Generic;
using System.Linq;
using ConflictingObjectives.Repositories;
using ConflictingObjectives.Extensions;

namespace ConflictingObjectives.Services
{
    public class CompoundWordsService
    {
        private WordlistRepo _repo;

        public CompoundWordsService(){
            _repo = new WordlistRepo();
        }

        public void DisplayCompoundWordsFromFile(string filePath, int compoundWordsLength)
        {
            var dictOfWords = _repo.GetListOfWordsByFirstLetter(filePath, compoundWordsLength);

            // Each dictionary entry has a list of all words starting with same letter
            foreach(var words in dictOfWords)
            {
                var firstLetter = words.Key;

                foreach(var beginWord in words.Where(w => w.Length < compoundWordsLength))
                {
                    //Find all words with max length that start with the given smaller word 
                    var compoundWords = words.Where(w => w.Length == compoundWordsLength && w.StartsWith(beginWord));

                    // Each similar word is necessarily bigger than initial word
                    foreach(var compoundWord in compoundWords)
                    {
                        var remainingString = compoundWord.Substring(beginWord.Length);

                        var endWord = dictOfWords[firstLetter].GetFirstMatch(remainingString);
                        if(endWord != null)
                        {
                            //Console.WriteLine("{0} + {1} => {2}", beginWord, endWord, compoundWord);
                        }
                    }
                }
            }
        }

        public void DisplayCompoundWordsFromFile2(string filePath, int compoundWordsLength)
        {
            var dictOfWords = _repo.GetListOfWordsByFirstLetter(filePath, compoundWordsLength);

            // Each dictionary entry has a list of all words starting with same letter
            foreach(var words in dictOfWords)
            {
                var firstLetter = words.Key;

                foreach(var beginWord in words.Where(w => w.Length < compoundWordsLength))
                {
                    //Find all words with max length that start with the given smaller word 
                    var compoundWords = words.Where(w => w.Length == compoundWordsLength && w.StartsWith(beginWord));

                    // Each similar word is necessarily bigger than initial word
                    foreach(var compoundWord in compoundWords)
                    {
                        var remainingString = compoundWord.Substring(beginWord.Length);

                        var endWord = dictOfWords[firstLetter].FirstOrDefault(w => w == remainingString);
                        if(endWord != null)
                        {
                            //Console.WriteLine("{0} + {1} => {2}", beginWord, endWord, compoundWord);
                        }
                    }
                }
            }
        }
    }
}