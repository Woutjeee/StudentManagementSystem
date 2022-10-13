using System.Text.Json.Serialization;

namespace API.Models
{
    public class Class
    {
        public Guid Id { get; set; }

        public string ClassName { get; set; }

        public string ClassRoom { get; set; }

        [JsonIgnore]
        public List<Student>? Students { get; set; }

        public Guid TeacherForeignKey { get; set; }

        [JsonIgnore]
        public Teacher? Teacher { get; set; }
    }
}
