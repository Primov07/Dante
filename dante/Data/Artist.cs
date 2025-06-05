using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Artist
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public List<long> Albums { get; set; }
        public List<long> Songs { get; set; }
        public Artist()
        {
            
        }
        public override string ToString()
        {
            return $"{Name}\n{Rating}";
        }
    }
}
