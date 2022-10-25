using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Attributes;

namespace API.Models
{
    public class Student
    {
        [SwaggerIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserInfoId { get; set; } = Guid.Empty;

        [SwaggerIgnore]
        public int StudentNumber { get; set; }

        [JsonIgnore]
        public ICollection<Class>? Classes { get; set; }
        [JsonIgnore]
        public List<ClassStudent> ClassStudents { get; set; }
    }
}
