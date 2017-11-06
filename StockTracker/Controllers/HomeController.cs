using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using StockTracker.Models;

namespace StockTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Stock> customers = new List<Stock>();
            string filePath = "/Users/mitchellrsistrunk/Documents/Apps/StockTracker/StockTracker/Data/NBRHistory.csv";


            //Read the contents of CSV file.
            string csvData = System.IO.File.ReadAllText(filePath);

            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    customers.Add(new Stock
                    {
                        Date = row.Split(',')[0],
                        Price = Convert.ToDouble(row.Split(',')[1])
                    });
                }
            }


            return View(customers);
        }
    }
}
