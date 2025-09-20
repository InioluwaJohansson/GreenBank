using BankApp.Context;
using BankApp.Entities;
using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace BankApp.Repositories;
public class LoanRepository{
    private readonly BankAppDbContext _context;
    public LoanRepository(BankAppDbContext bankAppdbcontext){
        _context = bankAppdbcontext;
    }
    public bool Create(Loan loan){
        if (loan == null){
            Console.WriteLine("Loan is Null");
            return false;
        }else{
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return true;
        }
    }
    public bool Update(Loan updatedLoan){
        _context.Update(updatedLoan);
        _context.SaveChanges();
        return true;
    }
    public Loan GetbyStatus(LoanPay loanPay, string accountNumber){
        return _context.Loans.Where(c => c.AccountNumber == accountNumber).FirstOrDefault(c => (c.LoanPay == LoanPay.NotPaid || c.LoanPay == LoanPay.Pending));
    }
    public List<Loan> ListAll(){
        return _context.Loans.ToList();
    }
    public List<Loan> List(string accountNumber){
        return _context.Loans.Where(x => x.AccountNumber == accountNumber).ToList();
    }
}