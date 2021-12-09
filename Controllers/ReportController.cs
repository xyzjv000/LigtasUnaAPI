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
    public class ReportController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public ReportController(ProjectDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<Report>> GetReports()
        {
            try
            {
                var query = from report in _context.Reports
                            join user in _context.Users on report.Users.User_ID equals user.User_ID
                            select new
                            {
                                id = report.Report_ID,
                                fname = user.User_Fname,
                                lname = user.User_Lname,
                                active = report.Active,
                                subscribe = report.Report_Subc,
                                feedback = report.Report_Feedback,
                                created = report.CreatedAt
                            };
                var result = await query.OrderByDescending(o => o.id).ToListAsync();


                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("active")]
        public async Task<ActionResult<Report>> GetActiveReports()
        {
            try
            {
                /*var result = await _context.Reports.FromSqlRaw($"SELECT * FROM [dbo].[Reports] WHERE Active = 1 ").ToListAsync();*/
                var query = from report in _context.Reports
                            join user in _context.Users on report.Users.User_ID equals user.User_ID
                            where report.Active.Equals(true)
                            select new
                            {
                                id = report.Report_ID,
                                fname = user.User_Fname,
                                lname = user.User_Lname,
                                active = report.Active,
                                subscribe = report.Report_Subc,
                                feedback = report.Report_Feedback,
                                created = report.CreatedAt
                            };
                var result = await query.OrderByDescending(o => o.id).ToListAsync();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<Report>> UpdateAllReports()
        {
            try
            {                                    
                var result = await _context.Reports.FromSqlRaw($"UPDATE [dbo].[Reports] SET Active = 0 WHERE Active = 1 SELECT * FROM [dbo].[Reports]").ToListAsync();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("one")]
        public async Task<ActionResult<Report>> UpdateReport(int id)
        {
            try
            {
                var result = await _context.Reports.FromSqlRaw($"UPDATE [dbo].[Reports] SET Active = 0 WHERE Report_ID = {id} SELECT * FROM [dbo].[Reports]").ToListAsync();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
