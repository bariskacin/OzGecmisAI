using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzGecmisAI.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public PersonalInfo? PersonalInfo { get; set; }
        public List<JobExperience> Experience { get; set; } = new();
        public List<EducationEntry> Education { get; set; } = new();
        public List<Skill> Skills { get; set; } = new();
    }
}
