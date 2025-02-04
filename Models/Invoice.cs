using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public string InvoiceSerialNumber { get; set; }
        public string InvoiceSequenceNumber { get; set; }

        public string Date { get; set; }
        public string TaxOffice { get; set; }
        public DateTime Hour { get; set; }
        public string Deliverer { get; set; }
        public string Recipient { get; set; }

        public decimal Total { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }


    }
}