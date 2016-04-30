using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lat.Models
{

    public class Statistics
    {
        public double mean { get; set; }
        public double median { get; set; }
        public double lowerQuartile { get; set; }
        public double upperQuartile { get; set; }

        public void getStats( List<double> numbers)
        {
            int size = numbers.Count;

            if(size == 0)
            {
                return;
            }

            numbers.Sort();

            mean = numbers.Sum()/size;
            median = numbers[size / 2];
            lowerQuartile = numbers[size / 4];
            upperQuartile = numbers[size * 3 / 4];
        }

       
    }
}
