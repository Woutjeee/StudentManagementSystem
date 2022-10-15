namespace API.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        public List<Class>? Classes { get; set; }
    }
}
