using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarlonPolanco_COVID19Report.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlonPolanco_COVID19Report.BL.Tests
{
    [TestClass()]
    public class OperationsTests
    {
        [TestMethod()]
        public async Task GetRegiosTest()
        {
            var services = new Operations();

            var result = await services.GetRegios();

            bool pResult = result.data.Count > 0 ? true : false;

            Assert.IsTrue(pResult);
        }

        [TestMethod()]
        public async Task GetCOVIDReport()
        {
            var services = new Operations();

            var result = await services.GetCOVIDReport();

            bool pResult = result.data.Count > 0 ? true : false;

            Assert.IsTrue(pResult);
        }
    }
}