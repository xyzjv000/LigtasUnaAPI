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
    public class CategoryController : ControllerBase
    {

        private readonly ProjectDBContext _context;
        public CategoryController(ProjectDBContext context)
        {
            _context = context;
        }

        //Create a new Firstaid Procedure
        //https://localhost:44348/api/category
        /*{
            "cat_Name" : "Child Care First Aid",
            "firstaids" : {
                "faidPR_ID" : 2
            }
        }*/
        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category cat, int id)
        {
            _context.Entry(cat).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Categories.Where(u => u.Cat_ID == cat.Cat_ID).ToListAsync();
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
