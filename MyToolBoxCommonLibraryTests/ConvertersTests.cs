using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyToolBoxCommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyToolBoxCommonLibrary.Tests
{
    [TestClass()]
    public class ConvertersTests
    {
        [TestMethod()]
        public void ToIeee754Test()
        {
            var bytes = Converters.ToIeee754(1.0f, ENDIAN.LittleEndian).ToArray();
            Assert.AreEqual(0x00, bytes[0]);
            Assert.AreEqual(0x00, bytes[1]);
            Assert.AreEqual(0x80, bytes[2]);
            Assert.AreEqual(0x3f, bytes[3]);

            bytes = Converters.ToIeee754(1.0f, ENDIAN.BigEndian).ToArray();
            Assert.AreEqual(0x3f, bytes[0]);
            Assert.AreEqual(0x80, bytes[1]);
            Assert.AreEqual(0x00, bytes[2]);
            Assert.AreEqual(0x00, bytes[3]);

        }
    }
}