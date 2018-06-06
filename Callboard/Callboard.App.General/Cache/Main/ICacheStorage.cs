namespace Callboard.App.General.Cache.Main
{
    public interface ICacheStorage
    {
        bool Add<T>(string key, T obj, int minutes) where T : class;

        T Get<T>(string key) where T : class;

        void Update<T>(string key, T obj, int minutes) where T : class;

        void Delete(string key);
    }
}
