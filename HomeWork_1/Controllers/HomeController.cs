using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork_1.Models;
using HomeWork_1.Repository;
using HomeWork_1.Service;

namespace HomeWork_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBookService _accountBookService;
        private readonly UnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
            _accountBookService = new AccountBookService(_unitOfWork);
        }

        public ActionResult Index()
        {
            GetTypeDropdownListModel();
            return View();
        }
        [ChildActionOnly]
        public ActionResult AccountingDetailView()
        {
            IEnumerable<Accounting> accountingBookList = _accountBookService.Lookup();
            return View(accountingBookList);
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

        public List<Accounting> GetAccountings()
        {
            List<Accounting> AccList = new List<Accounting>();
            DateTime Now = DateTime.Now;
            Now = Now.AddYears(-2);
            Random Random = new Random();
            Accounting Accounting = null;
            for (int i = 0; i < 100; i++)
            {
                Accounting = new Accounting();
                int Type = Random.Next(0, 3);
                Accounting.Type = Type;
                int AmountMax = 200000;
                int AmountMin = 20;
                int Amount = Random.Next(AmountMin++, AmountMax);
                Accounting.Amount = Amount;
                int DayRandom = Random.Next(1, 10);
                DateTime AccountingDate = AccList.Count == 0 ? Now.AddDays(DayRandom) : AccList[i - 1].Date.AddDays(DayRandom);
                Accounting.Date = AccountingDate;
                AccList.Add(Accounting);
            }
            return AccList;
        }

        private void GetTypeDropdownListModel()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem()
            {
                Text = "請選擇",
                 Value = "0"
            });
            items.Add(new SelectListItem()
            {
                Text = "支出",
                Value = "1"
            });
            items.Add(new SelectListItem()
            {
                Text = "收入",
                Value = "2"
            });

            ViewData["dr"] = items;
        }
     
        public ActionResult DateValid(DateTime date)
        {
            bool isValidate = DateTime.Now > date; 
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}