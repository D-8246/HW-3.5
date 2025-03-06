using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_3._5.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int Min { get; set; }
        public int Max { get; set; }
    }
}