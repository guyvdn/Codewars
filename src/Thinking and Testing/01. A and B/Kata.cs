using NUnit.Framework;

namespace Codewars.Thinking_and_Testing._01._A_and_B
{
    /// <summary>
    /// https://www.codewars.com/kata/56d904db9963e9cf5000037d/csharp
    /// </summary>
    public class Kata
    {
        public int Testit(int a, int b)
        {
            return a | b;
        }
    }

    [TestFixture]
    public class myjinxin
    {
        [Test]
        public void BasicTests()
        {
            //a+b?
            Assert.AreEqual(1, new Kata().Testit(0, 1));
            Assert.AreEqual(3, new Kata().Testit(1, 2));
            Assert.AreEqual(30, new Kata().Testit(10, 20));
            
            //a*b?
            Assert.AreEqual(1, new Kata().Testit(1, 1));
            Assert.AreEqual(3, new Kata().Testit(1, 3));

            //Click "Attempt" try more testcase...
            Assert.AreEqual(2, new Kata().Testit(2, 2));
            Assert.AreEqual(31, new Kata().Testit(11, 22));
            Assert.AreEqual(3199, new Kata().Testit(1095, 3135));
        }
    }
}