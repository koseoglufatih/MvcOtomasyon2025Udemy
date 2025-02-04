using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class SalesTransaction
    {
        [Key]
        public int SalesTransactionId { get; set; }
        //product
        //current
        //employee

        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        public int ProductID { get; set; }
        public int CurrentID { get; set; }
        public int PersonelID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Employee Employee { get; set; }

    }
}