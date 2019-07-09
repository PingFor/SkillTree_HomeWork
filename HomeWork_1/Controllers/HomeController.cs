using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork_1.Models;

namespace HomeWork_1.Controllers
{
    public class HomeController : Controller
    {
        public List<Accounting> AccountingList { get; set; }
        public ActionResult Index()
        {
            AccountingList = GetAccountings();
            return View(AccountingList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<Accounting> GetAccountings() {
            List<Accounting> AccList = new List<Accounting>();
            DateTime Now = DateTime.Now;
            Now = Now.AddYears(-2);
            Random Random = new Random();
            Accounting Accounting = null;
            for (int i = 0; i < 100; i++)
            {
                Accounting = new Accounting();
                int Type = Random.Next(0,3);
                Accounting.Type = Type;
                int AmountMax = 200000;
                int AmountMin = 20;
                int Amount = Random.Next(AmountMin++, AmountMax);                             
                Accounting.Amount = Amount;                
                int DayRandom = Random.Next(1,10);
                DateTime AccountingDate = AccList.Count == 0 ? Now.AddDays(DayRandom) : AccList[i - 1].Date.AddDays(DayRandom);
                Accounting.Date = AccountingDate;
                AccList.Add(Accounting);
            }
            return AccList;
        }
    }
}