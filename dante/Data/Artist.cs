using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public List<int> AlbumIDs { get; set; }
        public List<int> SongIDs { get; set; }
        public Artist(int ID, string Name, double Rating, List<int> AlbumIDs, List<int> SongIDs)
        {
            this.ID = ID;
            this.Name = Name;
            this.Rating = Rating;
            this.AlbumIDs = AlbumIDs;
            this.SongIDs = SongIDs;
        }
    }
}
