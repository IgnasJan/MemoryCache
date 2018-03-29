using MemoryCache.Interfaces.Services;
using Repository.Interfaces;
using MemoryCache;

namespace Student.Services
{
    public class StudentService
    {
        private ICache _cacheService;
        private IStudentRepository _studentRepository;

        public StudentService(ICache cacheService, IStudentRepository studentRepository)
        {
            _cacheService = cacheService;
            _studentRepository = studentRepository;
        }

        public Student GetStudentNameById(string key)
        {
            _studentRepository.Get(key);
            var content = _cacheService.GetContent(key, x => );

            return content;
        }

        private 
    }
}
