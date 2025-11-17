using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Student
    {
        [Required]
        public string Name {get;set;}
        [Range(1,120)]
        public int Age {get; set;}
    }
}