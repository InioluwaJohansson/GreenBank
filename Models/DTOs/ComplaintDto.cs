using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Models.DTOs;
public class CreateComplaintDto{
    public string Description {get; set;}
    public string AccountNumber {get; set;}
}
public class GetComplaintDto{
    public string AccountNumber {get; set;}
    public string Description {get; set;}
}