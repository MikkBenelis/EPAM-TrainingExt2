using NUnit.Framework;
using System.Linq;

namespace No6.Solution.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            int[] actual = SequenceGenerator.Generate(10, 1, 1, (a, b) => a + b).ToArray();
            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void Generator_ForSequence2()
        {
            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
            int[] actual = SequenceGenerator.Generate(10, 1, 2, (a, b) => 6 * a - 8 * b).ToArray();
            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void Generator_ForSequence3()
        {
            double[] expected = { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 };
            double[] actual = SequenceGenerator.Generate<double>(10, 1, 2, (a, b) => a + b / a).ToArray();
            Assert.That(expected, Is.EqualTo(actual).Within(0.001));
        }
    }
}
