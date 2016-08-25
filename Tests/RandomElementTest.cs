using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _001_LinqIntroduction;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class RandomElementTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSourceTest()
        {
            int[] values = null;
            int result = values.RandomElement();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptySourceTest()
        {
            var values = Enumerable.Empty<int>();
            int result = values.RandomElement();
        }

        [TestMethod]
        public void IEnumerableTest()
        {
            var values = Enumerable.Range(0, 1000);
            int result1 = values.RandomElement(1);
            int result2 = values.RandomElement(2);

            Assert.AreNotEqual(result1, result2);
        }

        [TestMethod]
        public void IListTest()
        {
            var values = Enumerable.Range(0, 1000).ToList();
            int result1 = values.RandomElement(1);
            int result2 = values.RandomElement(2);

            Assert.AreNotEqual(result1, result2);
        }

        [TestMethod]
        public void SingleElementTest()
        {
            var values1 = Enumerable.Range(10, 1);
            int result1 = values1.RandomElement(1);
            Assert.AreEqual(10, result1);

            var values2 = values1.ToList();
            int result2 = values2.RandomElement(2);
            Assert.AreEqual(10, result2);
        }

        [TestMethod]
        public void BoundaryTest()
        {
            var values = Enumerable.Range(10, 2);
            int result1 = values.RandomElement();
            bool foundDifferent = false;
            for (int i = 0; i < 25; i++)
            {
                int result2 = values.RandomElement(i + 100);
                if(result1 != result2)
                {
                    foundDifferent = true;
                    break;
                }
            }
            Assert.IsTrue(foundDifferent);
        }

        [TestMethod]
        public void CheckForDefault()
        {
            var values = Enumerable.Empty<int>();
            int result = values.RandomElementOrDefault();

            Assert.AreEqual(0, result);
        }
    }
}
