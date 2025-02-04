using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemsID { get; set; }


        public string Explanation { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}