using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtomasyon2025Udemy.Models
{
    public class ShipmentTracking
    {
        [Key]
        public int ShipmentTrackingID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; }
        public DateTime DateTime { get; set; }
    }
}