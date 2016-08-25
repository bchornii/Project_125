using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _001_LinqIntroduction;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class GroupingTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSourceException()
        {
            int[] values = null;
            values.Segment(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SegmentOutOfRangeException()
        {
            int[] values = { 1, 2, 3 };
            values.Segment(0);
        }

        [TestMethod]
        public void EmptySourceSet()
        {
            var values = Enumerable.Empty<int>().ToList();
            var result = values.Segment(4);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void EvenSegmentTest()
        {
            var values = Enumerable.Range(1, 100).ToList();
            var result = values.Segment(4);

            Assert.AreEqual(4, result.Count());

            foreach (var item in result)
            {
                Assert.AreEqual(25, item.Count());
            }
        }

        [TestMethod]
        public void MoreSegmentsThanElements()
        {
            var values = Enumerable.Range(1, 3).ToList();
            var result = values.Segment(10);

            Assert.AreEqual(10, result.Count());

            int i = 1;
            foreach (var g in result)
            {
                if(i < 4)
                {
                    Assert.AreEqual(1, g.Count());
                }
                else
                {
                    Assert.AreEqual(0, g.Count());
                }
                i++;
            }
        }

        [TestMethod]
        public void OddSegmentTest()
        {
            var values = Enumerable.Range(1, 101).ToList();
            var result = values.Segment(4);

            Assert.AreEqual(4, result.Count());

            int i = 1;
            foreach (var item in result)
            {
                if(i < 4)
                {
                    Assert.AreEqual(26, item.Count());
                }
                else
                {
                    Assert.AreEqual(23, item.Count());
                }
                i++;
            }
        }
    }
}
