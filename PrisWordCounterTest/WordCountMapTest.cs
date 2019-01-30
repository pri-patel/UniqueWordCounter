using PrisWordCounter;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrisWordCounterTest
{
  [TestClass]
  public class WordCountMapTest
  {
    [TestMethod]
    public void NoWords()
    {
      WordCountMap words = new WordCountMap();

      Assert.AreEqual(0, words.GetCount(""));
      Assert.AreEqual(0, words.GetCount("hello"));
    }

    [TestMethod]
    public void SomeWords()
    {
      WordCountMap words = new WordCountMap();
      words.AddWord("hello");
      words.AddWord("goodbye");
      words.AddWord("hello");
      words.AddWord("goodbye");
      words.AddWord("this");

      Assert.AreEqual(0, words.GetCount(""));
      Assert.AreEqual(0, words.GetCount("foo"));
      Assert.AreEqual(2, words.GetCount("hello"));
      Assert.AreEqual(2, words.GetCount("goodbye"));
      Assert.AreEqual(1, words.GetCount("this"));

      words.AddWord("hello");
      Assert.AreEqual(3, words.GetCount("hello"));
    }
  }
}
