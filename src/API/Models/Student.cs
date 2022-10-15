using System.Text.Json.Serialization;
using API.Attributes;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        [SwaggerIgnore]
        public int StudentNumber { get; set; }

        [JsonIgnore]
        public ICollection<Class>? Classes { get; set; }
    }
}
