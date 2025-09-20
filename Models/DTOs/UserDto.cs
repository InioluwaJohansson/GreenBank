using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Models.DTOs;
public class CreateUserDto{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email {get; set;}  
    public Gender Gender {get; set;}
    public int Age {get; set;}
    public AccountStatus AccountStatus {get; set;}
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string NumberLine { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int PostalCode { get; set; }
}
public class UpdateUserDto{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email {get; set;}  
    public Gender Gender {get; set;}
    public int Age {get; set;}
    public string PhoneNumber { get; set; }
    public string NumberLine { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int PostalCode { get; set; }
}
public class UpdateUserPasswordDto{
    public string Password { get; set; }
}
public class UpdateUserAccountStatusDto{
    public AccountStatus AccountStatus { get; set; }
}
public class GetUserDto{
    public string Name { get; set; }
    public string Email {get; set;}  
    public Gender Gender {get; set;}
    public int Age {get; set;}
    public AccountStatus AccountStatus {get; set;}
    public string PhoneNumber { get; set; }
    public string NumberLine { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int PostalCode { get; set; }
}
public class GetUserPasswordDto{
    public string Name { get; set; }
    public string Email {get; set;}  
    public string Password {get; set;}  
    public Gender Gender {get; set;}
    public int Age {get; set;}
    public AccountStatus AccountStatus {get; set;}
    public string PhoneNumber { get; set; }
    public string NumberLine { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int PostalCode { get; set; }
}