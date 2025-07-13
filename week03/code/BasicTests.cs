using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeachTests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void SimpleTest()
        {
            Assert.AreEqual(2 + 2, 4);
        }
    }
}
