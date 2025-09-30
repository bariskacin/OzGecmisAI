using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzGecmisAI.Data;
using OzGecmisAI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationDbContext = OzGecmisAI.Data.ApplicationDbContext;

namespace OzGecmisAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResumesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/resumes
        [HttpPost]
        public async Task<IActionResult> CreateResume([FromBody] Resume resume)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResumeById), new { id = resume.Id }, resume);
        }

        // GET: api/resumes/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Resume>>> GetResumesByUserId(string userId)
        {
            var resumes = await _context.Resumes
                .Include(r => r.PersonalInfo)
                .Include(r => r.Experience)
                .Include(r => r.Education)
                .Include(r => r.Skills)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            if (resumes == null || !resumes.Any())
            {
                return NotFound();
            }

            return Ok(resumes);
        }

        // GET: api/resumes/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Resume>> GetResumeById(int id)
        {
            var resume = await _context.Resumes
                .Include(r => r.PersonalInfo)
                .Include(r => r.Experience)
                .Include(r => r.Education)
                .Include(r => r.Skills)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (resume == null)
            {
                return NotFound($"Resume with ID {id} not found.");
            }

            return Ok(resume);
        }

        // GET: api/resumes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resume>>> GetResumes()
        {
            var resumes = await _context.Resumes
                .Include(r => r.PersonalInfo)
                .Include(r => r.Education)
                .Include(r => r.Experience)
                .Include(r => r.Skills)
                .ToListAsync();

            if (resumes == null || !resumes.Any())
            {
                return NotFound();
            }

            return Ok(resumes);
        }


        // PUT: api/resumes/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateResume(int id, [FromBody] Resume resume)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resume.Id)
            {
                return BadRequest("The ID in the URL does not match the ID in the request body.");
            }

            try
            {
                var existingResume = await _context.Resumes
                    .Include(r => r.PersonalInfo)
                    .Include(r => r.Experience)
                    .Include(r => r.Education)
                    .Include(r => r.Skills)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (existingResume == null)
                {
                    return NotFound($"Resume with ID {id} not found.");
                }

                // Update the existing resume with new values
                _context.Entry(existingResume).CurrentValues.SetValues(resume);

                // Handle related entities
                if (resume.PersonalInfo != null)
                {
                    if (existingResume.PersonalInfo == null)
                    {
                        existingResume.PersonalInfo = resume.PersonalInfo;
                    }
                    else
                    {
                        _context.Entry(existingResume.PersonalInfo).CurrentValues.SetValues(resume.PersonalInfo);
                    }
                }

                // Update Experience
                _context.Set<JobExperience>().RemoveRange(existingResume.Experience);
                existingResume.Experience = resume.Experience;

                // Update Education
                _context.Set<EducationEntry>().RemoveRange(existingResume.Education);
                existingResume.Education = resume.Education;

                // Update Skills
                _context.Set<Skill>().RemoveRange(existingResume.Skills);
                existingResume.Skills = resume.Skills;

                existingResume.LastUpdated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "An error occurred while updating the resume. The resume may have been modified by another user.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the resume.");
            }
        }

        // DELETE: api/resumes/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteResume(int id)
        {
            try
            {
                var resume = await _context.Resumes
                    .Include(r => r.PersonalInfo)
                    .Include(r => r.Experience)
                    .Include(r => r.Education)
                    .Include(r => r.Skills)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (resume == null)
                {
                    return NotFound($"Resume with ID {id} not found.");
                }

                _context.Resumes.Remove(resume);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the resume.");
            }
        }
    }
}
