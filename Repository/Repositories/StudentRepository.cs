using Model;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> _studentList; 

        public StudentRepository()
        {
            _studentList = new List<Student>() // Imagine current DB data // Should not be that way
            {
                new Student()
                {
                    StudentId = "123",
                    Name = "Ignas"
                },
                new Student()
                {
                    StudentId = "125",
                    Name = "Kazys"
                }
            };
        }

        public Student Get(string id)
        {
            return _studentList.FirstOrDefault(x => x.StudentId.Equals(id));
        }
    }
}
