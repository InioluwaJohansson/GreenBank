using BankApp.Models.Enums;
namespace BankApp.Entities;
public class Staff:BaseEntity{
    public User User {get; set;}
    public string StaffNo {get; set;}
    public Role Role {get; set;}
}