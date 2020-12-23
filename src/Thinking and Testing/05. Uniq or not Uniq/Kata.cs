using System;
using System.Linq;
using NUnit.Framework;

namespace Codewars._7kyu
{
    /// <summary>
    /// https://www.codewars.com/kata/56d949281b5fdc7666000004/train/csharp
    /// </summary>
    public class Kata
    {
        public int[] Testit(int[] a, int[] b)
        {
            Console.WriteLine("a: " + string.Join(',', a));
            Console.WriteLine("b: " + string.Join(',', b));
            Console.WriteLine("---");
            return a.Distinct().Concat(b.Distinct()).OrderBy(x => x).ToArray();
        }
    }
    
    [TestFixture]
    public class myjinxin
    {

        [Test]
        public void TestCase()
        {
            Assert.AreEqual(new int[] { 0, 1 }, new Kata().Testit(new int[] { 0 }, new int[] { 1 }), "");
            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, new Kata().Testit(new int[] { 1, 2 }, new int[] { 3, 4 }), "");
            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, new Kata().Testit(new int[] { 1 }, new int[] { 2, 3, 4 }), "");
            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, new Kata().Testit(new int[] { 1, 2, 3 }, new int[] { 4 }), "");
            Assert.AreEqual(new int[] { 1, 1, 2, 2 }, new Kata().Testit(new int[] { 1, 2 }, new int[] { 1, 2 }), "");
        }
    }
}