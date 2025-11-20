using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly IStudentService _service;
         public HelloController(IStudentService service)
        {
            _service = service;
        }
        // static List<Student> students = new List<Student>();
        [HttpGet]
        public string SayHello()
        {
            return "Hello Parth!";
        }

    [HttpPost("add")]
    public IActionResult  AddStudent(Student dto)
        {
            // if(!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }
            // Student s = new Student
            // {
            //     Name= dto.Name,
            //     Age=dto.Age,
            // };
            // students.Add(s);
            var result = _service.AddStudent(dto);
            return Ok(result);
        }
    [HttpGet("all")]
    public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

    
    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
        {
            // var student = students.FirstOrDefault(x => x.Name == name);
            // if(student == null) return NotFound("Student not Found");
            var result = _service.GetByName(name);
            if(result== null) return NotFound("Not found");
            return Ok(result);
        }
    [HttpPut("update/{name}")]
    public IActionResult UpdateStudent(string name, Student dto)
        {
          var updated = _service.UpdateStudent(name, dto);
          if (updated == null) return NotFound();
          return Ok(updated);
        }

    [HttpDelete("delete/{name}")]
    public IActionResult DeleteStudent(string name)
        {
            // var s= students.FirstOrDefault(x=>x.Name== name);
            // if(s == null) return NotFound();
            // students.Remove(s);
            var result = _service.Delete(name);
            if(!result) return NotFound();
            return Ok("Deleted Succesfully");
        }
    }
}
