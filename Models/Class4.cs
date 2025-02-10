using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Models
{
    public class Class4
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
    }
}