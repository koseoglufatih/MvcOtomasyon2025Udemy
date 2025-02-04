using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}