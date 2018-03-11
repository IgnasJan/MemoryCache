using MemoryCache.Interfaces.Services;
using Repository.Interfaces;

namespace Student.Services
{
    public class StudentService
    {
        private ICacheService _cacheService;
        private IStudentRepository _studentRepository;

        public StudentService(ICacheService cacheService, IStudentRepository studentRepository)
        {
            _cacheService = cacheService;
            _studentRepository = studentRepository;
        }

        public string GetStudentNameById(string key)
        {
            var cache = _cacheService.GetCache(key);
            if (cache != null)
            {
                return cache.Content;
            }
            var student = _studentRepository.Get(key);

            if (student != null)
            {
                _cacheService.CreateCache(student.StudentId, student.Name);
                return student.Name;
            }

            return null;
        }
    }
}
