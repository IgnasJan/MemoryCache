
namespace MemoryCache
{
    public interface ICacheable
    {

    }

    public class Student : ICacheable
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
    }
}
