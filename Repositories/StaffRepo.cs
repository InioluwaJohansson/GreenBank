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
public class StaffRepository{
    BankAppDbContext _context;
    public StaffRepository(BankAppDbContext bankAppdbcontext){
        _context = bankAppdbcontext;
    }
    public bool Create(Staff staff){
        if (staff == null){
            Console.WriteLine("Staff is Null");
            return false;
        }else{
            _context.Staffs.Add(staff);
            _context.SaveChanges();
            return true;
        }
    }
    public bool Update(Staff updatedStaff){
        _context.Update(updatedStaff);
        _context.SaveChanges();
        return true;
    }
    public bool UpdateAccountstatus(Staff updateAccountStatusStaffDto){
        _context.Update(updateAccountStatusStaffDto);
        _context.SaveChanges();
        return true;
    }
    public Staff GetById(int staffId){
        return _context.Staffs.Include(c => c.User).SingleOrDefault(c => c.Id == staffId);
    }
    public Staff GetbyEmail(string email){
        return _context.Staffs.Include(c => c.User.Address).Include(c => c.User).FirstOrDefault(c => c.User.Email == email);
    }
    public bool Delete(string email){
        var staff = _context.Staffs.FirstOrDefault(x => x.User.Email == email);
        if (staff == null){
            Console.WriteLine("Staff is Null");
            return false;
        }
        _context.Staffs.Remove(staff);
        _context.SaveChanges();
        return true;
    }
    public List<Staff> List(){
        return _context.Staffs.Include(c => c.User.Address).Include(c => c.User).ToList();
    }
}