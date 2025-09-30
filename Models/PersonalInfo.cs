using System.ComponentModel.DataAnnotations;

namespace OzGecmisAI.Models
{
    public class PersonalInfo
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        public string? LinkedInProfile { get; set; } = string.Empty;

        [Required]
        public string Summary { get; set; } = string.Empty;
    }
}
