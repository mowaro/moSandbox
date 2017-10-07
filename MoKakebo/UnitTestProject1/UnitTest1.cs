using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            string a = "obj1";
            string b = "obj2";
            Assert.AreEqual(a, b);
        }
    }
}
