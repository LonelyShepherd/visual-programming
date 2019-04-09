using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primer_kol
{
    public class Aeroport
    {
        public string City { get; set; }
        public string Name { get; set; }
        public string ShortCity { get; set; }
        public List<Destination> Destinations { get; set; } = new List<Destination>();

        public override string ToString()
        {
            return $"{ShortCity} - {Name} - {City}";
        }
    }
}
