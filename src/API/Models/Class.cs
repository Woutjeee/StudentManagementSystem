using System.Text.Json.Serialization;
using API.Attributes;

namespace API.Models
{
    public class Class
    {
        public Guid Id { get; set; }

        public string ClassName { get; set; }

        public string ClassRoom { get; set; }

        [SwaggerIgnore]
        public ICollection<Student>? Students { get; set; }
        [JsonIgnore]
        public List<ClassStudent> ClassStudents { get; set; }

        public Guid TeacherForeignKey { get; set; }

        [JsonIgnore]
        public Teacher? Teacher { get; set; }
    }
}
