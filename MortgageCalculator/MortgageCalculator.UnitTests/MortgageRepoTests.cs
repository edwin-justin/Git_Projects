using System.Text;
using NUnit.Framework;
using MortgageCalculator.Api.Repos;
using MortgageCalculator.Dto;
using System.Collections.Generic;

namespace MortgageCalculator.UnitTests
{
    [TestFixture]
    public class MortgageRepoTests
    {
        private readonly IMortgageRepo _mortgageRepo;

        public MortgageRepoTests()
        {
            _mortgageRepo = new MortgageRepo();
        }
        
        [TestCase]
        public void Verify_GetAllMortgages_Repository()
        {
            List<Mortgage> mortgages = _mortgageRepo.GetAllMortgages();
            Assert.IsNotNull(mortgages);
            Assert.IsTrue(mortgages.Count > 0);

            // Test Mortgage Sorting Logic
            var firstMortgage = mortgages.First();
            Assert.AreEqual(firstMortgage.MortgageType,MortgageType.Variable);

            var variableMortgages = mortgages.Where(mt => mt.MortgageType == MortgageType.Variable).ToList();
            Assert.Less(variableMortgages.First<Mortgage>().InterestRate, variableMortgages.Last<Mortgage>().InterestRate);

            var lastMortgage = mortgages.Last();
            Assert.AreEqual(lastMortgage.MortgageType, MortgageType.Fixed);

            var fixedMortgages = mortgages.Where(mt => mt.MortgageType == MortgageType.Fixed).ToList();
            Assert.Less(fixedMortgages.First<Mortgage>().InterestRate, fixedMortgages.Last<Mortgage>().InterestRate);
        }
    }
}





