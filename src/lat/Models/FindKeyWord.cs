using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lat.Models
{
    public class PrimaryCategory
    {
        public List<string> categoryId { get; set; }
        public List<string> categoryName { get; set; }
    }

    public class ShippingServiceCost
    {
        public string currencyId { get; set; }
        public string __value__ { get; set; }
    }

    public class ShippingInfo
    {
        public List<ShippingServiceCost> shippingServiceCost { get; set; }
        public List<string> shippingType { get; set; }
        public List<string> shipToLocations { get; set; }
        public List<string> expeditedShipping { get; set; }
        public List<string> oneDayShippingAvailable { get; set; }
        public List<string> handlingTime { get; set; }
    }


    public class SellingStatus
    {
        public List<CurrentPrice> currentPrice { get; set; }
        public List<ConvertedCurrentPrice> convertedCurrentPrice { get; set; }
        public List<string> sellingState { get; set; }
        public List<string> timeLeft { get; set; }
        public List<string> bidCount { get; set; }
    }



    public class ProductId
    {
        public string type { get; set; }
        public string __value__ { get; set; }
    }



    public class RootObject
    {
        public List<FindItemsByKeywordsResponse> findItemsByKeywordsResponse { get; set; }
    }
}

