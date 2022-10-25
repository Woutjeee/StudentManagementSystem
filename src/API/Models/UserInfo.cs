using System.ComponentModel.DataAnnotations.Schema;
using API.Attributes;

namespace API.Models
{
    public class UserInfo
    {
        [SwaggerIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Postalcode { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public string Password { get; set; } = "Welkom1!";

        public string Role { get; set; } = Enums.Role.NewAccount.ToString();
    }
}
