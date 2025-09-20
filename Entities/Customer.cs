using BankApp.Models.Enums;
namespace BankApp.Entities;
public class Customer:BaseEntity{
    public User User {get; set;}
    public AccountType AccountType {get; set;}
    public string AccountNumber {get; set;}
    public decimal Balance {get; set;}
    public DateTime DateOfBirth { get; set; } 
    public LoanPay LoanPay{get; set;}
    public Loans Loans {get; set;}
    public string BVN {get; set;}
    public string NIN {get; set;}
    public string NextOfKin { get; set; }
}