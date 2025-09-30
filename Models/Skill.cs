using System.ComponentModel.DataAnnotations;

namespace OzGecmisAI.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ProficiencyLevel { get; set; } = string.Empty;
    }
}
