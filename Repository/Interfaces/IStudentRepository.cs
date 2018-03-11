using Model;

namespace Repository.Interfaces
{
    public interface IStudentRepository
    {
        Student Get(string id);
    }
}
