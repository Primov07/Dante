using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Song
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public Song()
        {
            
        }
        public override string ToString()
        {
            string title = new string(Title.Take(13).ToArray());
            string genre = new string(Genre.Take(13).ToArray());
            if (title != Title)
            {
                title = title.Substring(0, title.Length - 3);
                title = title + "...";
            }
            title = "\"" + title + "\"";
            if (genre != Genre)
            {
                genre = genre.Substring(0, genre.Length - 3);
                genre = genre + "...";
            }
            return $"{title}\n{genre}\n";
        }
    }
}
