using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MortgageCalculator.Web.Models
{
    public class LoanCalculator
    {
        public int BorrowedAmount { get; set; }

        public int Years { get; set; }

        public MortgageType MortgageType { get; set; }

        public decimal Rate
        {
            get;
            set;
        }
            
        public string RepaymentSummary { get; internal set; }
    }
}