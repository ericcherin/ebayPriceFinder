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
using log4net;
using StackExchange.Profiling;
using lat.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace lat.Controllers
{
    public class wo : Controller
    {
        private ApplicationDbContext _context;

        public wo(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

          
            return View(); //"Ebay"
        }

        // GET: /<controller>/
        public String chart()
        {


            return EbayApi.getResponse("bottle", "findCompletedItems", false, false) ;
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

        public async Task<ActionResult> Ebay(string searchWords, string filter, string lower, string higher)
        {
            
            ViewData["searchWords"] = searchWords;
            SafeItemList si = new SafeItemList(); ;

            if(searchWords == null || searchWords.Length == 0)
            {    
                si.safeItems = new List<SafeItem>();
                return View(si);
            }

            CachedSearch cachedSearch = _context.CachedSearch.LastOrDefault(m => m.searchTerms.Equals(searchWords));
            if ( !("Filter").Equals(filter))
            {
                Writer.appendString("heythere");
                si = await EbayApi.getItems(searchWords);
                cachedSearch = new CachedSearch();
                cachedSearch.searchTerms = searchWords;
                cachedSearch.si = si;

                _context.CachedSearch.Add(cachedSearch);
                _context.SaveChanges();

                foreach (SafeItem item in si.safeItems)
                {
                    item.listID = cachedSearch.ID;
                    _context.SafeItem.Add(item);
                }
                _context.SaveChanges();

              
            }
            else
            {
                si.safeItems = _context.SafeItem.Where(m => m.listID == cachedSearch.ID).ToList();
               
          
            }

            si.safeItems = si.safeItems.OrderByDescending(a => a.currentPrice).ToList();   
                   
            if (("Filter").Equals(filter))
            {
                SafeItemList tempSi;
                double lowerBound = isValid(lower) ? Double.Parse(lower) : 0;
                double upperBound = isValid(higher) ? Double.Parse(higher) : double.MaxValue;
                tempSi = new SafeItemList();
                tempSi.safeItems = new List<SafeItem>();
                foreach(SafeItem s in si.safeItems)
                {
                    if (s.currentPrice > lowerBound && s.currentPrice < upperBound)
                    {
                        tempSi.safeItems.Add(s);
                    }
                }
                return View(tempSi);
            }
           
            

            return View(si);  
            
               
        }

        private bool isValid(string s)
        {
            if(s == null)
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
