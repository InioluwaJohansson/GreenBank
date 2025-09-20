using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Models.DTOs;
public class CreateTransactionDto{
    public string TransactionId {get; set;}
    public string TransactionType {get; set;}
    public DateTime TransactionDate { get; set; }
    public decimal Amount {get; set;}
    public string Description {get; set;}
    public string AccountNumber {get; set;}
}
public class GetTransactionDto{
    public string TransactionId {get; set;}
    public string TransactionType {get; set;}
    public DateTime TransactionDate { get; set; }
    public decimal Amount {get; set;}
    public string Description {get; set;}
    public string AccountNumber {get; set;}
}