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
            var dictOfWords = _repo.GetDictOfWordsByFirstLetter(filePath, compoundWordsLength);

            // Each dictionary entry has a list of all words starting with same letter
            foreach(var words in dictOfWords)
            {
                var firstLetter = words.Key;

                foreach(var beginWord in words.Where(w => w.Length < compoundWordsLength))
                {
                    // Find all words with max length that start with the given smaller word 
                    var potentialCompoundWords = words.GetPotentialCompoundWords(beginWord, compoundWordsLength);

                    foreach(var potentialCompoundWord in potentialCompoundWords)
                    {
                        var remainingString = potentialCompoundWord.Substring(beginWord.Length);

                        if(remainingString == beginWord) continue; // We want words composed of 2 distinct words. Ex.: we do not want zoozoo

                        var endWord = dictOfWords[firstLetter].GetFirstMatch(remainingString);
                        if(endWord != null)
                        {
                            Console.WriteLine("{0} + {1} => {2}", beginWord, endWord, potentialCompoundWord);
                        }
                    }
                }
            }
        }
    }
}