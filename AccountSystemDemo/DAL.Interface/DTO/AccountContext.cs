using System.Data.Entity;

namespace DAL.Interface.DTO
{
    public class AccountContext : DbContext
    {
        public AccountContext()
           : base("DbConnection")
        {
            Database.SetInitializer<AccountContext>(new DropCreateDatabaseAlways<AccountContext>());
        }

        public DbSet<AccountDTO> Accounts { get; set; }
    }
}
