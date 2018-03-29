

using MemoryCache.Interfaces;
using MemoryCache.Interfaces.Services;

namespace MemoryCache.Services
{
    public class StudentService
    {
        private ICache _cache;
        private IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository, ICache cache)
        {
            _cache = cache;
            _studentRepository = studentRepository;
        }

        public Student GetStudentNameById(string id)
        {
            var content = _cache.GetContent(id, x => _studentRepository.Get(id));
            return (Student)content;
        } 
    }
}
