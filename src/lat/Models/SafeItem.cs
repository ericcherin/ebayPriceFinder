
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace lat.Models
{

    public class SafeItem
    {
        public int ID { get; set; }
        public int listID { get; set; }
        public string galleryURL { get; set; }
        public string viewItemURL { get; set; }
        public string title { get; set; }
        public double currentPrice { get; set; }
        public string sold { get; set; }
        public string quantitySold { get; set;}

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

        public static async Task<SafeItem> instantiateOld(Item item, string description)
        {
            
            SafeItem s = new SafeItem(item);
            s.sold = description;

            if (s.viewItemURL != null )
            {
                var webClient = new System.Net.WebClient();
                string htmlSource = await webClient.DownloadStringTaskAsync(s.viewItemURL);
                if(s.sold.Length == 0)
                {
                    s.sold = isSold(htmlSource);
                }

                s.quantitySold = await getQuantitySold(htmlSource, webClient, s.title);
            }
            return s;
        }

        public static async Task<SafeItem> instantiate(Item item, string description)
        {

            SafeItem s = new SafeItem(item);
            s.sold = description;

            if (s.viewItemURL != null)
            {
                var webClient = new System.Net.WebClient();
                string htmlSource = await webClient.DownloadStringTaskAsync(s.viewItemURL);
                if (s.sold.Length == 0)
                {
                    s.sold = isSold(htmlSource);
                }

                s.quantitySold = await getQuantitySold(htmlSource, webClient, s.title);
            }
            return s;
        }

        public static SafeItem instantiateFast(Item item, string description)
        {
            SafeItem s = new SafeItem(item);
            s.sold = description;
            return s;
        }

        public static async Task<string >getQuantitySold(string htmlSource, System.Net.WebClient webClient, string title)
        {
            int lineSold = htmlSource.IndexOf(" sold</a");

            if(lineSold == -1)
            {
                return "0";
            }
            
            int htmlEnd = 0;
            int htmlStart = 0;
            for (int index = lineSold; htmlSource[index] != '<'; index--)
            {
                if(htmlSource[index] == '\"')
                {
                    if(htmlEnd == 0)
                    {
                        htmlEnd = index - 1;
                        index--;
                    }
                    else
                    {
                        htmlStart = index + 1;
                        break;
                    }
                    
                    
                }
            }

            

            string htmlLink = htmlSource.Substring(htmlStart, htmlEnd - htmlStart + 1);
            htmlLink = clean(htmlLink);
           
            string htmlNumberSource = await webClient.DownloadStringTaskAsync(htmlLink);
            string findRow = "\">US ";
            


            int indexStart = htmlNumberSource.IndexOf(findRow);
            if (indexStart == -1)
            {
                return "0";
            }

            int count = 0;
            double sum = 0;
            for (; indexStart != -1; indexStart = htmlNumberSource.IndexOf(findRow, indexStart+1))
            {
                int numberStart = htmlNumberSource.IndexOf("$", indexStart);
                int numberEnd = htmlNumberSource.IndexOf("<", indexStart);
                int length = numberEnd - numberStart - 1;

                if (length != 0)
                {
                    double ammount;
                    string sAmount = htmlNumberSource.Substring(numberStart+1, length);
                    if (Double.TryParse(sAmount,out ammount)){
                        count++;
                        sum += ammount;
                    }
                }


            }
            double average = Math.Truncate(sum * 100 / count) / 100 ;
            

            return count + " items sold for an average of $" + average;
        }

        public static string clean(string s)
        {
            s = s.Replace("amp;", "");
            return s;
        }
        public static string isSold( string htmlSource)
        {
            return htmlSource.Contains("Item Sold") ? "sold" : "not sold";
        }
    }

    public class SafeItemList
    {

        public int ID { get; set; }
        public virtual List<SafeItem> safeItems { get; set; }
        

    }
}