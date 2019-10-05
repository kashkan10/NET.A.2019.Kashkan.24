using AccSystemMVC.Models;
using System;
using System.Web.Mvc;

namespace AccSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        AccountContext db = new AccountContext();
        public ActionResult Index()
        {
            return View(db.Accounts);
        }

        public ActionResult Details(int id)
        {
            Account acc = db.Accounts.Find(id);
            return View(acc);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Account acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException();
            }
            acc.Bonus += Deposit(acc.Balance, acc.CardType);
            db.Accounts.Add(acc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deposit(int id)
        {
            Account acc = db.Accounts.Find(id);
            if (acc == null)
            {
                throw new ArgumentNullException();
            }

            return View(acc);
        }

        [HttpPost]
        public ActionResult Deposit(int id, int sum)
        {
            Account acc = db.Accounts.Find(id);
            if (acc == null)
            {
                throw new ArgumentNullException();
            }

            acc.Balance += sum;
            acc.Bonus += Deposit(sum, acc.CardType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Withdraw(int id)
        {
            Account acc = db.Accounts.Find(id);
            if (acc == null)
            {
                throw new ArgumentNullException();
            }

            return View(acc);
        }

        [HttpPost]
        public ActionResult Withdraw(int id, int sum)
        {
            Account acc = db.Accounts.Find(id);
            if (acc == null)
            {
                throw new ArgumentNullException();
            }

            acc.Balance -= sum;
            acc.Bonus -= Withdraw(sum, acc.CardType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Close(int id)
        {
            db.Accounts.Remove(db.Accounts.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Transaction(int id)
        {
            Account acc = db.Accounts.Find(id);
            if (acc == null)
            {
                throw new ArgumentNullException();
            }

            return View(acc);
        }

        [HttpPost]
        public ActionResult Transaction(int id, int idTo, int sum)
        {
            Account acc = db.Accounts.Find(id);
            Account accTo = db.Accounts.Find(idTo);
            if (acc == null && accTo == null)
            {
                throw new ArgumentNullException();
            }

            acc.Balance -= sum;
            accTo.Balance += sum;
            acc.Bonus -= Withdraw(sum, acc.CardType);
            accTo.Bonus += Deposit(sum, accTo.CardType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private int Deposit(decimal sum, CardType type)
        {
            return (int)sum * (int)type / 100;
        }

        private int Withdraw(decimal sum, CardType type)
        {
            return (int)sum * (int)type / 200;
        }
    }
}