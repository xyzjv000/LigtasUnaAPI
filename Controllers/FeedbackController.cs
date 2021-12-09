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
    public class FeedbackController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public FeedbackController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<Feedback>> GetFeedbacks(int id)
        {
            try
            {
                var query = from feed in _context.Feedbacks
                            join user in _context.Users on feed.Users.User_ID equals user.User_ID
                            select new
                            {
                                id = feed.Feed_ID,
                                fname = user.User_Fname,
                                lname = user.User_Lname,
                                description = feed.Feed_Descrp,
                                created = feed.Feed_Date,
                                faid = feed.Firstaids.FaidPR_ID
                            };
                var result = await query.Where(cond => cond.faid == id).OrderBy(o => o.id).ToListAsync();


                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("list_user")]
        public async Task<ActionResult<Feedback>> GetUserFeedbacks(int id)
        {
            try
            {
                var query = from feed in _context.Feedbacks
                            join user in _context.Users on feed.Users.User_ID equals user.User_ID
                            join firstaid in _context.Firstaids on feed.Firstaids.FaidPR_ID equals firstaid.FaidPR_ID
                            where feed.Users.User_ID.Equals(id)
                            select new
                            {
                                id = feed.Feed_ID,
                                fname = user.User_Fname,
                                lname = user.User_Lname,
                                description = feed.Feed_Descrp,
                                title = firstaid.FaidPR_Name,
                                created = feed.Feed_Date,
                                faid = feed.Firstaids.FaidPR_ID
                            };
                var result = await query.OrderBy(o => o.faid).ToListAsync();


                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Create a new Firstaid Procedure
        //https://localhost:44348/api/feedback
        [HttpPost]
        public async Task<ActionResult<Feedback>> CreateFurstAid(Feedback fd)
        {
            fd.Feed_Date = DateTime.Now;
            _context.Entry(fd).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Feedbacks.Where(u => u.Feed_ID == fd.Feed_ID).ToListAsync();
                var generateReport = await  _context.Reports.FromSqlRaw($"INSERT INTO [dbo].[Reports] (Report_Subc, Report_Feedback, Active ,User_ID) VALUES (0 , 1 , 1 ,{result[0].Users.User_ID}) SELECT * FROM [dbo].[Reports]").ToListAsync();
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
