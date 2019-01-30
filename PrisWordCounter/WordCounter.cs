// WordCounter
//
// Class that can read a list of words from either a file or a string and
// produce a map of words to word-counts
//
// Note that the map is case-sensitive, this can easily be changed

using System;
using System.Collections.Generic;
using System.IO;

namespace PrisWordCounter
{
  public class WordCounter
  {
    // ----- Public members -----
    public WordCounter()
    {
      wordCountCollection = new WordCountMap();
    }

    // Read a file into the collection of words
    // returns 0 if successful, 1 otherwise
    public int ParseFile(string filePath)
    {
      // If the passed file doesn't exist, default to defaultString
      if (!File.Exists(filePath))
      {
        Console.WriteLine("File '{0}' does not exist, using default string '{1}'", filePath, defaultString);
        ParseString(defaultString);
        return 0;
      }
 
      string line;
      try
      {
        StreamReader sr = new StreamReader(filePath);

        line = sr.ReadLine();
        while (line != null)
        {
          // add the words in 'line' to the collection
          ParseString(line);

          // read the next line
          line = sr.ReadLine();
        }

        // close the file
        sr.Close();
      }
      catch (Exception e)
      {
        Console.WriteLine("Exception: " + e.Message);
        return 1;
      }

      return 0;
    }

    // Read a string into the collection of words
    public void ParseString(string line)
    {
      foreach (string word in line.Split(' '))
      {
        // We could do some formatting here to remove punctuation and special
        // characters, but I decided not to for simplicity
        if (!string.IsNullOrEmpty(word))
        {
          wordCountCollection.AddWord(word);
        }
      }
    }

    // List words and their counts to the console
    public void ListWordsConsole()
    {
      foreach (KeyValuePair<string, int> wordCount in wordCountCollection)
      {
        Console.WriteLine("{1}: {0}", wordCount.Key, wordCount.Value);
      }
    }

    // List words and their counts in a string (for tests)
    public string ListWordsString()
    {
      string result = "";
      foreach (KeyValuePair<string, int> wordCount in wordCountCollection)
      {
        result += String.Format("{1}:{0} ", wordCount.Key, wordCount.Value);
      }
      return result;
    }

    // Get the number of occurrences of a word
    public int GetCount(string word)
    {
      return wordCountCollection.GetCount(word);
    }

    // ----- Private members -----
    private WordCountMap wordCountCollection;
    private const string defaultString = "Go do that thing that you do so well";
  }
}
