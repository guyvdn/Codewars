using NUnit.Framework;

namespace Codewars.Thinking_and_Testing._02._Incomplete_string
{
    /// <summary>
    /// https://www.codewars.com/kata/56d9292cc11bcc3629000533/train/csharp
    /// </summary>
    public class Kata
    {
        public string Testit(string s)
        {
            var result = new char[(s.Length + 1) / 2];

            for (var i = 0; i < s.Length; i += 2)
            {
                var a = (int)s[i];
                var b = i + 1 == s.Length ? a : s[i + 1];
                var c = (char)((a + b) / 2);
                result[i / 2] = c;
            }

            return new string(result);
        }
    }

    [TestFixture]
    public class myjinxin
    {

        [Test]
        public void TestCase()
        {

            //return s ?
            Assert.AreEqual("", new Kata().Testit(""), "");
            Assert.AreEqual("a", new Kata().Testit("a"), "");
            Assert.AreEqual("b", new Kata().Testit("b"), "");
            //return s.Substring(0,1) ?
            Assert.AreEqual("a", new Kata().Testit("aa"), "");
            Assert.AreEqual("a", new Kata().Testit("ab"), "");
            Assert.AreEqual("b", new Kata().Testit("bc"), "");
            //return s.Substring(0,s.Length/2) ?
            Assert.AreEqual("aa", new Kata().Testit("aaaa"), "");
            Assert.AreEqual("aaa", new Kata().Testit("aaaaaa"), "");
            //click "Submit" try more testcase...
            Assert.AreEqual("ikojb", new Kata().Testit("pcpftjikb"));
        }
    }
}