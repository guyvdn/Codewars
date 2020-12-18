using NUnit.Framework;

namespace Codewars._7kyu
{
    /// <summary>
    /// Growth of a Population
    /// https://www.codewars.com/kata/563b662a59afc2b5120000c6/train/csharp
    /// </summary>
    public class Arge
    {
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            var year = 0;
            var percentage = 1 + percent / 100;

            while (p0 < p)
            {
                p0 = (int)(p0 * percentage) + aug;
                year++;
            }

            return year;
        }
    }

    [TestFixture]
    public static class ArgeTests
    {
        [TestCase(1500, 5, 100, 5000, ExpectedResult = 15)]
        [TestCase(1500000, 2.5, 10000, 2000000, ExpectedResult = 10)]
        [TestCase(1500000, 0.25, 1000, 2000000, ExpectedResult = 94)]
        public static int Test(int p0, double percent, int aug, int p)
        {
            return Arge.NbYear(p0, percent, aug, p);
        }
    }
}