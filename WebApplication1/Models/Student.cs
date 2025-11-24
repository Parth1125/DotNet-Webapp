using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Student
    {
        public int Id {get;set;}// Primary Key
        [Required]
        public string Name {get;set;}
        [Range(1,120)]
        public int Age {get; set;}
    }
}