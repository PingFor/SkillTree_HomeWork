using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork_1.Models
{
    public class Accounting
    {
        public string Id { get; set; }
        public int Type { get; set; } //1.expenditure //2.income
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}