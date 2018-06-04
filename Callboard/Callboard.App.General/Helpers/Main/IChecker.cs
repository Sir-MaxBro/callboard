namespace Callboard.App.General.Helpers.Main
{
    public interface IChecker
    {
        void CheckForNull<T>(T obj) where T : class;

        void CheckForNull<T>(T obj, string errorMessage) where T : class;

        void CheckId(int id);

        void CheckId(int id, string errorMessage);
    }
}