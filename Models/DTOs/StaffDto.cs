using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Models.DTOs;
public class CreateStaffDto{
    public CreateUserDto User { get; set; }
   public string StaffNo {get; set;}
    public Role Role {get; set;}
}
public class UpdateStaffDto{
    public UpdateUserDto User { get; set; }
    public Role Role {get; set;}
}
public class GetStaffDto{
    public GetUserDto User { get; set; }
    public string StaffNo {get; set;}
    public Role Role {get; set;}
}
public class UpdatePasswordStaffDto{
    public UpdateUserPasswordDto User {get; set;}
}
public class UpdateAccountStatusStaffDto{
    public UpdateUserAccountStatusDto User {get; set;}
}