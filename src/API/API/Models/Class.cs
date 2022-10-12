namespace API.Models
{
    public class Class
    {
        public Guid Id { get; set; }

        public string ClassName { get; set; }

        public int ClassRoom { get; set; }

        public ICollection<Student> Students { get; set; }

        public Guid TeacherForeignKey { get; set; }

        public Teacher Teacher { get; set; }
    }
}
