using MemoryCache.Interfaces.Services;
using MemoryCache.Services;
using Repository.Interfaces;
using Repository.Repositories;
using Unity;

namespace Student
{
    public static class UnityFactory // on Application start
    {
        public static void RegisterTypes()
        {
            var container = new UnityContainer();
            container.RegisterType<ICache, Cache>();
            container.RegisterType<IStudentRepository, StudentRepository>();

        }
    }
}
