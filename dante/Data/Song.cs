using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Song
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public Song(int ID, string Title, string Genre)
        {
            this.ID = ID;
            this.Title = Title;
            this.Genre = Genre;
        }
    }
}
