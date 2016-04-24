using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNet.Mvc;
using eBay.Service.Core.Soap;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;
using lat.Models.Completed;
using log4net;
using StackExchange.Profiling;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace lat.Controllers
{
    public class wo : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

          
            return View("EnterSearch");
        }

        // GET: /<controller>/
        public IActionResult chart()
        {

           
            return View();
        }


       

        public IActionResult SearchOn()
        {
            //ViewData["searchWords"] = searchWords;
            return View();
        }

        public IActionResult EnterSearch()
        {
            
            return View();
        }

        public async Task<ActionResult> Ebay(SafeItems model, string searchWords, string filter, string lower, string higher)
        {

             ViewData["searchWords"] = searchWords;
            SafeItems si;
            Writer.appendString("hi");
            Writer.appendString(searchWords + " 1 " + filter + " 2 " + lower + " 3 " + higher);
            if (("Filter").Equals(filter) && model != null)
            {
                
                double lowerBound = isValid(lower) ? Double.Parse(lower) : 0;
                double upperBound = isValid(higher) ? Double.Parse(higher) : double.MaxValue;
                si = new SafeItems();
                si.safeItems = new List<SafeItem>();
                foreach(SafeItem s in model.safeItems)
                {
                    if (s.currentPrice > lowerBound && s.currentPrice < upperBound)
                    {
                        si.safeItems.Add(s);
                    }
                }
            }
            else
            {
                si = await EbayApi.getItems(searchWords);
            }
            

            return View(si);  
            
               
        }

        private bool isValid(string s)
        {
            if(s.Length < 1)
            {
                return false;
            }
            try
            {
                Double.Parse(s);
                return true;
            }
            catch { }
            return false;
            
        }

       
    }
}
