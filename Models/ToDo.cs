using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }

    }
}