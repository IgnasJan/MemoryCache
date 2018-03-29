using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryCache;
using Model;
using Student.Services;
using MemoryCache.Services;
using Repository.Repositories;

namespace ItemTests
{
    [TestClass]
    public class MemoryCacheTest
    {
        [TestMethod]
        public void StudentFromCacheTest()
        {
            var studentId = "123";
            //var itemService = new StudentService();
            //var studentOne = new Student()
            //{
            //    Name = "Bjaurimas",
            //    StudentId = studentId
            //};

            //itemService.InsertStudentIntoDatabase(studentOne);
            var studentService = new StudentService(new Cache(), new StudentRepository()); //Ioc
            var name = studentService.GetStudentNameById(studentId);
            
            // Blogai, reiketu mockinti arba keisti savo programos veikima, 
            // Blogas testas jeigu testuoti ar objektas atsidure list ar db? // problema glai but connecttion string ar kur kitur...
            // reikėtų atskirti Item service nuo cache. Controller pirmiau kreiptųsi į cache service ir jeigu neturėtų duomenų - pratęstų veikimą į item service. Pvz interceptor
            // Geriau is vis atskiras solution cache
            // Item service/controler neturėtų būti atsakingas už cache. (Web pvz) //kitas solution
            // DI 
            // Esme zinot ar cache veikia. Gal koks ping - pong?

            Assert.AreEqual(name, "Ignas");
            // Cache keisti i dictionary
            // IStore, ICache
            // Inversion of control
            // 
        }
    }
}

/*1. Get cached item by key, if not exist create

2. Add invalidation period for cached item, on expiration create

3. Support multi-threaded access to cache

4. Write unit-test to prove that cache now is thread sa
*/
