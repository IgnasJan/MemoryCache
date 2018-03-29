using MemoryCache.Interfaces.Services;
using MemoryCache.Repositories;
using MemoryCache.Services;
using System;

namespace MemoryCache
{
    class Program
    {
        static void Main(string[] args)
        {  
            StudentRepository studentRepository = new StudentRepository();
            ICache cache = new Cache();
            StudentService studentService = new StudentService(studentRepository, cache);
            var myStudent = studentService.GetStudentNameById("123");
            Console.WriteLine(myStudent.Name);
            Console.ReadKey();
        }
    }
}
