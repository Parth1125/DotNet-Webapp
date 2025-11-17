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

    
    }

}
