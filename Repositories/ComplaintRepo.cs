using BankApp.Context;
using BankApp.Entities;
using BankApp.Models.Enums;
using Microsoft.EntityFrameworkCore;
namespace BankApp.Repositories;
public class ComplaintRepository{
    private readonly BankAppDbContext _context;
    public ComplaintRepository(BankAppDbContext bankAppdbcontext){
        _context = bankAppdbcontext;
    }
    public bool Create(Complaint complaint){
        if (complaint == null){
            Console.WriteLine("Complaint is Null");
            return false;
        }else{
            _context.Complaints.Add(complaint);
            _context.SaveChanges();
            return true;
        }
    }
    public List<Complaint> ListAll(){
        return _context.Complaints.ToList();
    }
    public List<Complaint> List(string acccountNumber){
        return _context.Complaints.Where(x => x.AccountNumber == acccountNumber).ToList();
    }
}