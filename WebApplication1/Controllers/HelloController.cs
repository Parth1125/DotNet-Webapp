using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        static List<Student> students = new List<Student>();
        [HttpGet]
        public string SayHello()
        {
            return "Hello Parth!";
        }

    [HttpPost("add")]
    public IActionResult  AddStudent(Student dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Student s = new Student
            {
                Name= dto.Name,
                Age=dto.Age,
            };
            students.Add(s);
            return Ok(s);
        }
    [HttpGet("all")]
    public IActionResult GetAll()
        {
            return Ok(students);
        }

    
    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
        {
            var student = students.FirstOrDefault(x => x.Name == name);
            if(student == null) return NotFound("Student not Found");
            return Ok(student);
        }
    [HttpPut("update/{name}")]
    public IActionResult UpdateStudent(string name, Student dto)
        {
            var s= students.FirstOrDefault(x=> x.Name == name);
            if(s==null) return NotFound();
            s.Name= dto.Name;
            s.Age= dto.Age;

            return Ok(s);
        }

    [HttpDelete("delete/{name}")]
    public IActionResult DeleteStudent(string name)
        {
            var s= students.FirstOrDefault(x=>x.Name== name);
            if(s == null) return NotFound();
            students.Remove(s);
            return Ok("Deleted Succesfully");
        }
    }
}
