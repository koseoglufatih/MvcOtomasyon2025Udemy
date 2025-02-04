using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class Employee
    {
        [Key]
        public int PersonelID { get; set; }

        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelName { get; set; }


        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSurName { get; set; }


        [Display(Name = "Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeVisiual { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}