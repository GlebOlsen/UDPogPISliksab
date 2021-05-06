using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibSlikskab;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibSlikskab.Tests
{
    [TestClass()]
    public class SensorDataTests
    {
        private static SensorData _testsensordata;

        [TestInitialize]
        public void Init()
        {
            _testsensordata = new SensorData(1, 4, 20211304, true, "ddgss2222ssjshg37jd");
        }
        [TestMethod()]
        public void SensorIDTest()
        {
            Assert.AreEqual(expected: 1, actual: _testsensordata.SensorID);
        }

        [TestMethod()]
        public void ReadingIdTest()
        {
            Assert.AreEqual(expected:4, actual: _testsensordata.ReadingId);
        }

        [TestMethod]
        public void TimeTest()
        {
            Assert.AreEqual(expected:20211304,actual: _testsensordata.Time);
        }

        [TestMethod]
        public void IsOpenTest()
        {
            Assert.AreEqual(expected: true, actual: _testsensordata.IsOpen);
        }

        [TestMethod]
        public void ImageTest()
        {
            Assert.AreEqual(expected: "ddgss2222ssjshg37jd", actual: _testsensordata.Image);
        }
    }
}