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
    }
}
