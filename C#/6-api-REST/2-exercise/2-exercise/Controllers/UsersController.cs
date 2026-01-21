using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2_exercise.Models;


namespace _2_exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //[HttpGet("{id}")]
        //public IActionResult GetUser(int id)
        //{
        //    List<User> listUsers = new List<User>();
        //    User u = new User();
        //    u.Id = 0;
        //    u.Name = "Juan";
        //    u.Age = 30;
        //    listUsers.Add(u);

        //    User u1 = new User();
        //    u1.Id = 1;
        //    u1.Name = "Juana";
        //    u1.Age = 31;
        //    listUsers.Add(u1);

        //    User u2 = new User();
        //    u2.Id = 2;
        //    u2.Name = "Jose";
        //    u2.Age = 32;
        //    listUsers.Add(u2);

        //    if (id >= 0 && id < listUsers.Count)
        //    {
        //        User userFind = new User();
        //        foreach(var fa in listUsers)
        //        {
        //            if (fa.Id == id)
        //            {
        //                userFind = fa;
        //                break;
        //            }
        //        }
        //        return Ok(userFind);
        //    }
        //    else
        //    {
        //        return NotFound(404);
        //    }
        //}

        //[HttpGet]
        //public IActionResult GetUsers()
        //{
        //    List<User> listUsers = new List<User>();
        //    User u = new User();
        //    u.Id = 0;
        //    u.Name = "Juan";
        //    u.Age = 30;
        //    listUsers.Add(u);

        //    User u1 = new User();
        //    u1.Id = 1;
        //    u1.Name = "Juana";
        //    u1.Age = 31;
        //    listUsers.Add(u1);

        //    User u2 = new User();
        //    u2.Id = 2;
        //    u2.Name = "Jose";
        //    u2.Age = 32;
        //    listUsers.Add(u2);

        //    return Ok(listUsers);
        //}

        List<User> users = new List<User>();

        [HttpPost]
        public IActionResult Post(User json)
        {
            users.Add(json);
            return Created("", json);

            Console.WriteLine(json.Name);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

    }
}

