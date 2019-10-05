using System.Data.Entity;

namespace AccSystemMVC.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<AccountContext>
    {
        protected override void Seed(AccountContext db)
        {
            db.Accounts.Add(new Account { Owner = "Don Omar", Balance = 220 , CardType = CardType.Base});
            db.Accounts.Add(new Account { Owner = "Mike Shult", Balance = 180, CardType = CardType.Gold });
            db.Accounts.Add(new Account { Owner = "Lex Ron", Balance = 150, CardType = CardType.Platinum });

            base.Seed(db);
        }
    }
}