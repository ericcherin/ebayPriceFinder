
using System;
using System.Collections.Generic;
namespace lat.Models.Completed
{
    public class SafeItem
    {
        public string galleryURL { get; set; }
        public string viewItemURL { get; set; }
        public string title { get; set; }
        public double currentPrice { get; set; }
        public string completed { get; set; }

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
    }

    public class SafeItems
    {
        public IList<SafeItem> safeItems { get; set; }

    }
}