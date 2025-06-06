namespace Data
{
    public class Album
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<long> Songs { get; set; }
        public Album()
        {

        }
        public override string ToString()
        {
            string title = new string(Title.Take(13).ToArray());
            if (title != Title)
            {
                title = title.Substring(0, title.Length - 3);
                title = title + "...";
            }
            title = "\"" + title + "\"";
            return $"{title}\n";
        }
    }
}
