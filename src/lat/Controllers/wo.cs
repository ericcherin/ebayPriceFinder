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

        public async Task<ActionResult> Ebay(string searchWords)
        {
             ViewData["searchWords"] = searchWords;
            return View(await EbayApi.getItems(searchWords));  
            
               
        }

       
    }
}
