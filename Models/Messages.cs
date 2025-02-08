﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Receiver { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Contents { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime DateTime { get; set; }
    }
}