using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class StudentService: IStudentService
    {
        // private static List<Student> students = new List<Student>();
        private readonly StudentDbContext _db;
        public StudentService(StudentDbContext db)
        {
            _db=db;

        }
        public Student AddStudent(Student s)
        {
            _db.Students.Add(s);
            _db.SaveChanges();
            return s;
        }
        public List<Student> GetAll()
        {
            return _db.Students.ToList();
        }
        public Student? GetByName(string name)
        {
            var student = _db.Students.FirstOrDefault(x=>x.Name== name);
            return student;
        }
        public Student? UpdateStudent(string name, Student updated)
        {
            var student = _db.Students.FirstOrDefault(x=>x.Name == name);
            if(student == null) return null;
            student.Name= updated.Name;
            student.Age = updated.Age;
            _db.SaveChanges();
            return student;
        }
        public bool Delete(string name)
        {
            var s = _db.Students.FirstOrDefault(x=>x.Name == name);
            if(s== null) return false;
            _db.Students.Remove(s);
            return true;
        }
    }
    
}