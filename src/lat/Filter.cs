﻿using lat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lat
{
    public class Filter
    {
        public static void basic(SafeItemList safeItems, string completed, double lowestPrice = 0, double highestPrice = double.MaxValue)
        {
            safeItems.safeItems.Where(x => {
                if( x.currentPrice >= lowestPrice && x.currentPrice <= highestPrice)
                {
                    if(completed.Equals("") || completed.Equals(x.sold))
                    {
                        return true;
                    }
                }

                return false;
            });
            
        }
    }
}
