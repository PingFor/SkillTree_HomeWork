using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork_1.Models
{
    public class Accounting
    {
        public string Id { get; set; }
        [Range(1, 2, ErrorMessage = "請選擇類別")]        
        public int Type { get; set; } //1.expenditure //2.income
        [Range(1, int.MaxValue)]
        [Required(AllowEmptyStrings = false)]
        public int Amount { get; set; }
        [Required(AllowEmptyStrings = false)]       
        [Remote("DateValid", "Home", AreaReference.UseRoot, ErrorMessage = "日期不能大於今日")]
        public DateTime Date { get; set; }

        [StringLength(100)]
        public String Remark { get; set; }
    }
}