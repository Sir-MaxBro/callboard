using Callboard.App.General.Cache.Main;
using System;
using System.Runtime.Caching;

namespace Callboard.App.General.Cache.Realizations
{
    internal class CacheStorage : ICacheStorage
    {
        private MemoryCache _cache;
        private const string CACHE_NAME = "GeneralCache";
        public CacheStorage()
        {
            _cache = new MemoryCache(CACHE_NAME);
        }

        public bool Add<T>(string key, T obj, int milliseconds)
            where T : class
        {
            if (obj == null)
            {
                return false;
            }
            return _cache.Add(key, obj, DateTime.Now.AddMilliseconds(milliseconds));
        }

        public void Delete(string key)
        {
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
            }
        }

        public T Get<T>(string key)
            where T : class
        {
            object obj = _cache.Get(key);
            return obj as T;
        }

        public void Update<T>(string key, T obj, int milliseconds)
            where T : class
        {
            if (obj == null)
            {
                return;
            }
            _cache.Set(key, obj, DateTime.Now.AddMilliseconds(milliseconds));
        }
    }
}
