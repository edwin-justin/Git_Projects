using MortgageCalculator.Api.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using MortgageCalculator.Dto;
using System;

namespace MortgageCalculator.UnitTests
{
    [TestFixture]
    public class MortgageControllerAPITests
    {
        public MortgageControllerAPITests()
        {

        }

        [TestCase]
        public void Verify_GetAllMortgagesTest_Api()
        {
            // Arrange
            var controller = new MortgageController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            IEnumerable<Mortgage> mortgages = controller.Get();

            // Assert
            Assert.IsNotNull(mortgages);
            Assert.IsTrue(mortgages.Count() > 0);
        }


        [TestCase]
        public void Verify_GetMortgageTest_Api()
        {
            // Arrange
            var controller = new MortgageController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            Mortgage mortgage = controller.Get(3);

            // Assert
            Assert.IsNotNull(mortgage);
            Assert.IsTrue(mortgage.MortgageId == 3);
            Assert.IsTrue(mortgage.Name.Length > 0);
            Assert.IsTrue(mortgage.InterestRate > 0);
            Assert.IsTrue(mortgage.EstablishmentFee > 0);
            Assert.IsTrue(mortgage.EffectiveStartDate > DateTime.MinValue);
            Assert.IsTrue(mortgage.EffectiveEndDate < DateTime.MaxValue);
            Assert.IsTrue(mortgage.EffectiveEndDate > mortgage.EffectiveStartDate);
            Assert.IsTrue(mortgage.MortgageType == MortgageType.Fixed || mortgage.MortgageType == MortgageType.Variable);
            Assert.IsTrue(mortgage.InterestRepayment == InterestRepayment.InterestOnly || mortgage.InterestRepayment == InterestRepayment.PrincipalAndInterest);
        }
    }
}
