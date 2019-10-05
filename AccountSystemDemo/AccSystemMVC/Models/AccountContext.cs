using System.Data.Entity;

namespace AccSystemMVC.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}