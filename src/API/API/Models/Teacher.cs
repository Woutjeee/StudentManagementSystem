namespace API.Models
{
    public class Teacher
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

        public List<Class> Classes { get; set; }
    }
}
