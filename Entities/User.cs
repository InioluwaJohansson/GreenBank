using BankApp.Models.Enums;
namespace BankApp.Entities;
public class User:BaseEntity{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}  
    public Gender Gender {get; set;}
    public int Age {get; set;}
    public AccountStatus AccountStatus {get; set;}
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public Address Address { get; set; }
}
