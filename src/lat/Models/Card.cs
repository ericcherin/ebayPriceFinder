using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lat.Models
{
    public class Cardd
    {
        public int ID { get; set; }
        public int DeskID { get; set; }
        public string name { get; set; }
        public virtual Desk Desk { get; set; }

        public Cardd() { }
        public Cardd(String name, int DeskID) {
            this.name = name;
            this.DeskID = DeskID;
        }

    }

    public class Desk
    {
        public int ID { get; set; }
        public string named { get; set; }
        public virtual IList<Cardd> Cardds { get; set; }
    }
}
