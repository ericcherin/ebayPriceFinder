
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lat.Models
{

    public class CachedSearch
    {
        public int ID { get; set;}
        public string searchTerms { get; set; }
        public SafeItemList si { get; set; }
    }

    
}