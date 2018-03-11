using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCache
{
    public class ItemService
    {
        private List<CachedItem> _cachedItemList;
        private List<Student> _studentList; //DB

        public ItemService()
        {
            _cachedItemList = new List<CachedItem>();
        }

        public void RemoveOldCache()
        {
            var removeCachedList = new List<CachedItem>();
            foreach (var cache in _cachedItemList)
            {
                if (cache.ExpiryTime < DateTime.Now)
                {
                    removeCachedList.Add(cache);
                }
            }

            foreach(var cache in removeCachedList)
            {
                _cachedItemList.Remove(cache);
            }          
        }

        private void CreateCache(string key, string content)
        {
            var cacheItem = new CachedItem(key, content);
            _cachedItemList.Add(cacheItem);
        }

        public string GetContentByKey(string key)
        {
            foreach (var cache in _cachedItemList)
            {
                if (cache.Key.Equals(key)) return cache.Content;
            }

            foreach (var student in _studentList)
            {
                if (student.StudentId.Equals(key))
                {
                    CreateCache(key, student.Name);
                    return student.Name;
                }
            }


            return null;
        }

        public void InsertStudentIntoDatabase(Student student)
        {
            if (_studentList.Contains(student)) return;

            _studentList.Add(student);
        }
    }
}
