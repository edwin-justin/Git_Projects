using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MortgageCalculator.Web.Controllers;
using MortgageCalculator.Web.Models;

using NUnit.Framework;

namespace MortgageCalculator.UnitTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        public HomeControllerTests()
        {

        }

        [TestCase]
        public void Verify_IndexTest()
        {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            var actionResult = homeController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(actionResult, "Index action result should not be null");
        }

        [TestCase]
        public void Verify_IndexTest_WithModel()
        {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            var jsonResult = homeController.CalculateRepayment(12500, (decimal)5.25, 4) as JsonResult;

            //Assert
            Assert.IsNotNull(jsonResult, "Index action result should not be null");
            Assert.IsNotNull(jsonResult.Data, "Data returned in Json Result should not be null");

            LoanCalculator loanCalculator = (LoanCalculator)jsonResult.Data;
            Assert.IsTrue(loanCalculator.RepaymentSummary.Length > 0);
        }

        [TestCase]
         public void Verify_RepaymentCalculationTest()
        {
            HomeController homeController = new HomeController();
            // Test 1
            string repaymentSummary = homeController.GetRepaymentSummary(1000, (decimal)4.0, 1);
            Assert.AreEqual(repaymentSummary.Trim(), "Your total Repayment Amount would be $1040.00 and your Total Interest amount is $40.00.");

            // Test 2
            repaymentSummary = homeController.GetRepaymentSummary(270580, (decimal)3.25, 10);
            Assert.AreEqual(repaymentSummary.Trim(), "Your total Repayment Amount would be $358518.50 and your Total Interest amount is $87938.50.");

            // Test 3
            repaymentSummary = homeController.GetRepaymentSummary(450000, (decimal)3.75, 20);
            Assert.AreEqual(repaymentSummary.Trim(), "Your total Repayment Amount would be $787500.00 and your Total Interest amount is $337500.00.");
        }
    }
}
