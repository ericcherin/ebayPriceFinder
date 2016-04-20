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
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace lat.Controllers
{
    public class wo : Controller
    {



       

        [HttpPost]
        public string rawr(SchoolImages model)
        {
            string createText = "Hel1111o and Welcome " + model.images[0].url;

            return createText;
        }

        [HttpPost]
        public string da(SafeItems safeItems)
        {

            string createText = "Hel1111o and Welcome " + safeItems.safeItems[0].currentPrice;
            return createText;
        }


        public IActionResult Ebay()
        {
      

            SafeItems safeItems = new SafeItems();
            List<SafeItem> result = new List<SafeItem>();

            SafeItem s1 = new SafeItem();
            s1.currentPrice = "123";
            SafeItem s2 = new SafeItem();
            s2.currentPrice = "34";
            result.Add(s1);
            result.Add(s2);
            safeItems.safeItems = result;
           
           

            return View(safeItems);  
        }

        
        public IActionResult roa()
        {
            // Create a file to write to. 

            SchoolImages s = new SchoolImages();
            List<ImageModel> list = new List<ImageModel>();
            ImageModel t1 = new ImageModel();
            t1.url = "mo";
            ImageModel t2 = new ImageModel();
            t2.url = "fosho";
            list.Add(t2);
            list.Add(t1);

            s.images = list;
            return View(s);
        }
        
    }
}
