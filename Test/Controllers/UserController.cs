using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using Test.Data;
using Test.Models.entity;
using Test.Models.ModelView;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public UserController(ApplicationDBContext context)
        {
            this.context = context;
        }

     

        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(context.users.ToList());
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetUserById(int id )
        {
            var user = context.users.Find(id);
            if (user == null){
                return NotFound();
            }
            else
            return Ok(user);
        }
        [HttpPost]
        public IActionResult AddUser(UserDoc user)
        {
            if (!CheckEmail(user))
            {
                return BadRequest("Email already exists.");
            }
            var userLog = new User
            {
                Email = user.Email,
                Password = user.Password,
                FName = user.FName,
                LName = user.LName,
            };
            context.users.Add(userLog);
            context.SaveChanges();
            return Ok(userLog);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult RemoveUserById(int id)
        {
            var user = context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            context.users.Remove(user);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateUserById(int id,UserDoc Updateuser)
        {
            if (!CheckEmail(Updateuser))
            {
                return BadRequest("Email already exists.");
            }
            var user=context.users.Find(id);
            if (user == null) 
            { 
                return NotFound();
            }
            user.Email = Updateuser.Email;
            user.Password = Updateuser.Password;
            user.FName = Updateuser.FName;
            user.LName = Updateuser.LName;
            context.SaveChanges();
            return Ok(user);
        }
        [NonAction]
        public bool CheckEmail(UserDoc user)
        {
            var check = context.users.SingleOrDefault(item => item.Email == user.Email);
            if (check is null)
            {
                string pattern = @"^[a-zA-Z][a-zA-Z0-9._%+-]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (Regex.IsMatch(user.Email, pattern))
                {
                    Console.WriteLine("Valid email");
                    return true;
                }
            }

            return false;
        }

    }
}
