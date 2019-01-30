using System;

namespace PrisWordCounter
{
  class Program
  {
    static void Main(string[] args)
    {
      // If the file doesn't exist WordCounter will use the example text
      string filePath = "C:\\path\\to\\root\\SampleFiles\\simple.txt";

      // If arguments are passed, take the first one as a file path, ignore the other arguments
      if (args.Length > 0)
      {
        filePath = args[0];
      }

      // Count and store the words in the file
      WordCounter fileWordCounter = new WordCounter();
      int error_code = fileWordCounter.ParseFile(filePath);
      if (error_code == 0)
      {
        Console.WriteLine("The file contains the following counts:");
        fileWordCounter.ListWordsConsole();
      }

      // Count and store the words in the following string
      const string sentence = "You cannot end a sentence with because because because is a conjunction";
      WordCounter stringWordCounter = new WordCounter();
      stringWordCounter.ParseString(sentence);
      Console.WriteLine("\nThe string '{0}' contains the following counts:", sentence);
      stringWordCounter.ListWordsConsole();

      // Since words are stored in a dictionary, we can efficiently access the
      // wordcounts and perform comparisons on them.
      const string word = "that";
      Console.WriteLine(
        "\nThe file has {0} occurence(s) of '{1}', whereas the string has {2} occurence(s)",
        fileWordCounter.GetCount(word),
        word,
        stringWordCounter.GetCount(word)
      );

      // A more robust solution would probably involve using SQL Server and
      // maintaining a database of words and their counts.

      Console.ReadKey();
    }
  }
}
