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

       

        [HttpPost]
        public IActionResult roa(SchoolImages model)
        {
            try {
                string createText = "Hello and Welcome " + model.images[0].url + " and " + model.images[1].url;
                System.IO.File.WriteAllText("C:\\Users\\echerin\\Desktop\\tes1.txt", createText);
            }
            catch(Exception e)
            {
                string createText = "oh no! " + e;
                System.IO.File.WriteAllText("C:\\Users\\echerin\\Desktop\\tes1.txt", createText);
            }
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

        [HttpPost]
        public IActionResult rawr(SchoolImages model)
        {
            string createText = "Hel1111o and Welcome " + model.images[0].url;
            System.IO.File.WriteAllText("C:\\Users\\echerin\\Desktop\\tes1.txt", createText);
            return View(model);
        }

        [HttpPost]
        public IActionResult DisplayStats(SafeItems model)
        {
            //ViewData["searchWords"] = searchWords;
            Statistics stats = new Statistics();
            List<double> numbers = new List<double>();

            string createText = "Hel1111o and Welcome " + model.safeItems[0].currentPrice;
            System.IO.File.WriteAllText("C:\\Users\\echerin\\Desktop\\tes1.txt", createText);

            if (model != null && model.safeItems != null)
            {
                foreach (SafeItem s in model.safeItems)
                {
                    
                        numbers.Add(Double.Parse(s.currentPrice));
                    
                }
            }
            else
            {
                numbers.Add(1);
            }
            stats.getStats(numbers);
            
            return View("DisplayStats", stats);
        }


        public IActionResult Ebay(string searchWords)
        {
            // credentials are hard-coded for this example
           // string devId = "410bc734-250c-42fd-9a6a-40e902d389ac";     // use your dev ID
            string appId = "EricCher-a6f5-479e-b242-ce0cb0884801";     // use your app ID
            //string certId = "47b2b978-b988-44c6-903d-08df8012d222";   // use your cert ID
            //string token = "AgAAAA**AQAAAA**aAAAAA**0V8KVw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AAlIGgDpeGpQ+dj6x9nY+seQ**lR4DAA**AAMAAA**91/+76sTt1//Dy45JRbVyB0Td2P4jX/uE+50yfrMUALP+bqdlf0fFz4Hdnd+Wx3XML7msR7yboQbbbSyI9qpHssAcMpipAT4cl83H0U6/vvNNqbiA4uKsOwlM+KoPlGQUUNRf36dNLIg96JkBC7ofasG/aDRJJhQKi/B7ID+82p1np/z4W/UuAi0qI2w5kkFDUixIxGGrFMCLNwubmvNcjGIkYbMhWJ5kRqOtVWYy8hhBXmnr3RB86+AKIi3Fu/0ccYq4ISDgetxyKlEXlBLVjO5A2/oH6XzHDkeozK4nnkrFiFZl6CoR9EDfdN1slCa76iNF3ntBhuuRLFrYInj/3IBP9gKnl71P8RD/0JTjn/xKXrKvWvsUw08jnaKh/6MAKNDgtpAmeB2eOq8DbLGgu1X1v6dlDIymG2qZ9Ri9TKpnrcccAalXyf6Q5oWgquU58Y0PX2N5LmRsLDqrUrUklUBhFU+vcnlKrswKfZnt98+I3AI+1O5KjPJDSNe0WBy7pleOKLlTas86c60N+ibTYDHh+oieDTYTNznHNxLYYe3X0A1MIsoC/viPRsn36Y88T3ba1yTQusHXwje4bGTDyjv0Vd/kj634PjUtN9hKSbqJv2/8OomMwMRtzP7lyBYDIqXOYwhRo50Xoofo7Pqob5mQy3imngvYkt1erMGuX8swlgt6/lip/SHCgbdXj7J5pVDPbMbRYxxjlE7Mg5kniy9L592MXpb/5gbP2VMSoVlayVCPjpnetPg9JZIx6LS";    // use your token

            //            string requestURL = "http://svcs.ebay.com/services/search/FindingService/v1?SECURITY-APPNAME=EricCher-a6f5-479e-b242-ce0cb0884801&OPERATION-NAME=findItemsByKeywords&SERVICE-VERSION=1.0.0&RESPONSE-DATA-FORMAT=JSON&REST-PAYLOAD&keywords=iphone%203g&paginationInput.entriesPerPage=100";

            // call name, site id, and version are required
            string callName = "findCompletedItems";
            string dataFormat = "JSON&REST-PAYLOAD";
            //searchWords = searchWords"iphone 5g";
            string entriesPerPage = "100";
            string serviceVersion = "1.0.0";
            // build the request url

            string requestURL = "http://svcs.ebay.com/services/search/FindingService/v1?";
            requestURL += "SECURITY-APPNAME=" + appId;
            requestURL += "&OPERATION-NAME=" + callName;
            requestURL += "&SERVICE-VERSION=" + serviceVersion;
            requestURL += "&RESPONSE-DATA-FORMAT=" +dataFormat;
            requestURL += "&keywords=" + searchWords;
            requestURL += "&paginationInput.entriesPerPage=" + entriesPerPage;

            var webClient = new System.Net.WebClient();
            
            string json = webClient.DownloadString(requestURL);
            // Now parse with JSON.Net


            FindCompleted v;
            v = JsonConvert.DeserializeObject<FindCompleted>(json);

            List<SafeItem> result = new List<SafeItem>();

            if (v.findCompletedItemsResponse != null && v.findCompletedItemsResponse[0].searchResult != null)
            {
                v.findCompletedItemsResponse[0].searchResult[0].item.ForEach(x =>
                {
                    
                    result.Add(new SafeItem(x));
                });
            }
            //Tuple<List<SafeItem>, Boolean[]> t = Tuple.Create(result, new bool[result.Count]);
            ViewData["searchWords"] = searchWords;

            //string createText = "Hel1111o and Welcome " + result[0].currentPrice;
            //System.IO.File.WriteAllText("C:\\Users\\echerin\\Desktop\\tes1.txt", createText);
            SafeItems safeItems = new SafeItems();
            safeItems.safeItems = result;
            string tt = "";
            foreach(SafeItem safeItem in safeItems.safeItems)
            {
                tt += safeItem.currentPrice + " ";
           
            }
            System.IO.File.WriteAllText("C:\\Users\\echerin\\Desktop\\tes1.txt", tt);
            return View(safeItems);  
        }

        public IActionResult roa()
        {
            // Create a file to write to. 

            SchoolImages s = new SchoolImages();
            List<ImageModel> list = new List<ImageModel>();
            ImageModel t1 = new ImageModel("stow");

            ImageModel t2 = new ImageModel("grass");

            list.Add(t2);
            list.Add(t1);

            s.images = list;
            return View(s);
        }
    }
}
