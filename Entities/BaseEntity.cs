using BankApp.Models.Enums;
namespace BankApp.Entities;
public class BaseEntity{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}
