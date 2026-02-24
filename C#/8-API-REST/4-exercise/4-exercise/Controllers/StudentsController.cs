using _4_exercise.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4_exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private StudentRepository sr;

        public StudentsController(StudentRepository sr)
        {
            this.sr = sr;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            var students = sr.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var studentFind = sr.GetById(id);

            if (studentFind == null)
            {
                return NotFound();
            }
            return Ok(studentFind);
        }
    }
}
