using BankApp.Context;
using BankApp.Entities;
using BankApp.Models.Enums;
using Microsoft.EntityFrameworkCore;
namespace BankApp.Repositories;
public class TransactionRepository{
    private readonly BankAppDbContext _context;
    public TransactionRepository(BankAppDbContext bankAppdbcontext){
        _context = bankAppdbcontext;
    }
    public bool Create(Transaction transaction){
        if (transaction == null){
            Console.WriteLine("Transaction is Null");
            return false;
        }else{
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return true;
        }
    }
    public List<Transaction> List(string acccountNumber){
        return _context.Transactions.Where(x => x.AccountNumber == acccountNumber).ToList();
    }
}