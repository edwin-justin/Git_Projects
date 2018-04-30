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
        }
    }
}





