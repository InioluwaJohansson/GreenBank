using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models.Enums;
namespace BankApp.Entities;
public class Transaction:BaseEntity{
    public string TransactionId {get; set;}
    public string TransactionType {get; set;}
    public DateTime TransactionDate { get; set; }
    public decimal Amount {get; set;}
    public string Description {get; set;}
    public string AccountNumber {get; set;}
}