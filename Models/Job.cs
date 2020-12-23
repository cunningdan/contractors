namespace contractors.Models
{
    public class Job
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public int Id { get; set; }
        public int Budget { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }
}