using System.ComponentModel.DataAnnotations;

namespace OzGecmisAI.Models
{
    public class JobExperience
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Company { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public bool IsCurrent { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
