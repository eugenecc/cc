using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Unit.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = ConvertHelper.NoHTML("</html>");
        }
    }
}
