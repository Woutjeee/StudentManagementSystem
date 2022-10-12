namespace API.Models
{
    public class ClassStudent
    {
        public DateTime StartDate { get; set; }

        public Guid ClassId { get; set; }
        public Class Class { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
