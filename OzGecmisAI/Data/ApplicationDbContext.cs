using Microsoft.EntityFrameworkCore;
using OzGecmisAI.Models;

namespace OzGecmisAI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Resume> Resumes { get; set; }
        public DbSet<JobExperience> JobExperiences { get; set; }
        public DbSet<EducationEntry> EducationEntries { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
