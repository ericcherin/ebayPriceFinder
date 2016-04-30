
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace lat.Models
{
    
    public class SafeItem
    {
        public int ID { get; set;  }
        public int listID { get; set; }
        public string galleryURL { get; set; }
        public string viewItemURL { get; set; }
        public string title { get; set; }
        public double currentPrice { get; set; }
        public string sold { get; set; }

        public SafeItem() { }

        public SafeItem(Item item)
        {
            if(item.galleryURL != null)
            {
                this.galleryURL = item.galleryURL[0];
            }
            if(item.viewItemURL != null)
            {
                this.viewItemURL = item.viewItemURL[0];
                
            }
            if(item.title != null)
            {
                this.title = item.title[0];
            }
            if(item.sellingStatus != null && item.sellingStatus[0].currentPrice != null)
            {
                this.currentPrice = Double.Parse(item.sellingStatus[0].currentPrice[0].__value__);
            }
        }

        public static async Task<SafeItem> instantiate(Item item, string description)
        {
            
            SafeItem s = new SafeItem(item);
            s.sold = description;

            if (s.viewItemURL != null && s.sold.Length == 0)
            {
                
                s.sold = await isSold(s.viewItemURL);
                
            }
            return s;
        }




        public static async Task<string> isSold(string url)
        {
            var webClient = new System.Net.WebClient();
            string htmlSource = await webClient.DownloadStringTaskAsync(url);

            return htmlSource.Contains("Item Sold") ? "sold" : "not sold";
        }
    }

    public class SafeItemList
    {

        public int ID { get; set; }
        public virtual List<SafeItem> safeItems { get; set; }
        

    }
}