using NUnit.Framework;

namespace Codewars.Beta
{
    /// <summary>
    /// The Speed of Letters
    /// https://www.codewars.com/kata/5fc7caa854783c002196f2cb/train/csharp
    /// </summary>
    public static class Kata
    {
        public static string Speedify(string input)
        {
            var result = new string(' ', input.Length + 25).ToCharArray();
            const int a = 'A';

            for (var i = 0; i < input.Length; i++)
            {
                result[input[i] - a + i] = input[i];
            }

            return new string(result).TrimEnd(' ');
        }
    }

    [TestFixture]
    public class KataTests
    {
        [TestCase("AZ", ExpectedResult = "A                         Z")]
        [TestCase("ABC", ExpectedResult = "A B C")]
        [TestCase("ACE", ExpectedResult = "A  C  E")]
        [TestCase("CBA", ExpectedResult = "  A")]
        [TestCase("HELLOWORLD", ExpectedResult = "     E H    DLL   OLO   R  W")]
        public string BasicTests(string input)
        {
            return Kata.Speedify(input);
        }
    }
}