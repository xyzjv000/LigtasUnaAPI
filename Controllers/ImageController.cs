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
    public class ImageController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public ImageController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(Image image)
        {
            _context.Entry(image).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Images.Where(u => u.FaidPR_ImgID == image.FaidPR_ImgID).ToListAsync();
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
