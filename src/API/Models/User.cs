using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Attributes;

namespace API.Models
{
    public class User
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

        [NotMapped]
        public string Password { get; set; } = "Welkom1!";

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
