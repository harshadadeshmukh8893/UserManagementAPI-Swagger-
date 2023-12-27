using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementt.Data;
using UserManagementt.Model;

namespace UserManagementt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext context;
        public UserController(UserContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(context.Users.ToList());
        }

        //[HttpPost]
        //public async Task<IActionResult> AddUser(User user)
        //{
        //    var users = new User()
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        DateOfBirth = user.DateOfBirth,
        //        Designation = user.Designation,
        //        Skills = user.Skills              
        //    };

        //    await context.Users.AddAsync(users);
        //    await context.SaveChangesAsync();
        //    return Ok(users);
        //}
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        [Route("UpdateUser/{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, User user)
        {
            var users = await context.Users.FindAsync(id);
            if (users != null)
            {
                users.Name = user.Name;
                users.DateOfBirth = user.DateOfBirth;
                users.Designation = user.Designation;
                users.Skills = user.Skills;

                await context.SaveChangesAsync();
                return Ok(users);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var users = await context.Users.FindAsync(id);

            if (users != null)
            {
                context.Remove(users);
                await context.SaveChangesAsync();
                return Ok(users);
            }
            return NotFound();
        }
    }
}

