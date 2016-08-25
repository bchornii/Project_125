using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using _001_LinqIntroduction;

namespace Tests
{
    [TestClass]
    public class TakeRangeTest
    {
        [TestMethod]
        public void NormalSourceTest()
        {
            var values = Enumerable.Range(10, 20);
            var elements = values.TakeRange(t => t >= 15).ToArray();

            Assert.AreEqual(elements.Count(), 5);
        }

        [TestMethod]
        public void NormalSourceWithTwoBondariesTest()
        {
            var values = Enumerable.Range(10, 10);
            var elemets = values.TakeRange(t => t > 12, t => t > 18);

            Assert.AreEqual(elemets.Count(), 6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSourceTest()
        {
            int[] values = null;
            var result = values.TakeRange(t => true, t => true).ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStartPredicateException()
        {
            var values = Enumerable.Range(10, 10);
            var result = values.TakeRange(null, t => true).ToList();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullEndPredicateException()
        {
            var values = Enumerable.Range(10, 10);
            var result = values.TakeRange(t => true, null).ToList();
        }

        [TestMethod]
        public void ElementEqualsTest()
        {
            var values = Enumerable.Range(0, 20);
            var result = values.TakeRange(end => end > 9).ToList();

            Assert.AreEqual(result.Count(), 10);

            // expected values
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(result[i], i);
            }
        }
    }
}
