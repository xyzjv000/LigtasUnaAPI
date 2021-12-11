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
    public class OrganizationController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public OrganizationController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Organization>> GetOneOrganization(int userId, int faid)
        {
            try
            {
                var query = from organization in _context.Organizations
                            join user in _context.Users on organization.Users.User_ID equals user.User_ID
                            where user.User_ID.Equals(userId)
                            select new
                            {
                                id = organization.ID,
                                name = organization.Name,
                                contact_Name = organization.Contact_Name,
                                contact_Number = organization.Contact_Number,
                                user_ID = organization.Users.User_ID
                            };
                var result = await query.OrderByDescending(o => o.id).ToListAsync();
               /* var result = await _context.Organizations.FromSqlRaw($"SELECT * FROM [dbo].[Organizations] WHERE User_ID={userId}").ToListAsync();*/
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

        [HttpGet("all")]
        public async Task<ActionResult<Organization>> GetAllOrganization(int userId, int faid)
        {
            try
            {
                var query = from organization in _context.Organizations
                            join user in _context.Users on organization.Users.User_ID equals user.User_ID
                            select new
                            {
                                id = organization.ID,
                                name = organization.Name,
                                contact_Name = organization.Contact_Name,
                                contact_Number = organization.Contact_Number,
                                user_ID = organization.Users.User_ID
                            };
                var result = await query.OrderByDescending(o => o.id).ToListAsync();
                /* var result = await _context.Organizations.FromSqlRaw($"SELECT * FROM [dbo].[Organizations] WHERE User_ID={userId}").ToListAsync();*/
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

        [HttpPost("new")]
        public async Task<ActionResult<Organization>> AddUserOrganization(Organization org)
        {
            _context.Entry(org).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Organizations.Where(u => u.ID == org.ID).ToListAsync();
                return Ok(result);
               /* var result = await _context.Organizations.FromSqlRaw($"INSERT INTO [dbo].[Organizations] (Name,Contact_Name,Contact_Number,User_ID) VALUES ('{org.Name}','{org.Contact_Name}','{org.Contact_Number}', {userId}); SELECT * FROM [dbo].[Organizations]").ToListAsync();
                return Ok(result);*/
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to register due to some system error. " +
               "Try again, and if the problem persists, " +
               "see your system administrator.");
            }
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult<Organization>> UpdateUserOrganization(Organization org, int userId)
        {
            try
            {
                var result = await _context.Organizations.FromSqlRaw($"UPDATE [dbo].[Organizations] SET Name ='{org.Name}' ,Contact_Name= '{org.Contact_Name}' ,Contact_Number='{org.Contact_Number}' WHERE User_ID = {userId}; SELECT * FROM [dbo].[Organizations] WHERE User_ID={userId}").ToListAsync();
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
