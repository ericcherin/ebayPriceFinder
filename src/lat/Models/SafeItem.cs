
using System.Collections.Generic;
namespace lat.Models.Completed
{
    public class SafeItem
    {
        public string galleryURL;
        public string viewItemURL;
        public string title;
        public string currentPrice;

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
                this.currentPrice = item.sellingStatus[0].currentPrice[0].__value__;
            }
        }
    }
}