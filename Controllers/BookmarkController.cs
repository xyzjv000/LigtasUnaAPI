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
    public class BookmarkController : ControllerBase
    {

        private readonly ProjectDBContext _context;
        public BookmarkController(ProjectDBContext context)
        {
            _context = context;
        }

        //https://localhost:44348/api/bookmark?userId=&faid=
        [HttpGet]
        public async Task<ActionResult<Bookmark>> GetOneBookmark(int userId,int faid)
        {
            try
            {
                var result = await _context.Bookmarks.FromSqlRaw($"SELECT * FROM [dbo].[Bookmark] WHERE User_ID={userId} AND FaidPR_ID={faid} ").ToListAsync();
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

        //https://localhost:44348/api/bookmark/list?faid=
        [HttpGet("list")]
        public async Task<ActionResult<Bookmark>> GetBookmark(int faid)
        {
            try
            {
                var result = await _context.Bookmarks.FromSqlRaw($"SELECT * FROM [dbo].[Bookmark] WHERE FaidPR_ID={faid}").ToListAsync();
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


        //https://localhost:44348/api/bookmark/owner?userId=
        [HttpGet("one")]
        public async Task<ActionResult<Bookmark>> GetBookmarks(int userId)
        {
            try
            {
                /* var query = from b in _context.Bookmarks
                             join f in _context.Firstaids on b.Firstaids.FaidPR_ID equals f.FaidPR_ID
                             select new
                             {
                                 id = b.Bookmark_ID,
                                 created = b.Bookmark_date,
                                 title = f.FaidPR_ID
                             };
                 var result = await query.OrderBy(o => o.id).ToListAsync();*/
                var result = await _context.Bookmarks.FromSqlRaw($"SELECT * FROM [dbo].[Bookmark] WHERE User_ID={userId}").Include(e => e.Firstaids).ToListAsync();
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


        //https://localhost:44348/api/bookmark/new
        [HttpPost("new")]
        public async Task<ActionResult<Bookmark>> CreateBookmark(int userId, int faid)
        {
            DateTime currentDate = DateTime.Now;
            try
            {
                var result = await _context.Bookmarks.FromSqlRaw($"INSERT INTO [dbo].[Bookmark] (Bookmark_date,User_ID,FaidPR_ID)  VALUES ('{currentDate}',{userId},{faid}) SELECT TOP(1) * FROM [dbo].[Bookmark] ORDER BY Bookmark_ID DESC").ToListAsync();
              
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        //https://localhost:44348/api/bookmark/unbook?userId=&faid=
        [HttpPost("unbook")]
        public async Task<ActionResult<Bookmark>> Unsubscribe(int userId,int faid)
        {

            try
            {
                var result = await _context.Bookmarks.FromSqlRaw($"DELETE FROM [dbo].[Bookmark] WHERE User_ID={userId} AND FaidPR_ID={faid}  SELECT * FROM [dbo].[Bookmark]").ToListAsync();
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
