using Microsoft.EntityFrameworkCore;
using BankApp.Entities;
namespace BankApp.Context
{
    public class BankAppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;database=BankingApp;port=3306;password=Inioluwa10%");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
