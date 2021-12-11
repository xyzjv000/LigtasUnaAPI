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
    public class FirstaidController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public FirstaidController(ProjectDBContext context)
        {
            _context = context;
        }

        //get all videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firstaid>>> GetFirstAids()
        {
            /*var result = await _context.Firstaids.FromSqlRaw("SELECT * FROM [dbo].[Firstaids]").Select(faid => new
            {
                id = faid.FaidPR_ID,
                title = faid.FaidPR_Name,
                description = faid.FaidPR_Des,
                created = faid.Created
               
            }).ToListAsync();*/

            var query = from faid in _context.Firstaids
                        join cat in _context.Categories on faid.FaidPR_ID equals cat.Firstaids.FaidPR_ID
                        join img in _context.Images on faid.FaidPR_ID equals img.Firstaids.FaidPR_ID
                        join vid in _context.Videos on faid.FaidPR_ID equals vid.Firstaids.FaidPR_ID
                        select new
                        {
                            id = faid.FaidPR_ID,
                            title = faid.FaidPR_Name,
                            description = faid.FaidPR_Des,
                            created = faid.Created,
                            category = cat.Cat_Name,
                            tools = faid.FaidPR_Tools,
                            medicine = faid.FaidPR_Medicine,
                            imgUrl = img.FaidPR_ImgUrl,
                            imgName = img.FaidPR_ImgName,
                            vidUrl = vid.FaidPR_VidUrl,
                            vidName = vid.FaidPR_VidName,
                            views = faid.Views,
                            status = faid.Status
                        };
            var result = await query.OrderBy(o => o.id).ToListAsync();


            return Ok(result);
        }


        [HttpGet("view")]
        public async Task<ActionResult<Firstaid>> GetFirstAid(int id)
        {
            try
            {
                var result = await _context.Firstaids.FromSqlRaw($"SELECT * FROM [dbo].[Firstaids] WHERE FaidPR_ID = {id}").ToListAsync();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Create a new Firstaid Procedure
        //https://localhost:44348/api/firstaid
        [HttpPost]
        public async Task<ActionResult<Firstaid>> CreateFurstAid(Firstaid fa)
        {
            fa.Created = DateTime.Now;
            fa.Views = 0;
            fa.Status = "active";
            _context.Entry(fa).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Firstaids.Where(u => u.FaidPR_ID == fa.FaidPR_ID).ToListAsync();
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

        //Create a new Firstaid Procedure
        //https://localhost:44348/api/firstaid/delete_procedure
        [HttpPost("remove")]
        public async Task<ActionResult<Firstaid>> DeleteFirstAid(int faid)
        {
            
            try
            {
                var result = await _context.Firstaids.FromSqlRaw($"DELETE FROM [dbo].[Bookmark] WHERE FaidPR_ID = {faid}; DELETE FROM [dbo].[Categories] WHERE FaidPR_ID ={faid}; DELETE FROM [dbo].[Images] WHERE FaidPR_ID = {faid}; DELETE FROM [dbo].[Videos] WHERE FaidPR_ID = {faid}; DELETE FROM [dbo].[Feedbacks] WHERE FaidPR_ID = {faid}; DELETE FROM [dbo].[Firstaids] WHERE FaidPR_ID = {faid}; SELECT * FROM [dbo].[Firstaids] WHERE FaidPR_ID = {faid}").ToListAsync();
               /* var categories = await _context.Firstaids.FromSqlRaw($"DELETE FROM [dbo].[Categories] WHERE FaidPR_ID ={faid}").ToListAsync();
                var images = await _context.Firstaids.FromSqlRaw($"DELETE FROM [dbo].[Images] WHERE FaidPR_ID = {faid}").ToListAsync();
                var videos = await _context.Firstaids.FromSqlRaw($"DELETE FROM [dbo].[Videos] WHERE FaidPR_ID = {faid}").ToListAsync();
                var feedbacks = await _context.Firstaids.FromSqlRaw($"DELETE FROM [dbo].[Feedbacks] WHERE FaidPR_ID = {faid}").ToListAsync();
                var firstaid = await _context.Firstaids.FromSqlRaw($"DELETE FROM [dbo].[Firstaids] WHERE FaidPR_ID = {faid}").ToListAsync();
                var result = await _context.Firstaids.FromSqlRaw($"SELECT * FROM [dbo].[Firstaids] WHERE FaidPR_ID = {faid}").ToListAsync();*/
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

        [HttpPost("edit")]
        public async Task<ActionResult<Firstaid>> UpdateFirstAid([FromBody] Firstaid fa  , int faid, int name, int desc)
        {
            var query = "";
           
            if (name == 1)
            {
                query = query += " [dbo].[Firstaids].FaidPR_Name = '" + fa.FaidPR_Name + "'";
            }

            if (desc == 1)
            {
                if(query.Length > 0)
                {
                    query = query += ", [dbo].[Firstaids].FaidPR_Des =  '" + fa.FaidPR_Des + "'";
                }
                else
                {
                    query = query += " [dbo].[Firstaids].FaidPR_Des =  '" + fa.FaidPR_Des + "'";
                }
                
            }

            

            try
            {
                if (desc == 0 && name == 0)
                {
                    var result = await _context.Firstaids.FromSqlRaw($"DELETE [dbo].[Categories] WHERE FaidPR_ID = {faid};  SELECT * FROM [dbo].[Firstaids] WHERE FaidPR_ID = {faid}").ToListAsync();
                    return Ok(result);
                }
                else
                {
                    var result = await _context.Firstaids.FromSqlRaw($"UPDATE [dbo].[Firstaids] SET {query} WHERE FaidPR_ID = {faid}; DELETE [dbo].[Categories] WHERE FaidPR_ID = {faid};  SELECT * FROM [dbo].[Firstaids] WHERE FaidPR_ID = {faid}").ToListAsync();
                    return Ok(result);
                }
                
               
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to register due to some system error. " +
               "Try again, and if the problem persists, " +
               "see your system administrator.");
            }
            return Ok();
        }

        [HttpPost("add_views")]
        public async Task<ActionResult<Firstaid>> AddViews(int faid)
        {
            try
            {
                var result = await _context.Firstaids.FromSqlRaw($"UPDATE [dbo].[Firstaids] SET Views = Views + 1  WHERE FaidPR_ID={faid}; SELECT * FROM [dbo].[Firstaids] WHERE FaidPR_ID={faid}").ToListAsync();
                return Ok(result);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("video_option")]
        public async Task<ActionResult<Firstaid>> VideoOptions(int faid,string status)
        {
            try
            {
                var result = await _context.Firstaids.FromSqlRaw($"UPDATE [dbo].[Firstaids] SET Status = '{status}'  WHERE FaidPR_ID={faid}; SELECT * FROM [dbo].[Firstaids] WHERE FaidPR_ID={faid}").ToListAsync();
                return Ok(result);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
