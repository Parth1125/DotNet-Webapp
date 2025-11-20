using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentService: IStudentService
    {
        private static List<Student> students = new List<Student>();
        public Student AddStudent(Student s)
        {
            students.Add(s);
            return s;
        }
        public List<Student> GetAll()
        {
            return students;
        }
        public Student? GetByName(string name)
        {
            var student = students.FirstOrDefault(x=>x.Name== name);
            return student;
        }
        public Student? UpdateStudent(string name, Student updated)
        {
            var student = students.FirstOrDefault(x=>x.Name == name);
            if(student == null) return null;
            student.Name= updated.Name;
            student.Age = updated.Age;
            return student;
        }
        public bool Delete(string name)
        {
            var s = students.FirstOrDefault(x=>x.Name == name);
            if(s== null) return false;
            students.Remove(s);
            return true;
        }
    }
    
}