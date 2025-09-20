using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankApp.Entities;
public class Complaint: BaseEntity{
    public string AccountNumber { get; set; }
    public string Description { get; set; }
}