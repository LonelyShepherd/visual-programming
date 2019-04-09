using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer_kol
{
    public class Destination
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public float Price { get; set; }

        public override string ToString()
        {
            return $"{Name}\t{Length}km - {Price}EUR";
        }
    }
}
