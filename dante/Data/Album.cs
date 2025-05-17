namespace Data
{
    public class Album
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<int> SongIDs { get; set; }

        public Album(int ID, string Title, List<int> ids)
        {
            this.ID = ID;
            this.Title = Title;
            this.SongIDs = ids;
        }
    }
}
