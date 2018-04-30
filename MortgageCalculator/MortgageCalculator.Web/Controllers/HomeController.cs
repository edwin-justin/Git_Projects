using MortgageCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private const decimal defaultRate = (decimal)2.50;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CalculateRepayment(int borrowedAmount, decimal rate, int years)
        {
            LoanCalculator loanCalculator = new LoanCalculator();
            if (ModelState.IsValid)
            {
                if ((borrowedAmount > 0) && (rate > 0) && (years > 0))
                {

                    loanCalculator.BorrowedAmount = borrowedAmount;
                    loanCalculator.Rate = rate;
                    loanCalculator.Years = years;

                    // Perform Loan Repayment calculation
                    // push the TotalRepaymentAmount and  TotalInterest show LoadRepaymentSummary
                    string repaymentSummary = GetRepaymentSummary(loanCalculator.BorrowedAmount, (loanCalculator.Rate > 0 ? loanCalculator.Rate : defaultRate), loanCalculator.Years);
                    loanCalculator.RepaymentSummary = repaymentSummary;
                }
            }
            // return View("Index", loanCalculator);
            return  Json(loanCalculator);

        }

        public string GetRepaymentSummary(int principal, decimal rateOfInterest, int years)
        {
            double rate = Convert.ToDouble(((rateOfInterest / (years * 12)) / 100));
            double factor = (rate + (rate / (Math.Pow(rate + 1, (years * 12)) - 1)));
            double payment = (principal * factor);

            decimal totalPayment = (decimal)Math.Round(payment * years * 12, 2);
            decimal totalInterest = totalPayment - principal;

            return ($"Your total Repayment Amount would be ${totalPayment} and your Total Interest amount is ${totalInterest}.");
        }
    }
}