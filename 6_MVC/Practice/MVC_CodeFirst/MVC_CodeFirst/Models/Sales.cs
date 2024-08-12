using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_CodeFirst.Models
{
    public class Sales
    {
        [Key]
        public string Id { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
    }
}