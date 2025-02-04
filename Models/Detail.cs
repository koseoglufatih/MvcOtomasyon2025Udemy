using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class Detail
    {
        [Key]
        public int DetailID { get; set; }
        public string ProductName { get; set; }
        public string productInformation { get; set; }
    }
}