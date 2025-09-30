using System.ComponentModel.DataAnnotations;

namespace OzGecmisAI.Models
{
    public class EducationEntry
    {
        [Required]
        public string Institution { get; set; } = string.Empty;

        [Required]
        public string Degree { get; set; } = string.Empty;

        [Required]
        public string FieldOfStudy { get; set; } = string.Empty;

        [Required]
        public int GraduationYear { get; set; }

        public string? Description { get; set; } = string.Empty;
    }
}
