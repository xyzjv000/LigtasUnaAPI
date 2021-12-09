using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ligtasUnaAPI.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ligtasUnaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public UserController(ProjectDBContext context)
        {
            _context = context;
        }

        //https://localhost:44348/api/user || https://localhost:44348/api/user?type=admin or user
        [HttpGet]
        public async Task<ActionResult<User>> GetUsers(string type)
        {
            try
            {
                if (type == null)
                {
                    var result = await _context.Users.FromSqlRaw("SELECT * FROM [dbo].[Users]").ToListAsync();
                    return Ok(result);
                }
                else
                {
                    var result = await _context.Users.FromSqlRaw($"SELECT * FROM [dbo].[Users] WHERE [dbo].[Users].User_Type = '{type}'").ToListAsync();
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

     


        //https://localhost:44348/api/user?type=user || https://localhost:44348/api/user?type=admin
        //Body
        /*{
            "user_fname" : "admin",
            "user_lname" : "admin",
            "user_address" : "admin",
            "user_conNum" : "00000000000",
            "username" : "admin",
            "password" : "admin",
            "location_long" : "123.93571360000001",
            "location_lat" : "10.3321417"
        }*/
        [HttpPost]
        public async Task<ActionResult<User>> CreateUsers(User user, string type)
        {
            user.User_Type = type;
            if (type == "user")
            {
                user.Status = "inactive";
            }
            else
            {
                user.Status = "active";
            }
            user.User_CreatedAt = DateTime.Now;
            user.User_UpdatedAt = DateTime.Now;
            _context.Entry(user).State = EntityState.Added;
            try
            {
                await _context.SaveChangesAsync();
                var result = await _context.Users.Where(u => u.User_ID == user.User_ID).ToListAsync();
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

        //https://localhost:44348/api/user/login?type=user || https://localhost:44348/api/user/login?type=admin
        //Body
        /* {
             "username": "jesvir",
             "password": "123"
        }*/
        [HttpPost("login")]
        public async Task<ActionResult> Login(string type, [FromBody] User user)
        {

            try
            {
                var data = await _context.Users.FromSqlRaw($"SELECT * FROM [dbo].[Users] WHERE [dbo].[Users].Username = '{user.Username}' AND [dbo].[Users].password = '{user.Password}' AND [dbo].[Users].user_type = '{type}' ").ToListAsync();
                return Ok(data);
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to register due to some system error. " +
               "Try again, and if the problem persists, " +
               "see your system administrator.");
            }
            return Ok();


        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateProfile([FromBody] User user)
        {

            try
            {
                user.User_UpdatedAt = DateTime.Now;
                if (user.Password != null)
                {
                    var data = await _context.Users.FromSqlRaw($"UPDATE [dbo].[Users] SET User_Fname = '{user.User_Fname}', User_Lname='{user.User_Lname}' , Password='{user.Password}' , User_Address = '{user.User_Address}', User_ConNum = '{user.User_ConNum}', Username = '{user.Username}', Secret='{user.Secret}' , User_UpdatedAt = '{user.User_UpdatedAt}' WHERE User_ID = {user.User_ID} SELECT * FROM [dbo].[Users] WHERE User_ID = {user.User_ID}").ToListAsync();
                    return Ok(data);
                }
                else
                {
                    var data = await _context.Users.FromSqlRaw($"UPDATE [dbo].[Users] SET User_Fname = '{user.User_Fname}', User_Lname='{user.User_Lname}', User_Address = '{user.User_Address}', Username = '{user.Username}', Secret='{user.Secret}' , User_ConNum = '{user.User_ConNum}', User_UpdatedAt = '{user.User_UpdatedAt}' WHERE User_ID = {user.User_ID} SELECT * FROM [dbo].[Users] WHERE User_ID = {user.User_ID}").ToListAsync();
                    return Ok(data);
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

        [HttpPut("update_password")]
        public async Task<ActionResult> ChangePassword([FromBody] User user)
        {

            try
            {
                user.User_UpdatedAt = DateTime.Now;

                var data = await _context.Users.FromSqlRaw($"UPDATE [dbo].[Users] SET Password='{user.Password}' , User_UpdatedAt = '{user.User_UpdatedAt}' WHERE User_ID = {user.User_ID} SELECT * FROM [dbo].[Users] WHERE User_ID = {user.User_ID}").ToListAsync();
                return Ok(data);

            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to register due to some system error. " +
               "Try again, and if the problem persists, " +
               "see your system administrator.");
            }
            return Ok();
        }

        [HttpPut("update_token")]
        public async Task<ActionResult> UpdateUserToken([FromBody] User user)
        {

            try
            {
                user.User_UpdatedAt = DateTime.Now;

                var data = await _context.Users.FromSqlRaw($"UPDATE [dbo].[Users] SET Token='{user.Token}' , User_UpdatedAt = '{user.User_UpdatedAt}' WHERE User_ID = {user.User_ID} SELECT * FROM [dbo].[Users] WHERE User_ID = {user.User_ID}").ToListAsync();
                return Ok(data);

            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to register due to some system error. " +
               "Try again, and if the problem persists, " +
               "see your system administrator.");
            }
            return Ok();
        }

        [HttpPut("remove_token")]
        public async Task<ActionResult> RemoveUserToken([FromBody] User user)
        {

            try
            {
                user.User_UpdatedAt = DateTime.Now;

                var data = await _context.Users.FromSqlRaw($"UPDATE [dbo].[Users] SET Token= NULL , User_UpdatedAt = '{user.User_UpdatedAt}' WHERE User_ID = {user.User_ID} SELECT * FROM [dbo].[Users] WHERE User_ID = {user.User_ID}").ToListAsync();
                return Ok(data);

            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to register due to some system error. " +
               "Try again, and if the problem persists, " +
               "see your system administrator.");
            }
            return Ok();
        }

        [HttpPost("forget_password")]
        public async Task<ActionResult> ForgetPassword(string username, string password, string secret)
        {
            try
            {
                var result = await _context.Users.FromSqlRaw($"UPDATE [dbo].[Users] SET Password = '{password}' WHERE Username = '{username}' AND Secret = '{secret}' SELECT * FROM [dbo].[Users] WHERE Username = '{username}'").ToListAsync();
                return Ok(result);

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        [HttpPost("approve_user")]
        public async Task<ActionResult> UserApproval(int id, string status)
        {
            try
            {
                var result = await _context.Users.FromSqlRaw($"UPDATE [dbo].[Users] SET Status = '{status}' WHERE User_ID={id} SELECT * FROM [dbo].[Users] WHERE User_ID={id}").ToListAsync();
                return Ok(result);

            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }
}
