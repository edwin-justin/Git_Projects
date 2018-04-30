using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MortgageCalculator.Dto;

namespace MortgageCalculator.Api.Repos
{
    public class MortgageRepo : IMortgageRepo
    {
        public List<Mortgage> GetAllMortgages()
        {
            using (var context = new MortgageData.MortgageDataContext())
            {
                var mortgages = context.Mortgages.ToList();
                List<Mortgage> result = new List<Mortgage>();
                if (mortgages != null && mortgages.Count() > 0)
                {
                    result.AddRange(
                            mortgages
                            .Select(mortgage => new Mortgage()
                                {
                                    Name = $"{mortgage.Name}  @ {mortgage.InterestRate.ToString()}%",
                                    EffectiveStartDate = mortgage.EffectiveStartDate,
                                    EffectiveEndDate = mortgage.EffectiveEndDate,
                                    CancellationFee = mortgage.CancellationFee,
                                    EstablishmentFee = mortgage.EstablishmentFee,
                                    InterestRepayment = (InterestRepayment)Enum.Parse(typeof(InterestRepayment), mortgage.InterestRepayment.ToString().Trim()),
                                    MortgageId = mortgage.MortgageId,
                                    MortgageType = (MortgageType)Enum.Parse(typeof(MortgageType), mortgage.MortgageType.ToString().Trim()),
                                    InterestRate = mortgage.InterestRate
                                })
                            .OrderBy(mt => mt.MortgageType)
                            .ThenBy(mt => mt.InterestRate)
                        );
                }
                return result;
            }
        }
    }
}