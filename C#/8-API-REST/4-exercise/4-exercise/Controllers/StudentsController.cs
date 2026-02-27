using _4_exercise.Entity;
using _4_exercise.Repository;
using Azure.Core;
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
        public IActionResult GetAllStudents()
        {
            var students = sr.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var studentFind = sr.GetById(id);

            if (studentFind == null)
            {
                return NotFound();
            }
            return Ok(studentFind);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            int rowsAffected = sr.AddStudent(student.Name, student.Age, student.Subject);

            if(rowsAffected > 0)
            {
                return StatusCode(201);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            int rowsAffected = sr.DeleteStudent(id);

            if (rowsAffected > 0) {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] Student student, int id)
        {
            if (id != student.Id || student == null) { return BadRequest(); }

            var name = student.Name;
            var age = student.Age;
            var subject = student.Subject;

            int rowsAffected = sr.UpdateStudent(name, age, subject, id);
            if (rowsAffected > 0)
            {
                return Ok();
            }
            return NotFound();
        } 
    }
}
