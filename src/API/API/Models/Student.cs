namespace API.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Postalcode { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public int Phonenumber { get; set; }

        public ICollection<Class> Classes { get; set; }
        public List<ClassStudent> ClassStudents { get; set; }
    }
}
