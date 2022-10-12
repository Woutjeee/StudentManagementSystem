namespace API.Models
{
    public class Group
    {
        public Guid Id { get; set; }

        public string GroupCode { get; set; }

        public Guid TeacherForeignKey { get; set; }

        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }
    }
}
