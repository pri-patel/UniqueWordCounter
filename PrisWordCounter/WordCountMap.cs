// WordCountMap
//
// Class for an ordered map of words to word-counts
// GetEnumerator() is supplied to allow for iteration over the map, since it 
// is an ordered map this iteration will be in alphabetical order.

using System.Collections;
using System.Collections.Generic;

namespace PrisWordCounter
{
  public class WordCountMap : IEnumerable<KeyValuePair<string, int>>
  {
    // ----- Public members -----
    public WordCountMap()
    {
      dictionary = new SortedDictionary<string, int>();
    }
 
    // Add a word to the map
    public void AddWord(string word)
    {
      dictionary[word] = GetCount(word) + 1;
    }

    // Expose dictionary's GetEnumerator() methods to allow enumeration
    public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
    {
      return ((IEnumerable<KeyValuePair<string, int>>)dictionary).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable<KeyValuePair<string, int>>)dictionary).GetEnumerator();
    }

    // Get the number of occurrences of a word
    public int GetCount(string word)
    {
      int wordCount = 0;
      dictionary.TryGetValue(word, out wordCount);
      return wordCount;
    }

    // ----- Private members -----
    private SortedDictionary<string, int> dictionary;
  }
}
