using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Dto; 

namespace MortgageCalculator.Api.Repos
{
    public interface IMortgageRepo
    {
        List<Mortgage> GetAllMortgages();
    }
}