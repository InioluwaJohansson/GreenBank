using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models.Enums;
namespace BankApp.Entities;
public class Loan:BaseEntity{
    public string LoanId {get; set;}
    public Loans Loans {get; set;}
    public decimal Amount {get; set;}
    public decimal AmountPaid {get; set;}
    public decimal Interest {get; set;}
    public LoanPay LoanPay{get; set;}
    public DateTime LoanDate { get; set; }
    public string Description {get; set;}
    public string AccountNumber {get; set;}
}