using WebApplication1.Models;

namespace WebApplication1.Services
{
public interface IStudentService
    {
        Student AddStudent(Student s);
        List<Student> GetAll();
        Student? GetByName(string name);
        Student? UpdateStudent(string name,Student s);
        bool Delete(string name);
    }
    
}