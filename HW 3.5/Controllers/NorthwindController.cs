using HW_3._5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_3._5.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult SearchProducts()
        {
            return View();
        }
        public ActionResult SearchResults(int min, int max)
        {
            NorthwindManager manager = new NorthwindManager(Properties.Settings.Default.connectionString);
            ProductViewModel pm = new ProductViewModel
            {
                Products = manager.GetProdcutsByMinAndMax(min, max),
                Min = min,
                Max = max,
            };
            return View(pm);
        }
    }
}