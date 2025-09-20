using BankApp.Context;
using BankApp.Entities;
using BankApp.Models;
using BankApp.Models.Enums;
using Microsoft.EntityFrameworkCore;
namespace BankApp.Repositories;
public class CustomerRepository{
    private readonly BankAppDbContext _context;
    public CustomerRepository(BankAppDbContext bankAppdbcontext){
        _context = bankAppdbcontext;
    }
    public bool Create(Customer customer){
        if (customer == null){
            Console.WriteLine("Customer is Null");
            return false;
        }else{
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return true;
        }
    }
    public bool Update(Customer updatedCustomer){
        _context.Update(updatedCustomer);
        _context.SaveChanges();
        return true;
    }
    public bool UpdateBalance(Customer updateBalanceCustomerDto){
        _context.Update(updateBalanceCustomerDto);
        _context.SaveChanges();
        return true;
    }
    public bool UpdatePassword(Customer updatePasswordCustomerDto){
        _context.Update(updatePasswordCustomerDto);
        _context.SaveChanges();
        return true;
    }
    public bool UpdateAccountstatus(Customer updateAccountStatusCustomerDto){
        _context.Update(updateAccountStatusCustomerDto);
        _context.SaveChanges();
        return true;
    }
    public bool UpdateLoanstatus(Customer updateLoanStatusCustomerDto){
        _context.Update(updateLoanStatusCustomerDto);
        _context.SaveChanges();
        return true;
    }
    public Customer GetById(int customerId){
        return _context.Customers.Include(c => c.User).SingleOrDefault(c => c.Id == customerId);
    }
    public Customer 
     GetbyAccountNumber(string accountNumber){
        return _context.Customers.Include(c => c.User).Include(c => c.User.Address).FirstOrDefault(c => c.AccountNumber == accountNumber);
    }
    public bool Delete(string accountNumber){
        var customer = _context.Customers.Include(c => c.User.Address).Include(c => c.User).FirstOrDefault(c => c.AccountNumber == accountNumber);
        if (customer == null){
            Console.WriteLine("Customer is Null");
            return false;
        }
        _context.Customers.Remove(customer);
        _context.SaveChanges();
        return true;
    }
    public List<Customer> List(){
        return _context.Customers.Include(c => c.User.Address).Include(c => c.User).ToList();
    }
}