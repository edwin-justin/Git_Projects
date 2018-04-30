using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net.Http;
using System.Web.Http;
using MortgageCalculator.Api;
using MortgageCalculator.Web.Controllers;

namespace MortgageCalculator.UnitTests
{
    [TestFixture]
    public class WebApiConfigTests
    {
        private readonly HttpConfiguration _configuration;

        public WebApiConfigTests()
        {
            _configuration = new HttpConfiguration();
            WebApiConfig.Register(_configuration);
            _configuration.EnsureInitialized();
        }

        [TestCase]
        public void Verify_RouteConfigTest()
        {
            Assert.IsTrue(_configuration.Routes.Count() > 0, "Atleast one route needs to exist.");
            Assert.IsNotNull(_configuration.Routes["DefaultApi"], "DefaultApi Route should not be null");
        }

        [TearDown]
        public void Cleanup()
        {
            if (_configuration != null)
                _configuration.Dispose();
        }
    }
}
