using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _students;
        public MockStudentRepository()
        {
            _students = new List<Student>()
            {
                new Student{ Id=1,Name="张三",ClassName="一年级"},
                new Student{ Id=2,Name="李四",ClassName="二年级"},
                new Student{ Id=3,Name="王五",ClassName="三年级"}
            };
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
           return  _students.FirstOrDefault(d => d.Id == id);
        }
    }
}
