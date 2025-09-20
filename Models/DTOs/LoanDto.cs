using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Models.DTOs;
public class CreateLoanDto{
    public string LoanId {get; set;}
    public decimal Amount {get; set;}
    public Loans Loans {get; set;}
    public decimal Interest {get; set;}
    public decimal AmountPaid {get; set;}
    public DateTime LoanDate { get; set; }
    public LoanPay LoanPay{get; set;}
    public string Description {get; set;}
    public string AccountNumber {get; set;}
    
}
public class GetLoanDto{
    public string LoanId {get; set;}
    public decimal Amount {get; set;}
    public Loans Loans {get; set;}
    public decimal Interest {get; set;}
    public decimal AmountPaid {get; set;}
    public DateTime LoanDate { get; set; }
    public LoanPay LoanPay{get; set;}
    public string Description {get; set;}
    public string AccountNumber {get; set;}
}
public class UpdateLoanDto{
    public decimal AmountPaid {get; set;}
    public LoanPay LoanPay {get; set;}
}