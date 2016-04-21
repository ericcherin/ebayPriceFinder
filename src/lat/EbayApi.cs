using lat.Models.Completed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lat
{
    public static class EbayApi
    {
        public static SafeItems getKeyWords(String searchWords)
        {
            // credentials are hard-coded for this example
            // string devId = "410bc734-250c-42fd-9a6a-40e902d389ac";     // use your dev ID
            string appId = "EricCher-a6f5-479e-b242-ce0cb0884801";     // use your app ID
            //string certId = "47b2b978-b988-44c6-903d-08df8012d222";   // use your cert ID
            //string token = "AgAAAA**AQAAAA**aAAAAA**0V8KVw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AAlIGgDpeGpQ+dj6x9nY+seQ**lR4DAA**AAMAAA**91/+76sTt1//Dy45JRbVyB0Td2P4jX/uE+50yfrMUALP+bqdlf0fFz4Hdnd+Wx3XML7msR7yboQbbbSyI9qpHssAcMpipAT4cl83H0U6/vvNNqbiA4uKsOwlM+KoPlGQUUNRf36dNLIg96JkBC7ofasG/aDRJJhQKi/B7ID+82p1np/z4W/UuAi0qI2w5kkFDUixIxGGrFMCLNwubmvNcjGIkYbMhWJ5kRqOtVWYy8hhBXmnr3RB86+AKIi3Fu/0ccYq4ISDgetxyKlEXlBLVjO5A2/oH6XzHDkeozK4nnkrFiFZl6CoR9EDfdN1slCa76iNF3ntBhuuRLFrYInj/3IBP9gKnl71P8RD/0JTjn/xKXrKvWvsUw08jnaKh/6MAKNDgtpAmeB2eOq8DbLGgu1X1v6dlDIymG2qZ9Ri9TKpnrcccAalXyf6Q5oWgquU58Y0PX2N5LmRsLDqrUrUklUBhFU+vcnlKrswKfZnt98+I3AI+1O5KjPJDSNe0WBy7pleOKLlTas86c60N+ibTYDHh+oieDTYTNznHNxLYYe3X0A1MIsoC/viPRsn36Y88T3ba1yTQusHXwje4bGTDyjv0Vd/kj634PjUtN9hKSbqJv2/8OomMwMRtzP7lyBYDIqXOYwhRo50Xoofo7Pqob5mQy3imngvYkt1erMGuX8swlgt6/lip/SHCgbdXj7J5pVDPbMbRYxxjlE7Mg5kniy9L592MXpb/5gbP2VMSoVlayVCPjpnetPg9JZIx6LS";    // use your token

            string callName = "findCompletedItems";
            string dataFormat = "JSON&REST-PAYLOAD";
            string entriesPerPage = "100";
            string serviceVersion = "1.0.0";

            string requestURL = "http://svcs.ebay.com/services/search/FindingService/v1?";
            requestURL += "SECURITY-APPNAME=" + appId;
            requestURL += "&OPERATION-NAME=" + callName;
            requestURL += "&SERVICE-VERSION=" + serviceVersion;
            requestURL += "&RESPONSE-DATA-FORMAT=" + dataFormat;
            requestURL += "&keywords=" + searchWords;
            requestURL += "&paginationInput.entriesPerPage=" + entriesPerPage;

            var webClient = new System.Net.WebClient();

            string json = webClient.DownloadString(requestURL);
            // Now parse with JSON.Net

            FindCompleted unsafeItems = JsonConvert.DeserializeObject<FindCompleted>(json); ;
            SafeItems safeItems = toSafety(unsafeItems);

            return safeItems;
            
        }

        public static SafeItems toSafety(FindCompleted unsafeItems)
        {
            List<SafeItem> safeItemList = new List<SafeItem>();

            if (unsafeItems.findCompletedItemsResponse != null && unsafeItems.findCompletedItemsResponse[0].searchResult != null)
            {
                unsafeItems.findCompletedItemsResponse[0].searchResult[0].item.ForEach(x =>
                {

                    safeItemList.Add(new SafeItem(x));
                });
            }

            SafeItems safeItems = new SafeItems();
            safeItems.safeItems = safeItemList;

            return safeItems;
        }
    }
}
