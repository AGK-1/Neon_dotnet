using System.Net.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using SQLE_sam.Model;


namespace SQLE_sam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public  UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Getusers()
        {
            //return Ok(await Task.FromResult("salam"));
            return await _context.Userss.ToListAsync();    
        }


        [HttpGet("With_Id")]
        public async Task<ActionResult<Users>> GetUserID(int id)
        {
            var User = await _context.Userss.FindAsync(id);
            if (User == null)
            {
                return NotFound("NOT");
            }
            return User;
        }

        [HttpDelete("Delete{id}")]
        public async Task<ActionResult<Users>> Delet(int id)
        {
            var del = await _context.Userss.FindAsync(id);
            if (del == null)
            {
                return NotFound("Not found");

            }
            else
            {
                _context.Userss.Remove(del);
                await _context.SaveChangesAsync();
            }
            return Ok("Deleted");
        }

        [HttpPost("Posting")]
        public async Task<ActionResult<Users>> PostNewUser(Users newUser)
        {
            _context.Userss.Add(newUser);
            await _context.SaveChangesAsync();
            return (newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> UpdateUser(int id , Users user)
        {

            var existingUser = await _context.Userss.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User not foun with {id}");
            }
            existingUser.name = user.name;
            existingUser.email = user.email;

            // _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return Ok(existingUser);
        }


    }
}
