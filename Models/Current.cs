using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class Current
    {
        public int CurrentID { get; set; }

        //[Required]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz")]
        public string CurrentName { get; set; }

        //[Required]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentSurname { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CurrentPassword { get; set; }
        public bool Status { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}