using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Models.DTOs;
public class CreateCustomerDto{
    public CreateUserDto User { get; set; }
    public AccountType AccountType {get; set;}
    public string AccountNumber {get; set;}
    public decimal Balance {get; set;}
    public DateTime DateOfBirth { get; set; } 
    public Loans Loans {get; set;}
    public LoanPay LoanPay{get; set;}
    public string BVN {get; set;}
    public string NIN {get; set;}
    public string NextOfKin { get; set; }
}
public class UpdateCustomerDto{
    public UpdateUserDto User { get; set; }
    public AccountType AccountType {get; set;}
    public DateTime DateOfBirth { get; set; } 
    public string BVN {get; set;}
    public string NIN {get; set;}
    public string NextOfKin { get; set; }
}
public class GetCustomerDto{
    public GetUserDto User { get; set; }
     public AccountType AccountType {get; set;}
    public string AccountNumber {get; set;}
    public decimal Balance {get; set;}
    public DateTime DateOfBirth { get; set; }
    public Loans Loans {get; set;}
    public LoanPay LoanPay{get; set;} 
    public string BVN {get; set;}
    public string NIN {get; set;}
    public string NextOfKin { get; set; }
}
public class GetCustomerPasswordDto{
    public GetUserPasswordDto User { get; set; }
     public AccountType AccountType {get; set;}
    public string AccountNumber {get; set;}
    public decimal Balance {get; set;}
    public DateTime DateOfBirth { get; set; } 
    public Loans Loans {get; set;}
    public LoanPay LoanPay{get; set;}
    public string BVN {get; set;}
    public string NIN {get; set;}
    public string NextOfKin { get; set; }
}
public class UpdateBalanceCustomerDto{
    public decimal Balance {get; set;}
}
public class UpdatePasswordCustomerDto{
    public UpdateUserPasswordDto User {get; set;}
}
public class UpdateAccountStatusCustomerDto{
    public UpdateUserAccountStatusDto User {get; set;}
}
public class UpdateLoanStatusCustomerDto{
    public LoanPay LoanPay {get; set;}
}