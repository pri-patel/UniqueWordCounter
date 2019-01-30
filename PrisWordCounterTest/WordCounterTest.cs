using PrisWordCounter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrisWordCounterTest
{
  [TestClass]
  public class WordCounterTest
  {
    [TestMethod]
    public void NoWords()
    {
      WordCounter wordCounter = new WordCounter();
      Assert.AreEqual("", wordCounter.ListWordsString());
      Assert.AreEqual(0, wordCounter.GetCount("hello"));
    }

    [TestMethod]
    public void SuppliedExampleString()
    {
      WordCounter wordCounter = new WordCounter();
      wordCounter.ParseString("Go do that thing that you do so well");

      string expectedOutput = "2:do 1:Go 1:so 2:that 1:thing 1:well 1:you ";
      Assert.AreEqual(expectedOutput, wordCounter.ListWordsString());
      Assert.AreEqual(2, wordCounter.GetCount("do"));
      Assert.AreEqual(1, wordCounter.GetCount("Go"));
      Assert.AreEqual(0, wordCounter.GetCount("go"));
    }

    [TestMethod]
    public void TestString()
    {
      WordCounter wordCounter = new WordCounter();
      wordCounter.ParseString("You cannot end a sentence with because because because is a conjunction");

      string expectedOutput = "2:a 3:because 1:cannot 1:conjunction 1:end 1:is 1:sentence 1:with 1:You ";
      Assert.AreEqual(expectedOutput, wordCounter.ListWordsString());
      Assert.AreEqual(3, wordCounter.GetCount("because"));
    }
  }
}
