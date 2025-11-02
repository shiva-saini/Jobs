using Jobs.Data;
using Jobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly AppDbContext _context;
        public JobController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobs()
        {
            // Include Company to load related data
            var jobs = await _context.Jobs
                .Include(j => j.Company)
                .ToListAsync();

            return Ok(jobs);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllAppliedJobs(string userId)
        {
            var jobs = await _context.AppliedJobs
                .Include(j => j.Company)
                .Where(j => j.UserId == userId) // 👈 filter by userId
                .ToListAsync();

            if (jobs == null || !jobs.Any())
            {
                return NotFound($"No jobs found for user ID: {userId}");
            }

            return Ok(jobs);
        }
    }
}
