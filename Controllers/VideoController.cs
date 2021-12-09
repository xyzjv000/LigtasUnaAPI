using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ligtasUnaAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ligtasUnaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public VideoController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateVideo(Video video)
        {
            _context.Entry(video).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Videos.Where(u => u.FaidPR_VidID == video.FaidPR_VidID).ToListAsync();
                return Ok(result);
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to register due to some system error. " +
               "Try again, and if the problem persists, " +
               "see your system administrator.");
            }
            return Ok();
        }
    }
}
