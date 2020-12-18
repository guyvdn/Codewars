using System.Globalization;
using NUnit.Framework;

namespace Codewars._7kyu
{
    /// <summary>
    /// https://www.codewars.com/kata/555eded1ad94b00403000071/train/csharp
    /// </summary>
    public class NthSeries
    {

        public static string seriesSum(int n)
        {
            var sum = 0M;
            
            for (var number = 1; number <= n; number++)
            {
                sum += 1M / (3 * number - 2);
            }

            return sum.ToString("F2", CultureInfo.InvariantCulture);
        }
    }

    [TestFixture]
    public class NthSeriesTests
    {

        [TestCase(0, ExpectedResult = "0.00")]
        [TestCase(1, ExpectedResult = "1.00")]
        [TestCase(2, ExpectedResult = "1.25")]
        [TestCase(5, ExpectedResult = "1.57")]
        [TestCase(9, ExpectedResult = "1.77")]
        public string Test1(int n)
        {
            return NthSeries.seriesSum(n);
        }
    }
}