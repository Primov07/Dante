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
        private bool isDownloaded = false;

        public Song()
        {
            
        }
        public override string ToString()
        {
            return $"\"{Title}\"\n{Genre}";
        }
        public bool IsDownloaded() => isDownloaded;
        public void Download() => isDownloaded = true;
    }
}
