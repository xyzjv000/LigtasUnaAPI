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
    public class SubscriptionController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public SubscriptionController(ProjectDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<Subscription>> GetFeedbacks()
        {
            try
            {
                var query = from sub in _context.Subscriptions
                            join user in _context.Users on sub.Users.User_ID equals user.User_ID
                            select new
                            {
                                id = sub.Sub_ID,
                                fname = user.User_Fname,
                                lname = user.User_Lname,
                                number = user.User_ConNum,
                                subDate = sub.Sub_date,
                                userId = user.User_ID,
                                username = user.Username,
                                address = user.User_Address
                            };
                var result = await query.OrderBy(o => o.id).ToListAsync();


                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        //https://localhost:44348/api/subscription
        [HttpPost]
        public async Task<ActionResult<Subscription>> CreateFurstAid(Subscription sub)
        {
            sub.Sub_date = DateTime.Now;
            _context.Entry(sub).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Subscriptions.Where(u => u.Sub_ID == sub.Sub_ID).ToListAsync();
                var generateReport = await _context.Reports.FromSqlRaw($"INSERT INTO [dbo].[Reports] (Report_Subc, Report_Feedback, Active ,User_ID) VALUES (1 , 0 , 1 ,{result[0].Users.User_ID}) SELECT * FROM [dbo].[Reports]").ToListAsync();
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

        //https://localhost:44348/api/subscription/unsubscribe
        [HttpPost("unsubscribe")]
        public async Task<ActionResult<Subscription>> Unsubscribe(int userId)
        {
            
            try
            {
                var result = await _context.Subscriptions.FromSqlRaw($"DELETE FROM [dbo].[Subscriptions] WHERE User_ID={userId} SELECT * FROM [dbo].[Subscriptions]").ToListAsync();                
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
