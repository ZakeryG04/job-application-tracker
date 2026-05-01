using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobTracker.Api.Data;
using JobTracker.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JobTracker.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class JobApplicationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public JobApplicationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetJobs()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var jobs = await _context.JobApplications
            .Where(j => j.UserId == userId)
            .ToListAsync();

        return Ok(jobs);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob(JobApplication job)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        job.UserId = userId;

        _context.JobApplications.Add(job);
        await _context.SaveChangesAsync();

        return Ok(job);
    }
}