using NUnit.Framework;

namespace Codewars._6kyu
{
    public class BouncingBall
    {
        public static int bouncingBall(double h, double bounce, double window)
        {
            if (h <= 0 || bounce <= 0 || bounce >= 1 || window >= h)
                return -1;

            var result = -1;

            while (h > window)
            {
                result += 2;
                h *= bounce;
            };

            return result;
        }
    }

    [TestFixture]
    public class BouncingBallTests
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(3, BouncingBall.bouncingBall(3.0, 0.66, 1.5));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(15, BouncingBall.bouncingBall(30.0, 0.66, 1.5));
        }
    }
}