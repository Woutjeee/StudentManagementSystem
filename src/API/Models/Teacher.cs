using System.ComponentModel.DataAnnotations.Schema;
using API.Attributes;

namespace API.Models
{
    public class Teacher
    {
        [SwaggerIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserInfoId { get; set; } = Guid.Empty;

        [SwaggerIgnore]
        public List<Class>? Classes { get; set; }
    }
}
